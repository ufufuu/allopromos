using allopromo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Core.Interfaces
{
    public interface ICatalogService
    {
        #region Store Categories
        Task<StoreCategory> CreateStoreCategory(StoreCategory storeCategory );
        #endregion
        Task<StoreCategory> GetStoreCategory(string name); 
        #region Product Categories
        void CreateProductCategory(ProductCategory productCategory);
        Task<ProductCategory> GetProductCategory(string Id);
        ProductCategory UpdateProductCategory(string Id);
        IEnumerable<ProductCategory> GetProducsEntities();
        ProductCategory DeleteProductCategory(ProductCategory productCategory);
        Task DeleteProductCategory(string categoryId);
        #endregion
    }
}
