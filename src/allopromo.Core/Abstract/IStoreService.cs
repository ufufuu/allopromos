using allopromo.Core.Entities;
using allopromo.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Core.Abstract
{
    //public delegate bool StoreCreatedEventHandler(object source, EventArgs e);

    public interface IStoreService
    {
        event Services.StoreCreatedEventHandler StoreCreated;
        //void OnStoreCreated();

        Task CreateStoreAsync(Store store, string userName); // UserDto user);

        Task CreateStore(string storeDtoName);
        Task CreateStoreCategoryAsync(StoreCategory storeCategoryName);


        Task<IEnumerable<Store>> GetStores();
        Task<IEnumerable<Store>> GetStores(string localizationId);
        Task<IEnumerable<Store>> GetStores(string categoryId, string localizationId, string sortingOrder);


        Task<IEnumerable<Store>> GetStoresByCategoryIdAsync(int catId, int pageNumber, int offSet);
        Task<Store> GetStoreByIdAsync(string storeId);
        Task<StoreCategory> GetStoreCategoryByIdAsync(string catId);
        Task<IEnumerable<StoreCategory>> GetStoreCategoriesAsync();


        //Task<StoreDto> GetStoresByLocationIdAsync();

        Task<StoreCategory> GetStoreCategoriesAsyncById(string Id);
        Task<IQueryable<Store>> GetStoresByUserName(string userName);
        

        public void UpdateStoreCategory(string Id, StoreCategory category);

        void DeleteStoreCategory(StoreCategory storeCategory);
        void DeleteStoreCategory(string categoryId);
        
        Task<string> getImageUrl();
        Task<string> getImageInformationAsync();
        
        //Action<bool> StoreCreatedDel;
        //public Func<bool, int> StoreCreatedDel2;
        //IEnumerable<StoreDto> GetStores(int page, int size);
    }
}
