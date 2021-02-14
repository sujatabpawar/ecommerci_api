using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Catalog.Services;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.Catalog.Areas.Catalog.Controllers
{
    [Area("Catalog")]
    [Authorize(Roles = "admin, vendor")]
    [Route("api/brands")]
    [ApiController]
    public class BrandApiController : Controller
    {
        private readonly IRepository<Brand> _brandRepository;
        private readonly IBrandService _brandService;
        private int _pageSize;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMediaService _mediaService;
        private readonly IRepository<Product> _productRepository;
        private readonly IProductPricingService _productPricingService;
        private readonly IContentLocalizationService _contentLocalizationService;

        public BrandApiController(IRepository<Brand> brandRepository,
            IBrandService brandService,
            IRepository<Product> productRepository,
            IMediaService mediaService,
            IRepository<Category> categoryRepository,
            IProductPricingService productPricingService,
            IConfiguration config,
            IContentLocalizationService contentLocalizationService)
        {
            _brandRepository = brandRepository;
            _brandService = brandService;
            _productRepository = productRepository;
            _mediaService = mediaService;
            _categoryRepository = categoryRepository;
            _productPricingService = productPricingService;
            _contentLocalizationService = contentLocalizationService;
            _pageSize = config.GetValue<int>("Catalog.ProductPageSize");
        }

        [HttpGet]
        public async Task<ActionResult<IList<BrandVm>>> Get()
        {
            var brands = await _brandRepository.Query()
            .Where(x => !x.IsDeleted)
            .Select(x =>  new BrandVm
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                IsPublished = x.IsPublished
            }).ToListAsync();

            return brands;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BrandVm>> Get(long id)
        {
            var brand = await _brandRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if(brand == null)
            {
                return NotFound();
            }

            var model = new BrandVm
            {
                Id = brand.Id,
                Name = brand.Name,
                Slug = brand.Slug,
                IsPublished = brand.IsPublished
            };

            return model;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Post([FromBody] BrandForm model)
        {
            var brand = new Brand
            {
                Name = model.Name,
                Slug = model.Slug,
                IsPublished = model.IsPublished
            };

            await _brandService.Create(brand);
            return CreatedAtAction(nameof(Get), new { id = brand.Id }, null);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Put(long id, [FromBody] BrandForm model)
        {
            var brand = _brandRepository.Query().FirstOrDefault(x => x.Id == id);
            if(brand == null)
            {
                return NotFound();
            }

            brand.Name = model.Name;
            brand.Slug = model.Slug;
            brand.IsPublished = model.IsPublished;

            await _brandService.Update(brand);
            return Accepted();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(long id)
        {
            var brand = _brandRepository.Query().FirstOrDefault(x => x.Id == id);
            if (brand == null)
            {
                return NotFound();
            }

            await _brandService.Delete(brand);
            return NoContent();
        }

        [HttpPost("GetBrandDetail/{id}/searchOption")]
       // [Authorize(Roles = "admin")]
        public  IActionResult GetBrandDetail(long id, SearchOption searchOption)
        {
            var brand = _brandRepository.Query().FirstOrDefault(x => x.Id == id);
            if (brand == null)
            {
                return Ok(new { statusCode = 400, data = "Doesn't contains the record" });
            }

            var model = new ProductsByBrand
            {
                BrandId = id,
                BrandName = brand.Name,
                BrandSlug = brand.Slug,
                CurrentSearchOption = searchOption,
                FilterOption = new FilterOption()
            };

            var query =  _productRepository.Query().Where(x => x.BrandId == id && x.IsPublished && x.IsVisibleIndividually);

            if (query.Count() == 0)
            {
                model.TotalProduct = 0;
                return Json(model);
            }
            if (searchOption.MinPrice.HasValue)
            {
                query = query.Where(x => x.Price >= searchOption.MinPrice.Value);
            }

            if (searchOption.MaxPrice.HasValue)
            {
                query = query.Where(x => x.Price <= searchOption.MaxPrice.Value);
            }

            var categories = searchOption.GetCategories().ToArray();
            if (categories.Any())
            {
                query = query.Where(x => x.Categories.Any(c => categories.Contains(c.Category.Slug)));
            }

            model.TotalProduct = query.Count();
            var currentPageNum = searchOption.Page <= 0 ? 1 : searchOption.Page;
            var offset = (_pageSize * currentPageNum) - _pageSize;
            while (currentPageNum > 1 && offset >= model.TotalProduct)
            {
                currentPageNum--;
                offset = (_pageSize * currentPageNum) - _pageSize;
            }

            query = ApplySort(searchOption, query);

            var products = query
                .Include(x => x.ThumbnailImage)
                .Skip(offset)
                .Take(_pageSize)
                .Select(x => ProductThumbnail.FromProduct(x))
                .ToList();

            foreach (var product in products)
            {
                product.Name = _contentLocalizationService.GetLocalizedProperty(nameof(Product), product.Id, nameof(product.Name), product.Name);
                product.ThumbnailUrl = _mediaService.GetThumbnailUrl(product.ThumbnailImage);
                product.CalculatedProductPrice = _productPricingService.CalculateProductPrice(product);
            }

            model.Products = products;
            model.CurrentSearchOption.PageSize = _pageSize;
            model.CurrentSearchOption.Page = currentPageNum;

            return Json(model);
        }

        private static IQueryable<Product> ApplySort(SearchOption searchOption, IQueryable<Product> query)
        {
            var sortBy = searchOption.Sort ?? string.Empty;
            switch (sortBy.ToLower())
            {
                case "price-desc":
                    query = query.OrderByDescending(x => x.Price);
                    break;
                default:
                    query = query.OrderBy(x => x.Price);
                    break;
            }

            return query;
        }
    }
}
