using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web.SmartTable;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.News.Areas.News.ViewModels;
using SimplCommerce.Module.News.Models;
using SimplCommerce.Module.News.Services;

namespace SimplCommerce.Module.News.Areas.News.Controllers
{
    [Area("News")]
    //[Authorize(Roles = "admin")]
    [Route("api/news-items")]
    public class NewsItemApiController : Controller
    {
        private readonly IRepository<NewsItem> _newsItemRepository;
        private readonly INewsItemService _newsItemService;
        private readonly IMediaService _mediaService;
        private readonly IWorkContext _workContext;
        private readonly IRepository<NewsCategory> _newsCategoryRepository;
        private int _pageSize;

        public NewsItemApiController(IRepository<NewsItem> newsItemRepository, IConfiguration config, IRepository<NewsCategory> newsCategoryRepository, INewsItemService newsItemService, IMediaService mediaService, IWorkContext workContext)
        {
            _newsItemRepository = newsItemRepository;
            _newsItemService = newsItemService;
            _mediaService = mediaService;
            _workContext = workContext;
            _newsCategoryRepository = newsCategoryRepository;
            _pageSize = config.GetValue<int>("News.PageSize");
        }

        [HttpPost("grid")]
        public IActionResult Get([FromBody] SmartTableParam param)
        {
            var query = _newsItemRepository.Query().Where(x => !x.IsDeleted);

            if (param.Search.PredicateObject != null)
            {
                dynamic search = param.Search.PredicateObject;

                if (search.Name != null)
                {
                    string name = search.Name;
                    query = query.Where(x => x.Name.Contains(name));
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

            var newsItems = query.ToSmartTableResult(
                param,
                x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    Slug = x.Slug,
                    IsPublished = x.IsPublished,
                    CreatedOn = x.CreatedOn
                });
            return Json(newsItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var newsItem = await _newsItemRepository.Query()
               .Include(x => x.ThumbnailImage)
               .Include(x => x.Categories)
               .FirstOrDefaultAsync(x => x.Id == id);

            if (newsItem == null)
            {
                return NotFound();
            }

            var model = new NewsItemForm()
            {
                Name = newsItem.Name,
                Id = newsItem.Id,
                Slug = newsItem.Slug,
                MetaTitle = newsItem.MetaTitle,
                MetaKeywords = newsItem.MetaKeywords,
                MetaDescription = newsItem.MetaDescription,
                ShortContent = newsItem.ShortContent,
                FullContent = newsItem.FullContent,
                IsPublished = newsItem.IsPublished,
                ThumbnailImageUrl = _mediaService.GetThumbnailUrl(newsItem.ThumbnailImage),
                NewsCategoryIds = newsItem.Categories.Select(x => x.CategoryId).ToList()
            };

            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post(NewsItemForm model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentUser = await _workContext.GetCurrentUser();
            var newsItem = new NewsItem
            {
                Name = model.Name,
                Slug = model.Slug,
                MetaTitle = model.MetaTitle,
                MetaKeywords = model.MetaKeywords,
                MetaDescription = model.MetaDescription,
                ShortContent = model.ShortContent,
                FullContent = model.FullContent,
                IsPublished = model.IsPublished,
                CreatedBy = currentUser,
                LatestUpdatedBy = currentUser
            };

            foreach (var categoryId in model.NewsCategoryIds)
            {
                var newsItemCategory = new NewsItemCategory
                {
                    CategoryId = categoryId
                };
                newsItem.AddNewsItemCategory(newsItemCategory);
            }

            await SaveServiceMedia(model.ThumbnailImage, newsItem);
            _newsItemService.Create(newsItem);
            return CreatedAtAction(nameof(Get), new { id = newsItem.Id }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, NewsItemForm model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newsItem = await _newsItemRepository.Query()
               .Include(x => x.ThumbnailImage)
               .Include(x => x.Categories)
               .FirstOrDefaultAsync(x => x.Id == id);
            if (newsItem == null)
            {
                return NotFound();
            }

            var currentUser = await _workContext.GetCurrentUser();

            newsItem.Name = model.Name;
            newsItem.Slug = model.Slug;
            newsItem.MetaTitle = model.MetaTitle;
            newsItem.MetaKeywords = model.MetaKeywords;
            newsItem.MetaDescription = model.MetaDescription;
            newsItem.ShortContent = model.ShortContent;
            newsItem.FullContent = model.FullContent;
            newsItem.IsPublished = model.IsPublished;
            newsItem.LatestUpdatedOn = DateTimeOffset.Now;
            newsItem.LatestUpdatedBy = currentUser;

            AddOrDeleteCategories(model, newsItem);

            if (model.ThumbnailImage != null && newsItem.ThumbnailImage != null)
            {
                await _mediaService.DeleteMediaAsync(newsItem.ThumbnailImage);
            }

            await SaveServiceMedia(model.ThumbnailImage, newsItem);
            _newsItemService.Update(newsItem);
            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var newsItem = await _newsItemRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if (newsItem == null)
            {
                return NotFound();
            }

            await _newsItemService.Delete(newsItem);
            return NoContent();
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Value.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _mediaService.SaveMediaAsync(file.OpenReadStream(), fileName, file.ContentType);
            return fileName;
        }

        private async Task SaveServiceMedia(IFormFile image, NewsItem newsItem)
        {
            if (image != null)
            {
                var fileName = await SaveFile(image);
                if (newsItem.ThumbnailImage != null)
                {
                    newsItem.ThumbnailImage.FileName = fileName;
                }
                else
                {
                    newsItem.ThumbnailImage = new Media { FileName = fileName };
                }
            }
        }

        private void AddOrDeleteCategories(NewsItemForm model, NewsItem newsItem)
        {
            foreach (var categoryId in model.NewsCategoryIds)
            {
                if (newsItem.Categories.Any(x => x.CategoryId == categoryId))
                {
                    continue;
                }

                var newsItemCategory = new NewsItemCategory
                {
                    CategoryId = categoryId
                };
                newsItem.AddNewsItemCategory(newsItemCategory);
            }

            var deletedNewsItemCategories =
                newsItem.Categories.Where(newsItemCategory => !model.NewsCategoryIds.Contains(newsItemCategory.CategoryId))
                    .ToList();

            foreach (var deletedNewsItemCategory in deletedNewsItemCategories)
            {
                deletedNewsItemCategory.NewsItem = null;
                newsItem.Categories.Remove(deletedNewsItemCategory);
            }
        }
        [HttpGet("news")]
        public IActionResult NewsHome(int page)
        {
            var newsCategoryList = _newsCategoryRepository.Query()
                .Include(x => x.NewsItems)
                .Where(x => !x.IsDeleted)
                .Select(x => new NewsCategoryVm()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Slug = x.Slug
                })
                .ToList();

            var model = new NewsVm()
            {
                NewsCategory = newsCategoryList
            };

            var query = _newsItemRepository.Query()
                .Where(x => !x.IsDeleted && x.IsPublished)
                .OrderByDescending(x => x.CreatedOn);

            model.TotalItem = query.Count();
            var currentPageNum = page <= 0 ? 1 : page;
            var offset = (_pageSize * currentPageNum) - _pageSize;
            while (currentPageNum > 1 && offset >= model.TotalItem)
            {
                currentPageNum--;
                offset = (_pageSize * currentPageNum) - _pageSize;
            }

            model.NewsItem = query.Include(x => x.ThumbnailImage).Select(x => new NewsItemThumbnail()
            {
                Id = x.Id,
                ShortContent = x.ShortContent,
                ImageUrl = _mediaService.GetMediaUrl(x.ThumbnailImage),
                PublishedOn = x.CreatedOn,
                Slug = x.Slug
            })
            .Skip(offset)
            .Take(_pageSize)
            .ToList();

            model.PageSize = _pageSize;
            model.Page = currentPageNum;
            return View(model);
        }
        [HttpGet("GetNewsItemDetail/{id}")]
        public IActionResult GetNewsItemDetail(long id)
        {
            var newsItem = _newsItemRepository.Query()
                .Include(x => x.ThumbnailImage)
                .FirstOrDefault(x => x.Id == id && x.IsPublished && !x.IsDeleted);

            if (newsItem == null)
            {
                return Ok(new { statusCode = 400, data = "Doesn't contains the record" });
            }

            var model = new NewsItemVm()
            {
                Name = newsItem.Name,
                FullContent = newsItem.FullContent,
                ThumbnailImageUrl = _mediaService.GetThumbnailUrl(newsItem.ThumbnailImage)
            };

            return Ok(model);
        }

    }
}
