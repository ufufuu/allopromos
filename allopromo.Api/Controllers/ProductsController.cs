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
        #region Fields
        IProductService _productService { get; set; }

        //private allopromo.Infrastructure.Repositories.TRepository<ProductDto> _prodRepo{ get; set; }

        private IRepository<ProductDto> _prodRepository { get; set; }

        Validators.IValidationService _validationService { get; set; }

        #endregion

        #region constructors
    
        public ProductsController(IProductService productService) 
        {
            _productService = productService;
        }
        #endregion

        #region Public Methods
        [HttpPost("create-product")]
        //[Route("category/create")]
        public async Task<IActionResult> PostCategory([FromBody] ProductCategoryDto productCategoryDto)
        {

            //validationService.Validate<ProductDto>();

            await _productService.CreateProductCategory(productCategoryDto);

            //await _productRepository.Create()


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
        #endregion
    }
}