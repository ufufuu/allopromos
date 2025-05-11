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

            #region Create
        Task<StoreCategory> CreateStoreCategory(StoreCategory storeCategory );
            #endregion

            #region Read
        Task<StoreCategory> GetStoreCategory(string name);
        Task<IEnumerable<StoreCategory>> GetStoreCategories();
        #endregion
        #endregion

        #region Product Categories
        Task <IEnumerable<ProductCategory>> GetProductsCategorAsync();
        Task<bool> CreateProductCategory(ProductCategory productCategory);
        Task<ProductCategory> GetProductCategory(string Id);
        ProductCategory UpdateProductCategory(string Id);

        Task<Product> UpdateProductAsync(string Id, Object obj);

        ProductCategory DeleteProductCategory(ProductCategory productCategory);
        Task DeleteProductCategory(string categoryId);

        #endregion

        #region Vendors
        Task<IEnumerable<Vendor>> GetVendors();
        #endregion

        #region Products

        #region Create
        Task<Product> CreateProductAsync(Product product, string Name);
        Task<IEnumerable<Product>> GetProductsAsync();
        #endregion

        #region Read
        Task<IEnumerable<Product>> GetProductsByStore(string storeId);
        //Task<Product> GetProductByIdAsync(string productId);
        //Task<IEnumerable<Product>> GetProductsAync();
        Task<IEnumerable<Product>> GetProductsByCategoryId(string id);
        Task<IEnumerable<ProductCategory>> GetProductCategories();
            #endregion

            #region Delete
        Task<ProductCategory> Delete(object obj);
            #endregion

        #endregion
    }
}
