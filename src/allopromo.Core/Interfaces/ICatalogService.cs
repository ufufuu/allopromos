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

        Task<Product> UpdateProductAsync(string Id, Object obj);


        //Task<IEnumerable<Product>> GetProductsAync();
        ProductCategory DeleteProductCategory(ProductCategory productCategory);
        Task DeleteProductCategory(string categoryId);
        #endregion

        #region Products
        
        Task<Product> CreateProductAsync(Product product, string Name);
        Task<IEnumerable<Product>> GetProductsByStore(string storeId);
        //Task<Product> GetProductByIdAsync(string productId);



        Task<IEnumerable<Product>> GetProductsByCategoryId(string id);
        Task<IEnumerable<ProductCategory>> GetProductCategories();
        Task<ProductCategory> Delete(object obj);
        #endregion
    }
}
