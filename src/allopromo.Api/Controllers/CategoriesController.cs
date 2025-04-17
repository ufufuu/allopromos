
using allopromo.Api.DTOs;
using allopromo.Core.Entities;
using allopromo.Core.Interfaces;
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
        private readonly ICatalogService _catalogService;
        private readonly IMapper _mapper;
        public CategoriesController(ICatalogService catalogService, IMapper mapper)
        {
            this._catalogService = catalogService;
            this._mapper = mapper;
        }

        [HttpPost]
        public IActionResult PostCategory([FromBody] ProductCategoryDto productCategoryDto)
        {
            if (productCategoryDto == null)
                return (IActionResult)this.BadRequest();
            _catalogService.CreateProductCategory(_mapper.Map<ProductCategory>((object)productCategoryDto));
            return (IActionResult)this.Ok((object)productCategoryDto);
        }

        [HttpGet]
        [Authorize(Roles = "Administrators")]
        public IActionResult GetCategories()
        {
            return Ok();
        }

        [HttpGet]
        [Route("[action]/{categoryId}")]
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> GetCategory(string categoryId)
        {
            ProductCategory category = await _catalogService.GetProductCategory(categoryId);
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
            this._catalogService.DeleteProductCategory(Id);
            return (IActionResult)this.Ok((object)Id);
        }

        [HttpPost]
        [Route("categories/create/")]
        public async Task<IActionResult> PostStoreCategory([FromBody] StoreCategoryDto storeCategoryDto)
        {
            if (storeCategoryDto == null)
                return BadRequest();
            var category = _mapper.Map<StoreCategory>(storeCategoryDto);
            await _catalogService.CreateStoreCategory(category);
            return Ok(storeCategoryDto);
        }
    }
}
