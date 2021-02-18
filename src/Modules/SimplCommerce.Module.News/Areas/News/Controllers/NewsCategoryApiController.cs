using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.News.Areas.News.ViewModels;
using SimplCommerce.Module.News.Models;
using SimplCommerce.Module.News.Services;

namespace SimplCommerce.Module.News.Areas.News.Controllers
{
    [Area("News")]
    // [Authorize(Roles = "admin")]
    [Route("api/news-categories")]
    public class NewsCategoryApiController : Controller
    {
        private readonly IRepository<NewsCategory> _categoryRepository;
        private readonly INewsCategoryService _categoryService;
        private int _pageSize;
        private readonly IRepository<NewsItem> _newsItemRepository;
        private readonly IMediaService _mediaService;
        private readonly IRepository<NewsCategory> _newsCategoryRepository;
        public NewsCategoryApiController(IRepository<NewsCategory> categoryRepository, INewsCategoryService categoryService, IRepository<NewsCategory> newsCategoryRepository, IRepository<NewsItem> newsItemRepository, IConfiguration config, IMediaService mediaService)
        {
            _categoryRepository = categoryRepository;
            _categoryService = categoryService;
            _newsItemRepository = newsItemRepository;
            _newsCategoryRepository = newsCategoryRepository;
            _mediaService = mediaService;
            _pageSize = config.GetValue<int>("News.PageSize");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categoryList = await _categoryRepository.Query().Where(x => !x.IsDeleted).ToListAsync();

            return Json(categoryList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var category = await _categoryRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            var model = new NewsCategoryForm
            {
                Id = category.Id,
                Name = category.Name,
                Slug = category.Slug,
                MetaTitle = category.MetaTitle,
                MetaKeywords = category.MetaKeywords,
                MetaDescription = category.MetaDescription,
                IsPublished = category.IsPublished
            };

            return Json(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Post([FromBody] NewsCategoryForm model)
        {
            if (ModelState.IsValid)
            {
                var category = new NewsCategory
                {
                    Name = model.Name,
                    Slug = model.Slug,
                    MetaTitle = model.MetaTitle,
                    MetaKeywords = model.MetaKeywords,
                    MetaDescription = model.MetaDescription,
                    IsPublished = model.IsPublished
                };

                await _categoryService.Create(category);
                return CreatedAtAction(nameof(Get), new { id = category.Id }, null);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Put(long id, [FromBody] NewsCategoryForm model)
        {
            if (ModelState.IsValid)
            {
                var category = _categoryRepository.Query().FirstOrDefault(x => x.Id == id);
                category.Name = model.Name;
                category.Slug = model.Slug;
                category.MetaTitle = model.MetaTitle;
                category.MetaKeywords = model.MetaKeywords;
                category.MetaDescription = model.MetaDescription;
                category.IsPublished = model.IsPublished;

                await _categoryService.Update(category);
                return Accepted();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(long id)
        {
            var category = await _categoryRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            await _categoryService.Delete(category);
            return NoContent();
        }
        [HttpGet("GetNewsCategoryDetail/{id}/{page}")]
        public IActionResult GetNewsCategoryDetail(long id, int page)
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

            if (newsCategoryList == null || newsCategoryList.Count == 0)
            {
                return Ok(new { statusCode = 400, data = "Doesn't contains the record" });
            }

            var currentNewsCategory = newsCategoryList.Select(x => new NewsCategoryVm()
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug
            })
            .FirstOrDefault(x => x.Id == id);

            var model = new NewsVm()
            {
                CurrentNewsCategory = currentNewsCategory,
                NewsCategory = newsCategoryList
            };

            var query = _newsItemRepository.Query()
                .Where(x => x.Categories.Any(c => c.CategoryId == currentNewsCategory.Id) && !x.IsDeleted && x.IsPublished)
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
            return Ok(model);
        }

    }
}
