
using allopromo.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using allopromo.Core.Abstract;
using allopromo.Core.Entities;
using allopromo.Api.Queries.Models;
using allopromo.Api.Commands.Model;
using allopromo.Core.Application.Dto;
using allopromo.Api.Validators;

namespace allopromo.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region Fields
        IProductService _productService { get; set; }
        private MediatR.IMediator _mediator { get; set; }

        private readonly IPermissionService _permissionService;
        private IRepository<tProduct> _prodRepository { get; set; }
        IValidationService _validationService { get; set; }
        private readonly AutoMapper.IMapper _mapper; 

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
        //public async Task<IActionResult> PostCategory([FromBody] ProductCategoryDto productCategoryDto)
        //{
        //    if (productCategoryDto == null)
        //        return BadRequest();
        //    await _productService.CreateProductCategory(productCategoryDto);

        //    //await _productRepository.Create()

        //    return Ok(productCategoryDto);
        //}

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> PostProduct([FromBody] ProductDto productDto)
        {
            if (await _permissionService.Authorize(allopromo.Core.Security.PermissionSystemName.ManageCountries))
            {
                return Forbid();
            }
            if (productDto != null)
            {
                await _productService.CreateProductAsync(
                    _mapper.Map<tProduct>(productDto), "alistcom@free.fr");
                return Ok(productDto);
            }
            else
            {
                return NoContent();
            }
        }

        [Route("({key})/[action]")]

        //[SwaggerOperation(summary: "Invoke action UpdateProductPicture", OperationId = "UpdateProductPicture")]

        [HttpPost]
        public async Task<IActionResult> UpdateProductPicture(string key,
            [FromBody] allopromo.Core.Application.Dto.AisleDto productPictureDto)
        {
            if (productPictureDto == null)
                return BadRequest();
            if (!await _permissionService.Authorize(allopromo.Core.Security.PermissionSystemName.ManageProducts))
                return Unauthorized();

            var product = await _mediator.Send(new GetQuery<ProductDto>(){Id = key });
            if (!product.Any())
                return NotFound();

            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new AddProductPictureCommand()
                {
                     Product = product.FirstOrDefault(),
                });
            }
            return BadRequest(ModelState);
        }
        [HttpGet]
        public List<StoreDto> GetProducts()
        {
            return new List<StoreDto>();
        }
        #endregion

        #region Product Categories
        [Route("api/v1/[Controller]/categories")]
        [HttpPost]
        public async Task<IActionResult> GetProductCategories()
        {
            if (ModelState.IsValid)
            {
                return Ok(await _productService.GetProductCategories());
            }
            else
            {
                return NotFound();
            }
        }
        #endregion
        [HttpDelete]
        
        public async Task<IActionResult> Delete(string Id)
        {

            return Ok ( await _productService.Delete(int.Parse(Id)));
        }
    }
}