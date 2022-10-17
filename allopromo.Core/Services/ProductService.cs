using allopromo.Core.Abstract;
using allopromo.Core.Application;
using allopromo.Core.Application.Dto;
using allopromo.Core.Domain;
using allopromo.Core.Entities;
using allopromo.Services.Abstract;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
//using System.Web.Http.ModelBinding;
namespace allopromo.Core.Services
{
    public class ProductService :IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository
            )
        {
            _productRepository = productRepository;
            //_productQuery = productQuery;
        }
        public async Task<ProductDto> CreateAsync(tProduct product)
        {
            ProductDto productDto = null;
            if (product != null)
            {
                tProduct tProduct = await _productRepository.CreateAsync(product);
                ProductDto pod = Mapper.Map<ProductDto>(product);
                productDto = Mapper.Map<ProductDto>(tProduct);
            }
            return productDto;
        }
        public async Task<ProductDto> GetProductById(string productId)
        {
            if (productId == null)
                return null;
            return AutoMapper.Mapper.Map<tProduct, ProductDto>(
            await _productRepository.GetProductAsync(productId));
        }
        public async Task<IEnumerable<ProductDto>> GetProductsByCategoryId(string id)
        {
            var products = Mapper.Map<IEnumerable<ProductDto>>(
                await _productRepository.GetProductsByStoreIdAsync(id));
            return products;
        }
        public async Task<IEnumerable<ProductDto>> GetProductsByStore(string storeId)
        {
            if (storeId != null)
                return (IEnumerable<ProductDto>)
                    await _productRepository.GetProductsByStoreIdAsync(storeId);
            return null;
        }
        public Task<IEnumerable<ProductDto>> GetProductsByStore()
        {
            throw new System.NotImplementedException();
        }
        protected bool ValidateProduct()
        {
            // return _modelStateDictionnary.IsValid;
            return true;
        }
    }
}
/*  IDataErrorInfo c# -
 *  //ModelStateDictionary modelStateDictonnary,
    //IProductQuery productQuery
 */