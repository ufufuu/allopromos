using allopromo.Core.Abstract;
using allopromo.Core.Entities;
using allopromo.Core.Interfaces;
using allopromo.Core.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace allopromo.Core.Services
{
    public class CatalogService : ICatalogService
    {
        private IRepository<StoreCategory> _storeCategoryRepository { get; set; }
        private IRepository<ProductCategory> _productCategoryRepository { get; set; }
        private IRepository<Product> _productRepository { get; set; }
        private IStoreService _storeService { get; set; }
        private IUserService _userService {get; set;}
        public CatalogService(
            IRepository<StoreCategory> storeCategoryRepository,
            IRepository<ProductCategory> productCategoryRepository,
            IRepository<Product> productRepository,
            IStoreService storeService,
            IUserService userService
            )
        {
            _storeCategoryRepository = storeCategoryRepository;
            _productCategoryRepository = productCategoryRepository;
            _productRepository = productRepository;
            _storeService = storeService;
            _userService = userService;
        }
        #region Products
        public async Task<Product> CreateProductAsync(Product productDto, string userName)
        {
            if (productDto != null)
            {
                var currentUser = _userService.GetCurrentUser();
                var productObj = AutoMapper.Mapper.Map<Product>(productDto);
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

        /*public async Task<Product> GetProductByIdAsync(string productId)
        {
            if (productId == null)
                throw new NullReferenceException();

            //return AutoMapper.Mapper.Map<tProduct, ProductDto>(

            var product = await _productRepository.GetByIdAsync(productId);
            return product;
        }*/

        public async Task<IEnumerable<Product>> GetProductsByCategoryId(string Id)
        {
            var products = (await _productRepository.GetAllAsync())
                        .Where(x => x.ProductCategory.productCategoryId.Equals(Id));
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
            var productCategory = from q in await _productCategoryRepository.GetAllAsync()
                                  where q.productCategoryName == Name
                                  select q;
            return productCategory.FirstOrDefault();
        }

        #region UPDATE

        #endregion 

        #region DELETE PRODUCT
        public async Task<ProductCategory> Delete(object obj)
        {
            var Id = 4;
            var productCategory = from q in await _productCategoryRepository.GetAllAsync()
                                  where q.productCategoryId.Equals(Id)
                                  select q;
            _productCategoryRepository.Delete(productCategory);
            return productCategory.FirstOrDefault();
        }
        #endregion

        public async Task<IEnumerable<ProductCategory>> GetProductCategories()
        {
            var productCategories = await _productCategoryRepository.GetAllAsync();
            return AutoMapper.Mapper.Map<IList<ProductCategory>>(productCategories);
        }

        protected bool ValidateProduct()
        {
            // return _modelStateDictionnary.IsValid;
            return true;
        }
        #endregion
        #region Stores Categories
        public Task<StoreCategory> CreateStoreCategoryAsync(StoreCategory storeCategory)
        {
            _storeCategoryRepository.Add(storeCategory);
            _storeCategoryRepository.Save();
            return Task.FromResult(storeCategory);
        }

        public async Task<StoreCategory> GetStoreCategory( string name)
        {
            var category = (await _storeCategoryRepository.GetAllAsync())
                            .Where(x => x.storeCategoryName.Equals(name));
            return category.FirstOrDefault();
        }
        #endregion

        #region Products Categories
        public async Task<bool> CreateProductCategory(ProductCategory tProductCategory)
        {
            if(tProductCategory != null)
            {
                _productCategoryRepository.Add(tProductCategory);
                _productCategoryRepository.Save();
                return true;
            }
            throw new ArgumentException(" product Category");
        }

        public async Task<ProductCategory> GetProductCategory(string Id)
        {
            return await _productCategoryRepository.GetByIdAsync(Id) ?? throw new Exception();
        }

        public ProductCategory UpdateProductCategory(string Id) => (ProductCategory)null;

        public ProductCategory DeleteProductCategory() => (ProductCategory)null;

        public IEnumerable<ProductCategory> GetEntities()
        {
            return (IEnumerable<ProductCategory>)_productCategoryRepository.GetAllAsync();
        }

        public async Task DeleteProductCategory(string categoryId)
        {
            var category = await  _productCategoryRepository.GetByIdAsync(categoryId);
            if (category != null)
                _productCategoryRepository.Delete(category);

            /*_productCategoryRepository.Delete((await _productCategoryRepository.GetAllAsync())
                .AsEnumerable<ProductCategory>().AsQueryable<ProductCategory>()
                .Where<ProductCategory>((Expression<Func<ProductCategory, bool>>)(q => q.productCategoryId == int.Parse(categoryId))).FirstOrDefault<ProductCategory>());
            */
        }

        public ProductCategory DeleteProductCategory(ProductCategory productCategory)
        {
            throw new NotImplementedException();
        }
        /*
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }


        */
        /*public IEnumerable<ProductCategory> GetProductsCAsync()
        {
            throw new NotImplementedException();
        }*/

        public Task<StoreCategory> CreateStoreCategory(StoreCategory storeCategory)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> UpdateProductAsync (string Id, Object obj)
        {
            var product = await _productRepository.GetByIdAsync(Id);
            return product;
        }

        public Task<IEnumerable<ProductCategory>> GetProductsAync()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}