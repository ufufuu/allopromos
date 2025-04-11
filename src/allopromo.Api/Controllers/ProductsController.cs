// Decompiled with JetBrains decompiler
// Type: allopromo.Api.Controllers.ProductsController
// Assembly: allopromo.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9E70BF9-6813-49CA-B8B2-EE280C9B986F
// Assembly location: C:\Users\MonPC\Downloads\allopromo.Api.dll

using allopromo.Api.Commands.Model;
using allopromo.Api.DTOs;
using allopromo.Api.Queries.Models;
using allopromo.Api.Validators;
using allopromo.Core.Abstract;
using allopromo.Core.Domain;
using allopromo.Core.Entities;
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

#nullable enable
namespace allopromo.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IProductService _productService { get; set; }
        private IUserService _userService { get; set; }
        private IStoreService _storeService { get; set; }
        private IMediaService _mediaService { get; set; }

        private IMediator _mediator { get; set; }

        private IRepository<Product> _productRepo { get; set; }

        private IValidationService _validationService { get; set; }

        public ProductsController(
          IProductService productService,
          IUserService userService,
          
          IRepository<Product> productRepo,
          IStoreService storeService,
          IMediaService mediaService,
          IValidationService validationService,
          IMapper mapper)
        {
            _productService = productService;
            _userService = userService;
            _storeService = storeService;
            _mediaService = mediaService;
            
            _productRepo = productRepo;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("create")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> PostProduct([FromForm] ProductDto productDto)
        {
            ProductsController productsController = this;
            return !productsController.ModelState.IsValid ? (IActionResult)productsController.StatusCode(500, (object)"") : (IActionResult)productsController.Ok((object)"Ok");
        }

        [HttpPut]
        [Route("{storeName}")]
        public async Task<IActionResult> GetProducts(string storeName)
        {
            ProductsController productsController = this;

            var productsByStore = await _productService.GetProductsByStore(storeName.ToString());

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
            ProductsController productsController = this;
            try
            {
                Product byIdAsync = await productsController._productRepo.GetByIdAsync(Id);
                if (byIdAsync == null)
                    return (IActionResult)productsController.StatusCode(404, (object)(" product  with id " + Id + " Not Found"));
                if (productToUpdate.productImages != null)
                {
                    IFormFile productImageFiles = productToUpdate.productImageFiles;
                    if ((productImageFiles != null ? (productImageFiles.Length > 1048576L ? 1 : 0) : 0) != 0)
                        return (IActionResult)productsController.StatusCode(400, (object)" File size shoud not exceed 1 MB");
                    string[] strArray = new string[3]
                    {
            ".jpg",
            ".jpeg",
            ".png"
                    };
                }
                productsController._productRepo.Update(byIdAsync);
                return (IActionResult)productsController.Ok((object)byIdAsync);
            }
            catch (Exception ex)
            {
                return (IActionResult)productsController.StatusCode(500, (object)ex.Message);
            }
        }

        [Route("id")]
        [HttpDelete]
        public async Task<IActionResult> Delete(string Id)
        {
            ProductsController productsController = this;
            try
            {
                Product byIdAsync = await productsController._productRepo.GetByIdAsync(Id);
                if (byIdAsync == null)
                    return (IActionResult)productsController.StatusCode(404, (object)("product with " + Id + " Not Found "));
                productsController._productRepo.Delete(byIdAsync);
                return (IActionResult)productsController.NoContent();
            }
            catch (Exception ex)
            {
                return (IActionResult)productsController.StatusCode(500, (object)ex.Message);
            }
        }

        private async Task<IActionResult> gr([FromForm] MultipartFormDataContent formData)
        {
            return (IActionResult)null;
        }

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
