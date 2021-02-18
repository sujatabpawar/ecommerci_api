using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web.SmartTable;
using SimplCommerce.Module.Contacts.Areas.Contacts.ViewModels;
using SimplCommerce.Module.Contacts.Models;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.Contacts.Areas.Contacts.Controllers
{
    [Area("Contacts")]
    //[Authorize(Roles = "admin")]
    [Route("api/contacts")]
    public class ContactApiController : Controller
    {
        private readonly IRepository<Contact> _contactRepository;
        private readonly IMediaService _mediaService;
        private readonly IWorkContext _workContext;
        private readonly IRepository<ContactArea> _contactAreaRepository;
        private readonly IContentLocalizationService _contentLocalizationService;

        public ContactApiController(IRepository<Contact> contactRepository, IRepository<ContactArea> contactAreaRepository, IMediaService mediaService, IWorkContext workContext, IContentLocalizationService contentLocalizationService)
        {
            _contactRepository = contactRepository;
            _mediaService = mediaService;
            _workContext = workContext;
            _contactAreaRepository = contactAreaRepository;
            _contentLocalizationService = contentLocalizationService;
        }

        [HttpPost("grid")]
        public IActionResult Get([FromBody] SmartTableParam param)
        {
            var query = _contactRepository.Query()
                .Where(x => !x.IsDeleted);

            if (param.Search.PredicateObject != null)
            {
                dynamic search = param.Search.PredicateObject;

                if (search.FullName != null)
                {
                    string name = search.FullName;
                    query = query.Where(x => x.FullName.Contains(name));
                }

                if (search.ContactAreaId != null)
                {
                    long id = search.ContactAreaId;
                    query = query.Where(x => x.ContactArea.Id == id);
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

            var contacts = query.ToSmartTableResult(
                param,
                x => new
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    ContactArea = x.ContactArea.Name,
                    CreatedOn = x.CreatedOn,
                    Content = x.Content
                });
            return Json(contacts);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var contact = _contactRepository.Query()
               .Include(x => x.ContactArea)
               .FirstOrDefault(x => x.Id == id);

            var model = new ContactForm()
            {
                FullName = contact.FullName,
                PhoneNumber = contact.PhoneNumber,
                EmailAddress = contact.EmailAddress,
                Address = contact.Address,
                Content = contact.Content,
                CreatedOn = contact.CreatedOn,
                ContactArea = contact.ContactArea.Name
            };

            return Json(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var contact = _contactRepository.Query().FirstOrDefault(x => x.Id == id);

            if (contact == null)
            {
                return NotFound();
            }

            contact.IsDeleted = true;
            _contactRepository.SaveChanges();

            return Ok();
        }
        [HttpGet("contact")]
        public async Task<IActionResult> Index()
        {
            var model = new ContactVm()
            {
                ContactAreas = GetContactArea()
            };

            if (User.Identity.IsAuthenticated)
            {
                var currentUser = await _workContext.GetCurrentUser();

                model.FullName = currentUser.FullName;
                model.EmailAddress = currentUser.Email;
                model.PhoneNumber = currentUser.PhoneNumber;
            }

            return Ok(model);
        }
        [HttpPost("contact")]
        public IActionResult SubmitContact(ContactVm model)
        {
            if (ModelState.IsValid)
            {
                var contact = new Models.Contact()
                {
                    FullName = model.FullName,
                    PhoneNumber = model.PhoneNumber,
                    EmailAddress = model.EmailAddress,
                    Address = model.Address,
                    ContactAreaId = model.ContactAreaId,
                    Content = model.Content
                };

                _contactRepository.Add(contact);
                _contactRepository.SaveChanges();

                return View("SubmitContactResult", model);
            }

            model.ContactAreas = GetContactArea();
            return Ok(model);
            // return View("Index", model);
        }
        private IList<ContactAreaVm> GetContactArea()
        {
            var getContactAreaName = _contentLocalizationService.GetLocalizationFunction<ContactArea>();
            var categories = _contactAreaRepository.Query()
                .Where(x => !x.IsDeleted)
                .Select(x => new ContactAreaVm()
                {
                    Id = x.Id,
                    Name = getContactAreaName(x.Id, nameof(x.Name), x.Name)
                })
                .ToList();

            return categories;
        }
    }
}

