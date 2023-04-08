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
        #region Properties
        private readonly IRepository<tProduct> _productRepository;
        private readonly IRepository<tProductCategory> _productCategoryRepository;
        public allopromo.Core.Logic.LogiqueCatalogProduits logiqueCatalogueProduit { get; set; }
        public  allopromo.Core.Abstract.IStoreService _storeService { get; set; }
        #endregion

        #region Fields

        #endregion

        #region Constructors
        
        public ProductService(IRepository<tProduct> productRepository, IRepository<tProductCategory> productCategoryRepository, 
            IStoreService storeService)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _storeService = storeService;
        }
        #endregion

        #region CREATE

        public async Task<ProductCategoryDto> CreateProductCategory(ProductCategoryDto productCategoryDto)
        {
            if(productCategoryDto != null)
            {
                var productCategory = AutoMapper.Mapper.Map<tProductCategory>(productCategoryDto);
                productCategory.productCategoryId = 1;//Guid.NewGuid().ToString(),
                productCategory.productCategoryName = productCategoryDto.categoryName;
                _productCategoryRepository.Add(productCategory);
                return await Task.FromResult(productCategoryDto);
            }
            throw new Exception();
        }
        public async Task<ProductDto> CreateProductAsync(ProductDto productDto, string userName)
        {
            if (productDto != null)
            {
                userName = "alistcom@free.fr";
                var productObj = AutoMapper.Mapper.Map<tProduct>(productDto);
                var storeObj = (_storeService.GetStoresByUserName("alistcom@free.fr")).Result.FirstOrDefault();

                productObj.Store = storeObj;
                var category = await GetProductCategoryByName(productDto.productCategoryName);
                productObj.ProductCategory = category;

                productObj.productId = Guid.NewGuid().ToString();
                productObj.productName = productDto.productName;
                productObj.Store = storeObj;
                try
                {
                    _productRepository.Add(productObj);
                    _productRepository.Save();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return productDto;
        }
        #endregion

        #region READ

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
        private async Task<tProduct> GetProductByName(string Name)
        {
            var product = from q in await _productRepository.GetEntitiesAsync()
                          where q.productName == Name
                          select q;
            return product.FirstOrDefault();
        }
        private async Task<tProductCategory> GetProductCategoryByName(string Name)
        {
            var productCategory = from q in await _productCategoryRepository.GetEntitiesAsync()
                          where q.productCategoryName == Name
                          select q;
            return productCategory.FirstOrDefault();
        }
        #endregion

        #region UPDATE

        #endregion

        #region DELETE

        #endregion

        #region Autres Methodes - Validation
        protected bool ValidateProduct()
        {
            // return _modelStateDictionnary.IsValid;
            return true;
        }
        #endregion
    }
}
/*  IDataErrorInfo c# -
 *  //ModelStateDictionary modelStateDictonnary,
    //IProductQuery productQuery
 */