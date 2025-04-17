using allopromo.Api.Commands.Model;
using allopromo.Api.DTOs;
using allopromo.Api.Queries.Models;
using allopromo.Api.Validators;
using allopromo.Core.Abstract;
using allopromo.Core.Domain;
using allopromo.Core.Entities;
using allopromo.Core.Interfaces;
using allopromo.Core.Model;
using allopromo.Core.Services;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace allopromo.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ICatalogService _catalogService { get; set; }
        private IUserService _userService { get; set; }
        private IStoreService _storeService { get; set; }
        private IMediaService _mediaService { get; set; }
        private IMediator _mediator { get; set; }
        private readonly IMapper _mapper;
        private IValidationService _validationService { get; set; }

        public ProductsController(
          ICatalogService catalogService,
          IUserService userService,
          IStoreService storeService,
          IMediaService mediaService,
          IValidationService validationService,
          IMapper mapper)
        {
            //_productService = productService;

            _userService = userService;
            _storeService = storeService;
            _mediaService = mediaService;
            _catalogService = catalogService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("create")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> PostProduct([FromForm] ProductDto dto)
        {
            if( ModelState.IsValid )
            {
                var product = _mapper.Map<Product>(dto);
                var category = (await _catalogService.GetProductCategories()).FirstOrDefault();
                var productPictures = ( await _mediaService.SaveImages(dto.productImages));

                var currentUserName = (await _userService.GetCurrentUser()).UserName;
                var store = (await _storeService.GetStoresByUserName(currentUserName))
                                .FirstOrDefault();
                product.ProductCategory = category;
                product.productDescription = dto.Description;
                product.productName = dto.Name;
                product.productStatus = (int)dto.productPrice;
                product.Store = store;
                product.productImages = productPictures;

                await _catalogService.CreateProductAsync(product, dto.categoryName);
                return Ok(dto);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("{storeName}")]
        public async Task<IActionResult> GetProducts(string storeName)
        {
            ProductsController productsController = this;

            var productsByStore = await _catalogService.GetProductsByStore(storeName.ToString());
            IEnumerable<ProductDto> productDtos = productsController._mapper.Map<IEnumerable<ProductDto>>(productsByStore);
            return (IActionResult)productsController.Ok((object)productDtos);
        }

        [Route("({key})/[action]")]
        [HttpPut]
        public async Task<IActionResult> UpdateProductPicture(string key, [FromBody] AisleDto productPictureDto)
        {
            ProductsController productsController = this;
            if (productPictureDto == null)
                return BadRequest();

            IMediator mediator1 = productsController._mediator;
            GetQuery<ProductDto> getQuery = new GetQuery<ProductDto>();
            getQuery.Id = key;
            CancellationToken cancellationToken1 = new CancellationToken();
            IQueryable<ProductDto> source = await ((ISender)mediator1).Send<IQueryable<ProductDto>>((IRequest<IQueryable<ProductDto>>)getQuery, cancellationToken1);
            if (!source.Any<ProductDto>())
                return (IActionResult)productsController.NotFound();
            if (productsController.ModelState.IsValid)
            {
                IMediator mediator2 = productsController._mediator;
                AddProductPictureCommand productPictureCommand = new AddProductPictureCommand();
                productPictureCommand.Product = source.FirstOrDefault<ProductDto>();
                CancellationToken cancellationToken2 = new CancellationToken();
                bool flag = await ((ISender)mediator2).Send<bool>((IRequest<bool>)productPictureCommand, cancellationToken2);
            }
            return (IActionResult)productsController.BadRequest(productsController.ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(string Id, [FromForm] ProductUpdateDto productToUpdate)
        {
            if (Id == null || productToUpdate == null)
                return BadRequest();

            var productById = (await _catalogService.GetProductsByStore(Id));
                                //.Where(x => x.productId.Equals(Id));
            if (productById == null)
               return NotFound(" product  with id " + Id + " Not Found");
            if (productToUpdate.productImages != null)
            {
                IList<IFormFile> productImages = productToUpdate.productImages;
                if ((productImages != null ? (productImages.FirstOrDefault().Length > 1048576L ? 1 : 0) : 0) != 0)
                      return BadRequest();  //StatusCode(400, (object)" File size shoud not exceed 1 MB");
                 string[] strArray = new string[3]
                 {
                     ".jpg",
                     ".jpeg",
                     ".png"
                 };
            }
                //_catalogService.UpdateProductAsync(productById);
                return Ok(productById);
        }

        [Route("id")]
        [HttpDelete]
        public async Task<IActionResult> Delete(string Id)
        {
            if (Id == null)
                return BadRequest();
                    
            var productToDelete = await _catalogService.GetProductsByStore(Id); 
                                          //.Where(x => x.productCategoryId.Equals(Id));
            if (productToDelete == null)
                    //return (IActionResult)productsController.StatusCode(404, (object)("product with " + Id + " Not Found "));
                return NoContent();
            await _catalogService.Delete(productToDelete);
            return BadRequest(); // StatusCode(500, (object)ex.Message);
        }

        /*
        private async Task<IActionResult> gr ([FromForm] MultipartFormDataContent formData)
        {
            return Ok(null);
        }*/

        private IActionResult gt([FromForm] IFormFile file)
        {
            if (file == null || file.Length <= 0L)
                return (IActionResult)this.BadRequest((object)" No FIle uploaded");
            string fileName = file.FileName;
            long length = file.Length;
            return (IActionResult)this.Ok((object)" file Uploaded");
        }
    }
}
