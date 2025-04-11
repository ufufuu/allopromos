using allopromo.Core.Entities;
using allopromo.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Core.Abstract
{
    public interface IStoreService
    {
        Task<bool> CreateStoreAsync(Store store, string name, string city, string category);

        Task CreateStoreCategoryAsync(StoreCategory storeCategoryName);

        Task<IEnumerable<Store>> GetStoresAsync();

        Task<IEnumerable<Store>> GetStores(string localizationId);

        Task<IEnumerable<Store>> GetStores(
          string categoryId,
          string localizationId,
          string sortingOrder);

        Task<IEnumerable<Store>> GetStoresByCategoryNameAsync(
          string categoryName,
          int pageNumber,
          int offSet);

        Task<Store> GetStoreByIdAsync(string storeId);

        Task<StoreCategory> GetStoreCategoryByIdAsync(string catId);

        Task<IEnumerable<StoreCategory>> GetStoreCategoriesAsync();

        Task<StoreCategory> GetStoreCategoriesAsyncById(string Id);

        Task<IQueryable<Store>> GetStoresByUserName(string userName);

        Task<bool> UpdateStoreCategoryAsync(string Id, StoreCategory category);

        Task<bool> UpdateStoreAsync(string Id, Store category);

        void DeleteStoreCategory(StoreCategory storeCategory);

        void DeleteStoreCategory(string categoryId);

        event Services.StoreService.StoreCreatedEventHandler StoreCreated;

        Task<string> getImageUrl();

        Task<string> getImageInformationAsync();
    }
}
