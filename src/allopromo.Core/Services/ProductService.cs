using allopromo.Core.Abstract;
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


        //public async Task CreateProductCategory(tProductCategory productCategoryDto)
        //{
        //    if(productCategoryDto != null)
        //    {
        //        var productCategory = AutoMapper.Mapper.Map<tProductCategory>(productCategoryDto);

        //        productCategory.productCategoryId = 1;//Guid.NewGuid().ToString(),
        //        productCategory.productCategoryName = productCategoryDto.productCategoryName;
        //        _productCategoryRepository.Add(productCategory);
        //        return await Task.FromResult(productCategoryDto);
        //    }
        //    throw new NullReferenceException();
        //}


        public async Task<tProduct> CreateProductAsync(tProduct productDto, string userName)
        {
            if (productDto != null)
            {
                userName = "";
                var productObj = AutoMapper.Mapper.Map<tProduct>(productDto);
                var storeObj = (_storeService.GetStoresByUserName("")).Result.FirstOrDefault();

                productObj.Store = storeObj;
                var category = await GetProductCategoryByName(productDto.productName);
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
                    throw ex;
                }
            }
            return productDto;
        }
        #endregion

        #region READ

        public async Task<IEnumerable<tProduct>> GetProductsByStore(string storeId)
        {
            var products = new List<tProduct>();
            if (storeId != null)
            {
                var tObjProducts = (await _productRepository.GetAllAsync()).AsQueryable()//GetProductsByStoreIdAsync(storeId);//GetByIdAsync(storeId);
                                        .Include(c => c.ProductCategory)
                                        .Select(p => new tProduct
                                        {
                                            productName = p.productName,
                                            productDescription = p.productDescription,
                                            //= p.ProductCategory.productCategoryName
                                        });
                products = AutoMapper.Mapper.Map<List<tProduct>>(tObjProducts);
            }
            return products;
        }
        //public async Task<ProductDto> GetProductById(string productId)
        //{
        //    if (productId == null)
        //        return null;
        //    return AutoMapper.Mapper.Map<tProduct, ProductDto>(
        //    await _productRepository.GetByIdAsync(productId));
        //}
        public async Task<tProduct> GetProductById(string productId)
        {
            if (productId == null)
                throw new NullReferenceException();

            //return AutoMapper.Mapper.Map<tProduct, ProductDto>(

            var product = await _productRepository.GetByIdAsync(productId);
            return product;
        }
        public async Task<IEnumerable<tProduct>> GetProductsByCategoryId(string id)
        {
            var products = Mapper.Map<IEnumerable<tProduct>>(
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
        public async Task<tProductCategory> Delete(int Id)
        {
            var productCategory = from q in await _productCategoryRepository.GetAllAsync()
                                  where q.productCategoryId.Equals(Id)
                                  select q;
            _productCategoryRepository.Delete(productCategory);
            return productCategory.FirstOrDefault();
        }
        #endregion

        #region Product Categories
        public async Task<IEnumerable<tProductCategory>> GetProductCategories()
        {
            var productCategories = await _productCategoryRepository.GetAllAsync();
            return AutoMapper.Mapper.Map<IList<tProductCategory>>(productCategories);
        }
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