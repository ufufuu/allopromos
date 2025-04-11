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
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductCategory> _productCategoryRepository;
        public allopromo.Core.Logic.LogiqueCatalogProduits logiqueCatalogueProduit { get; set; }
        public  allopromo.Core.Abstract.IStoreService _storeService { get; set; }
        #endregion

        #region Fields

        #endregion

        #region Constructors
        
        public ProductService(IRepository<Product> productRepository, IRepository<ProductCategory> productCategoryRepository, 
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


        public async Task<Product> CreateProductAsync(Product productDto, string userName)
        {
            if (productDto != null)
            {
                userName = "";
                var productObj = AutoMapper.Mapper.Map<Product>(productDto);
                var storeObj = (_storeService.GetStoresByUserName("")).Result.FirstOrDefault();

                productObj.store = storeObj;
                var category = await GetProductCategoryByName(productDto.productName);
                productObj.ProductCategory = category;

                productObj.productId = Guid.NewGuid().ToString();
                productObj.productName = productDto.productName;
                productObj.store = storeObj;
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

        public async Task<IEnumerable<Product>> GetProductsByStore(string storeId)
        {
            var products = new List<Product>();
            if (storeId != null)
            {
                var tObjProducts = (await _productRepository.GetAllAsync()).AsQueryable()//GetProductsByStoreIdAsync(storeId);//GetByIdAsync(storeId);
                                        .Include(c => c.ProductCategory)
                                        .Select(p => new Product
                                        {
                                            productName = p.productName,
                                            productDescription = p.productDescription,
                                            //= p.ProductCategory.productCategoryName
                                        });
                products = AutoMapper.Mapper.Map<List<Product>>(tObjProducts);
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
        public async Task<Product> GetProductById(string productId)
        {
            if (productId == null)
                throw new NullReferenceException();

            //return AutoMapper.Mapper.Map<tProduct, ProductDto>(

            var product = await _productRepository.GetByIdAsync(productId);
            return product;
        }
        public async Task<IEnumerable<Product>> GetProductsByCategoryId(string id)
        {
            var products = Mapper.Map<IEnumerable<Product>>(
                await _productRepository.//GetProductsByStoreIdAsync(id));
                GetByIdAsync(id));
            return products;
        }
        private async Task<Product> GetProductByName(string Name)
        {
            var product = from q in await _productRepository.GetEntitiesAsync()
                          where q.productName == Name
                          select q;
            return product.FirstOrDefault();
        }
        private async Task<ProductCategory> GetProductCategoryByName(string Name)
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
        public async Task<ProductCategory> Delete(int Id)
        {
            var productCategory = from q in await _productCategoryRepository.GetAllAsync()
                                  where q.productCategoryId.Equals(Id)
                                  select q;
            _productCategoryRepository.Delete(productCategory);
            return productCategory.FirstOrDefault();
        }
        #endregion

        #region Product Categories
        public async Task<IEnumerable<ProductCategory>> GetProductCategories()
        {
            var productCategories = await _productCategoryRepository.GetAllAsync();
            return AutoMapper.Mapper.Map<IList<ProductCategory>>(productCategories);
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