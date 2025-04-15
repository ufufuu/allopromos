using allopromo.Core.Abstract;
using allopromo.Core.Entities;
using allopromo.Core.Interfaces;
using allopromo.Core.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace allopromo.Core.Services
{
    public class CatalogService : ICatalogService
    {
        private IRepository<StoreCategory> _storeCategoryRepository { get; set; }
        private IRepository<ProductCategory> _productCategoryRepository { get; set; }
        public CatalogService(IRepository<ProductCategory> productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
            
        }

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
        public void CreateProductCategory(ProductCategory tProductCategory)
        {
            _productCategoryRepository.Add(tProductCategory);
            _productCategoryRepository.Save();
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

        public IEnumerable<ProductCategory> GetProducsEntities()
        {
            throw new NotImplementedException();
        }

        public Task<StoreCategory> CreateStoreCategory(StoreCategory storeCategory)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}