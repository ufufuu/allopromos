using allopromo.Core.Abstract;
using allopromo.Core.Entities;
using allopromo.Core.Interfaces;
//using allopromo.Core.Abstract.Interfaces;
using allopromo.Core.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Core.Services
{
    public class CatalogService : ICatalogService
    {
        private IRepository<ProductCategory> _productCategoryRepository { get; set; }
        public CatalogService(IRepository<ProductCategory> productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        #region Stores Categories
        public StoreCategory GetStoreCategory()
        {
            return null;
        }
        #endregion

        #region Products Categories
        public void CreateProductCategory(ProductCategory tProductCategory)
        {
            _productCategoryRepository.Add(tProductCategory);
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

        #endregion
    }
}