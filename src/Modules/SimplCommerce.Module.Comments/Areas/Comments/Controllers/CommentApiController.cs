using System;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimplCommerce.Infrastructure.Web.SmartTable;
using SimplCommerce.Module.Comments.Areas.Comments.ViewModels;
using SimplCommerce.Module.Comments.Data;
using SimplCommerce.Module.Comments.Models;
using SimplCommerce.Module.Core.Extensions;

namespace SimplCommerce.Module.Comments.Areas.Comments.Controllers
{
    [Area("Comments")]
    // [Authorize(Roles = "admin")]
    [Route("api/comments")]
    public class CommentApiController : Controller
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMediator _mediator;
        private readonly IWorkContext _workContext;
        private readonly IConfiguration _config;
        private const int DefaultPageSize = 10;
        public CommentApiController(ICommentRepository commentRepository, IMediator mediator, IWorkContext workContext, IConfiguration config)
        {
            _commentRepository = commentRepository;
            _mediator = mediator;
            _workContext = workContext;
            _config = config;
        }

        [HttpGet]
        public ActionResult Get(int status, int numRecords)
        {
            var reviewStatus = (CommentStatus)status;
            if ((numRecords <= 0) || (numRecords > 100))
            {
                numRecords = 5;
            }

            var model = _commentRepository
                .List()
                .Where(x => x.Status == reviewStatus)
                .OrderByDescending(x => x.CreatedOn)
                .Take(numRecords)
                .Select(x => new
                {
                    x.Id,
                    x.CommenterName,
                    x.EntityName,
                    x.EntitySlug,
                    x.CommentText,
                    x.ParentId,
                    Status = x.Status.ToString(),
                    x.CreatedOn
                });

            return Json(model);
        }

        [HttpPost("grid")]
        public ActionResult List([FromBody] SmartTableParam param)
        {
            var query = _commentRepository.List();

            if (param.Search.PredicateObject != null)
            {
                dynamic search = param.Search.PredicateObject;
                if (search.Id != null)
                {
                    long id = search.Id;
                    query = query.Where(x => x.Id == id);
                }

                if (search.EntityName != null)
                {
                    string entityName = search.EntityName;
                    query = query.Where(x => x.EntityName == entityName);
                }

                if (search.Status != null)
                {
                    var status = (CommentStatus)search.Status;
                    query = query.Where(x => x.Status == status);
                }

                if (search.CreatedOn != null)
                {
                    if (search.CreatedOn.before != null)
                    {
                        DateTimeOffset before = search.CreatedOn.before;
                        query = query.Where(x => x.CreatedOn <= before);
                    }

                    if (search.CreatedOn.after != null)
                    {
                        DateTimeOffset after = search.CreatedOn.after;
                        query = query.Where(x => x.CreatedOn >= after);
                    }
                }
            }

            var comments = query.ToSmartTableResult(
                param,
                x => new
                {
                    x.Id,
                    x.CommenterName,
                    x.CommentText,
                    x.EntityName,
                    x.EntitySlug,
                    x.ParentId,
                    Type = x.ParentId == null ? "Comment" : "Reply",
                    Status = x.Status.ToString(),
                    x.CreatedOn
                });

            return Json(comments);
        }

        [HttpPost("change-status/{id}")]
        public async Task<IActionResult> ChangeStatus(long id, [FromBody] int statusId)
        {
            var comment = _commentRepository.Query().FirstOrDefault(x => x.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            if (Enum.IsDefined(typeof(CommentStatus), statusId))
            {
                comment.Status = (CommentStatus)statusId;
                _commentRepository.SaveChanges();

                await _commentRepository.SaveChangesAsync();
                return Accepted();
            }

            return BadRequest(new { Error = "unsupported order status" });
        }
        [HttpGet("GetCommentById/{entityId}/{entityTypeId}/{search}/{page}")]
        public async Task<IActionResult> GetCommentById(long entityId, string entityTypeId, string search, int page)
        {
            var currentUser = await _workContext.GetCurrentUser();
            var itemsPerPage = DefaultPageSize;
            var offset = (itemsPerPage * page) - itemsPerPage;
            var query = _commentRepository.Query().Where(x => x.EntityId == entityId && x.EntityTypeId == entityTypeId && x.Parent == null);
            if (!User.IsInRole("admin"))
            {
                query = query.Where(x => x.UserId == currentUser.Id || x.Status == CommentStatus.Approved);
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.CommenterName.Contains(search));
            }
            var totalItems = await query.CountAsync();
            var items = await query.OrderByDescending(x => x.CreatedOn).Select(x => new CommentItem
            {
                Id = x.Id,
                CommentText = x.CommentText,
                CommenterName = x.CommenterName,
                CreatedOn = x.CreatedOn,
                Status = x.Status.ToString(),
                Replies = x.Replies
                            .Where(r => r.Status == CommentStatus.Approved)
                            .OrderByDescending(r => r.CreatedOn)
                            .Select(r => new CommentItem()
                            {
                                Id = r.Id,
                                CommentText = r.CommentText,
                                CommenterName = r.CommenterName,
                                CreatedOn = r.CreatedOn,
                                Status = x.Status.ToString()
                            })
            })
                .Skip(offset)
                .Take(itemsPerPage)
                .ToListAsync();

            return Ok(new { TotalItems = totalItems, Items = items });
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CommentForm model)
        {
            if (ModelState.IsValid)
            {
                var user = await _workContext.GetCurrentUser();
                var comment = new Comment
                {
                    ParentId = model.ParentId,
                    CommentText = model.CommentText,
                    CommenterName = user.FullName,
                    Status = CommentStatus.Approved,
                    EntityId = model.EntityId,
                    EntityTypeId = model.EntityTypeId,
                    UserId = user.Id
                };

                if (!User.IsInRole("admin"))
                {
                    var isCommentsRequireApproval = _config.GetValue<bool>("Catalog.IsCommentsRequireApproval");
                    comment.Status = isCommentsRequireApproval ? CommentStatus.Pending : CommentStatus.Approved;
                }

                _commentRepository.Add(comment);
                await _commentRepository.SaveChangesAsync();
                var commentItem = new CommentItem
                {
                    Id = comment.Id,
                    CommentText = comment.CommentText,
                    CommenterName = comment.CommenterName,
                    CreatedOn = comment.CreatedOn,
                    Status = comment.Status.ToString()
                };

                return Ok(commentItem);
            }

            return BadRequest(ModelState);
        }

    }

}
