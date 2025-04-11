
using allopromo.Api.DTOs;
using allopromo.Core.Entities;
using allopromo.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

#nullable enable
namespace allopromo.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly
#nullable disable
    ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            this._categoryService = categoryService;
            this._mapper = mapper;
        }

        [HttpPost]
        public IActionResult PostCategory([FromBody] ProductCategoryDto productCategoryDto)
        {
            if (productCategoryDto == null)
                return (IActionResult)this.BadRequest();
            this._categoryService.CreateCategory(this._mapper.Map<ProductCategory>((object)productCategoryDto));
            return (IActionResult)this.Ok((object)productCategoryDto);
        }

        [HttpGet]
        [Authorize(Roles = "Administrators")]
        public IActionResult GetCategories()
        {
            IEnumerable<ProductCategory> entities = this._categoryService.GetEntities();
            return entities == null ? (IActionResult)this.NotFound() : (IActionResult)this.Ok((object)entities);
        }

        [HttpGet]
        [Route("[action]/{categoryId}")]
        [Authorize(Roles = "Administrators")]
        public IActionResult GetCategory(string categoryId)
        {
            ProductCategory category = this._categoryService.GetCategory(categoryId);
            return category == null ? (IActionResult)this.NotFound() : (IActionResult)this.Ok((object)category);
        }

        [HttpPut]
        [Authorize(Roles = "Administrators")]
        public IActionResult UpdateCategory(string categoryId, StoreCategoryDto categoryDto)
        {
            return (IActionResult)this.Ok((object)categoryDto);
        }

        [HttpDelete]
        [Authorize(Roles = "Administrators")]
        public IActionResult DeleteCategory(string Id)
        {
            this._categoryService.DeleteCategory(Id);
            return (IActionResult)this.Ok((object)Id);
        }

        [HttpPost]
        [Route("categories/create/")]
        public async Task<IActionResult> PostStoreCategory([FromBody] StoreCategoryDto storeCategoryDto)
        {
            CategoriesController categoriesController = this;
            if (storeCategoryDto == null)
                return (IActionResult)categoriesController.BadRequest();
            categoriesController._mapper.Map<StoreCategory>((object)storeCategoryDto);
            return (IActionResult)categoriesController.Ok((object)storeCategoryDto);
        }
    }
}
