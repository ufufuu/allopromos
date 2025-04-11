using allopromo.Core.Abstract;
using allopromo.Core.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;
namespace allopromo.Core.Services
{
    public interface IProductCategoryService
    {
    }
    public class ProductCategoryService : IProductCategoryService
    {
    }
    public class ProductCategoryService<TEntity> //:BaseService <TEntity> where TEntity:class
    {
        private IRepository<allopromo.Core.Entities.ProductCategory> _productCategoryRepository { get; set; }
        public IEnumerable<TEntity> GetEntities()
        {
            return (IEnumerable<TEntity>)_productCategoryRepository.GetAllAsync();
        }
    }
}

