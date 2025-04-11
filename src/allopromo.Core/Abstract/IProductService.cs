using allopromo.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace allopromo.Core.Abstract
{
    public interface IProductService
    {
        //Task CreateProductCategory(tProductCategory productCategory);

        #region Create
        Task<Product> CreateProductAsync(Product product, string Name);
        #endregion

        #region Read
        Task<IEnumerable<Product>> GetProductsByStore(string storeId);
        Task<Product> GetProductById(string productId);
        Task<IEnumerable<Product>> GetProductsByCategoryId(string id);
        Task<IEnumerable<ProductCategory>> GetProductCategories();
        #endregion

        #region Delete
        Task<ProductCategory> Delete(int Id);
        #endregion
    }
}
