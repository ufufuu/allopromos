using allopromo.Core.Abstract;
using allopromo.Core.Application;
using allopromo.Core.Application.Dto;
using allopromo.Core.Domain;
using allopromo.Core.Entities;
using allopromo.Services.Abstract;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Http.ModelBinding;
namespace allopromo.Core.Services
{
    public class ProductService :IProductService
    {
        #region Constructor & Properties
        private readonly IRepository<tProduct> _productRepository;
        public ProductService(IRepository<tProduct> productRepository)
        {
            _productRepository = productRepository;
            //_productQuery = productQuery;
        }
        #endregion
        #region GET

        public async Task<IEnumerable<ProductDto>> GetProductsByStore(string storeId)
        {
            var products = new List<ProductDto>();
            if (storeId != null)
            {
                var tObjProducts = (await _productRepository.GetAllAsync()).AsQueryable()//GetProductsByStoreIdAsync(storeId);//GetByIdAsync(storeId);
                                        .Include(c => c.ProductCategory)
                                        .Select(p => new ProductDto
                                        {
                                            productName = p.productName,
                                            productDescription = p.productDescription,
                                            productStatus = p.productStatus,
                                            productCategoryName= p.ProductCategory.productCategoryName
                                        });
                products = AutoMapper.Mapper.Map<List<ProductDto>>(tObjProducts);
            }
            return products;
        }
        public async Task<ProductDto> GetProductById(string productId)
        {
            if (productId == null)
                return null;
            return AutoMapper.Mapper.Map<tProduct, ProductDto>(
            await _productRepository.GetByIdAsync(productId));
        }
        public async Task<IEnumerable<ProductDto>> GetProductsByCategoryId(string id)
        {
            var products = Mapper.Map<IEnumerable<ProductDto>>(
                await _productRepository.//GetProductsByStoreIdAsync(id));
                GetByIdAsync(id));
            return products;
        }
        
        
        #endregion
        #region CREATE
        public async Task<ProductDto> CreateProductAsync(tProduct product)
        {
            ProductDto productDto = null;
            if (product != null)
            {
                //var tProduct2 = 
                await _productRepository.Add(product);
                ProductDto pod = AutoMapper.Mapper.Map<ProductDto>(product);
                productDto = AutoMapper.Mapper.Map<ProductDto>(product);
            }
            return productDto;
        }

        #endregion
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