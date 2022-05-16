using allopromo.Core.Abstract;
using allopromo.Core.Application;
using allopromo.Core.Application.Dto;
using allopromo.Core.Domain;
using allopromo.Core.Entities;
using allopromo.Core.Helpers.Convertors;
using allopromo.Services.Abstract;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
namespace allopromo.Core.Services
{
    public class ProductService :IProductService
    {
        private readonly IProductQuery _productQuery;
        private readonly ModelStateDictionary _modelStateDictionnary;
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository, 
            ModelStateDictionary modelStateDictonnary,
            IProductQuery productQuery)
        {
            _productRepository = productRepository;
            _productQuery = productQuery;
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
            if (productId != null)
                return new ProductConvertor().ConvertDto(
                    await _productQuery.GetProductAsync(productId));
            return null;
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
                    await _productQuery.GetProductsByStoreIdAsync(storeId);
            return null;
        }
        public Task<IEnumerable<ProductDto>> GetProductsByStore()
        {
            throw new System.NotImplementedException();
        }
        protected bool ValidateProduct()
        {
            return _modelStateDictionnary.IsValid;
        }
    }
}
/*
 * 
 * IDataErrorInfo c# - 
 */