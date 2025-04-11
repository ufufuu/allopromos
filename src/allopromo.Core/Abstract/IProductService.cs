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
        Task<tProduct> CreateProductAsync(tProduct product, string Name);
        #endregion

        #region Read
        Task<IEnumerable<tProduct>> GetProductsByStore(string storeId);
        Task<tProduct> GetProductById(string productId);
        Task<IEnumerable<tProduct>> GetProductsByCategoryId(string id);
        Task<IEnumerable<tProductCategory>> GetProductCategories();
        #endregion

        #region Delete
        Task<tProductCategory> Delete(int Id);
        #endregion
    }
}
