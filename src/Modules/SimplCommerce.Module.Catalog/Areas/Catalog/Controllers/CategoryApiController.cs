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
using SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Catalog.Services;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.Catalog.Areas.Catalog.Controllers
{
    [Area("Catalog")]
    [Authorize(Roles = "admin, vendor")]
    [Route("api/categories")]
    public class CategoryApiController : Controller
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<ProductCategory> _productCategoryRepository;
        private readonly ICategoryService _categoryService;
        private readonly IMediaService _mediaService;
        private int _pageSize;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Brand> _brandRepository;
        private readonly IProductPricingService _productPricingService;
        private readonly IContentLocalizationService _contentLocalizationService;

        public CategoryApiController(IRepository<Category> categoryRepository, IRepository<ProductCategory> productCategoryRepository, ICategoryService categoryService,
            IMediaService mediaService,
            IRepository<Product> productRepository,
            IRepository<Brand> brandRepository,
            IProductPricingService productPricingService,
            IContentLocalizationService contentLocalizationService,
            IConfiguration config)
        {
            _categoryRepository = categoryRepository;
            _productCategoryRepository = productCategoryRepository;
            _categoryService = categoryService;
            _mediaService = mediaService;
            _productRepository = productRepository;
            _mediaService = mediaService;
            _brandRepository = brandRepository;
            _productPricingService = productPricingService;
            _contentLocalizationService = contentLocalizationService;
            _pageSize = config.GetValue<int>("Catalog.ProductPageSize");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var gridData = await _categoryService.GetAll();
            return Json(gridData);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var category = await _categoryRepository.Query().Include(x => x.ThumbnailImage).FirstOrDefaultAsync(x => x.Id == id);
            var model = new CategoryForm
            {
                Id = category.Id,
                Name = category.Name,
                Slug = category.Slug,
                MetaTitle = category.MetaTitle,
                MetaKeywords = category.MetaKeywords,
                MetaDescription = category.MetaDescription,
                DisplayOrder = category.DisplayOrder,
                Description = category.Description,
                ParentId = category.ParentId,
                IncludeInMenu = category.IncludeInMenu,
                IsPublished = category.IsPublished,
                ThumbnailImageUrl = _mediaService.GetThumbnailUrl(category.ThumbnailImage),
            };

            return Json(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Post(CategoryForm model)
        {
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    Name = model.Name,
                    Slug = model.Slug,
                    MetaTitle = model.MetaTitle,
                    MetaKeywords = model.MetaKeywords,
                    MetaDescription = model.MetaDescription,
                    DisplayOrder = model.DisplayOrder,
                    Description = model.Description,
                    ParentId = model.ParentId,
                    IncludeInMenu = model.IncludeInMenu,
                    IsPublished = model.IsPublished
                };

                await SaveCategoryImage(category, model);
                await _categoryService.Create(category);
                return CreatedAtAction(nameof(Get), new { id = category.Id }, null);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Put(long id, CategoryForm model)
        {
            if (ModelState.IsValid)
            {
                var category = await _categoryRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
                if(category == null)
                {
                    return NotFound();
                }

                category.Name = model.Name;
                category.Slug = model.Slug;
                category.MetaTitle = model.MetaTitle;
                category.MetaKeywords = model.MetaKeywords;
                category.MetaDescription = model.MetaDescription;
                category.Description = model.Description;
                category.DisplayOrder = model.DisplayOrder;
                category.ParentId = model.ParentId;
                category.IncludeInMenu = model.IncludeInMenu;
                category.IsPublished = model.IsPublished;

                if (category.ParentId.HasValue && await HaveCircularNesting(category.Id, category.ParentId.Value))
                {
                    ModelState.AddModelError("ParentId", "Parent category cannot be itself children");
                    return BadRequest(ModelState);
                }

                await SaveCategoryImage(category, model);
                await _categoryService.Update(category);

                return Accepted();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(long id)
        {
            var category = _categoryRepository.Query().Include(x => x.Children).FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            if (category.Children.Any(x => !x.IsDeleted))
            {
                return BadRequest(new { Error = "Please make sure this category contains no children" });
            }

            await _categoryService.Delete(category);
            return NoContent();
        }

        [HttpPost("{id}/products")]
        public IActionResult GetProducts(long id, [FromBody] SmartTableParam param)
        {
            var query = _productCategoryRepository.Query().Include(x => x.Product)
                .Where(x => x.CategoryId == id && !x.Product.IsDeleted && x.Product.IsVisibleIndividually);

            if (param.Search.PredicateObject != null)
            {
                dynamic search = param.Search.PredicateObject;
                if (search.Name != null)
                {
                    string name = search.Name;
                    query = query.Where(x => x.Product.Name.Contains(name));
                }

                if (search.IsPublished != null)
                {
                    bool isPublished = search.IsPublished;
                    query = query.Where(x => x.Product.IsPublished == isPublished);
                }
            }

            var gridData = query.ToSmartTableResult(
                param,
                x => new
                {
                    Id = x.Id,
                    ProductName = x.Product.Name,
                    IsFeaturedProduct = x.IsFeaturedProduct,
                    DisplayOrder = x.DisplayOrder,
                    IsProductPublished = x.Product.IsPublished
                });

            return Json(gridData);
        }

        [HttpPut("update-product/{id}")]
        public async Task<IActionResult> UpdateProduct(long id, [FromBody] ProductCategoryForm model)
        {
            var productCategory = await _productCategoryRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if(productCategory == null)
            {
                return NotFound();
            }

            productCategory.IsFeaturedProduct = model.IsFeaturedProduct;
            productCategory.DisplayOrder = model.DisplayOrder;

            await _productCategoryRepository.SaveChangesAsync();
            return Accepted();
        }

        [HttpPost("GetCategoryDetail/{id}/searchOption")]
        public IActionResult GetCategoryDetail(long id, [FromBody] ViewModels.SearchOption searchOption)
        {
            var category = _categoryRepository.Query().FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return Ok(new { statusCode = 400, data = "Doesn't contains the record" });
            }

            var model = new ProductsByCategory
            {
                CategoryId = category.Id,
                ParentCategorId = category.ParentId,
                CategoryName = _contentLocalizationService.GetLocalizedProperty(category, nameof(category.Name), category.Name),
                CategorySlug = category.Slug,
                CategoryMetaTitle = category.MetaTitle,
                CategoryMetaKeywords = category.MetaKeywords,
                CategoryMetaDescription = category.MetaDescription,
                CurrentSearchOption = searchOption,
                FilterOption = new FilterOption()
            };

            var query = _productRepository
                .Query()
                .Where(x => x.Categories.Any(c => c.CategoryId == category.Id) && x.IsPublished && x.IsVisibleIndividually);

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

            var categories = searchOption.GetCategories();
            if (categories.Any())
            {
                query = query.Where(p => p.Categories.Select(c => c.CategoryId).Intersect(_categoryRepository.Query().Where(cat => categories.Contains(cat.Slug)).Select(c => c.Id)).Any());
            }

            var brands = searchOption.GetBrands().ToArray();
            if (brands.Any())
            {
                query = query.Where(x => x.BrandId != null && brands.Contains(x.Brand.Slug));
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

        private static IQueryable<Product> ApplySort(ViewModels.SearchOption searchOption, IQueryable<Product> query)
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

        private async Task SaveCategoryImage(Category category, CategoryForm model)
        {
            if (model.ThumbnailImage != null)
            {
                var fileName = await SaveFile(model.ThumbnailImage);
                if (category.ThumbnailImage != null)
                {
                    category.ThumbnailImage.FileName = fileName;
                }
                else
                {
                    category.ThumbnailImage = new Media { FileName = fileName };
                }
            }
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Value.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _mediaService.SaveMediaAsync(file.OpenReadStream(), fileName, file.ContentType);
            return fileName;
        }

        private async Task<bool> HaveCircularNesting(long childId, long parentId)
        {
            var category = await _categoryRepository.Query().FirstOrDefaultAsync(x => x.Id == parentId);
            var parentCategoryId = category.ParentId;
            while (parentCategoryId.HasValue)
            {
                if(parentCategoryId.Value == childId)
                {
                    return true;
                }

                var parentCategory = await _categoryRepository.Query().FirstAsync(x => x.Id == parentCategoryId);
                parentCategoryId = parentCategory.ParentId;
            }

            return false;
        }

    }
}
