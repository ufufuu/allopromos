using allopromo.Core.Abstract;
using allopromo.Core.Entities;
using allopromo.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private IRepository<ProductCategory> _productCategoryRepository { get; set; }

        public CategoryService( IRepository<ProductCategory> productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public void CreateCategory(ProductCategory tProductCategory)
        {
            _productCategoryRepository.Add(tProductCategory);
        }

        public async Task<ProductCategory> GetCategory(string Id)
        {
            return await _productCategoryRepository.GetByIdAsync(Id) ?? throw new Exception();
        }

        public ProductCategory UpdateCategory(string Id) => (ProductCategory)null;

        public IEnumerable<ProductCategory> GetEntities()
        {
            return (IEnumerable<ProductCategory>)_productCategoryRepository.GetAllAsync();
        }

        public async Task DeleteCategory(string categoryId)
        {
            var category = await _productCategoryRepository.GetByIdAsync(categoryId);
            if (category != null)
                _productCategoryRepository.Delete(category);

            /*_productCategoryRepository.Delete((await _productCategoryRepository.GetAllAsync())
                .AsEnumerable<ProductCategory>().AsQueryable<ProductCategory>()
                .Where<ProductCategory>((Expression<Func<ProductCategory, bool>>)(q => q.productCategoryId == int.Parse(categoryId))).FirstOrDefault<ProductCategory>());
            */
        }

        public ProductCategory DeleteCategory(ProductCategory productCategory)
        {
            throw new NotImplementedException();
        }

    }
}
