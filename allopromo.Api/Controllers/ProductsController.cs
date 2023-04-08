using allopromo.Core.Application.Dto;
using allopromo.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using allopromo.Core.Abstract;

namespace allopromo.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService { get; set; }
        public ProductsController(IProductService productService) 
        {
            _productService = productService;
        }
        [HttpPost]
        [Route("category/create")]
        public async Task<IActionResult> PostCategory([FromBody] ProductCategoryDto productCategoryDto)
        {
            await _productService.CreateProductCategory(productCategoryDto);
            return Ok(productCategoryDto);
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> PostProduct([FromBody] ProductDto productDto)
        {
            if (productDto != null)
            {
                await _productService.CreateProductAsync(productDto, "alistcom@free.fr");
                return Ok(productDto);
            }
            else
                return NoContent();
        }
        [HttpGet]
        public List<StoreDto> GetProducts()
        {
            return new List<StoreDto>();
        }
    }
}