using allopromo.Core.Entities;
using allopromo.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using allopromo.Core.Application.Dto;

namespace allopromo.Core.Abstract
{
    //public delegate bool StoreCreatedEventHandler(object source, EventArgs e);

    public interface IStoreService
    {
        event Services.StoreCreatedEventHandler StoreCreated;
        //void OnStoreCreated();

        Task CreateStoreAsync(tStore store, string userName); // UserDto user);

        Task CreateStore(string storeDtoName);
        Task CreateStoreCategoryAsync(tStoreCategory storeCategoryName);


        Task<IEnumerable<tStore>> GetStores();
        Task<IEnumerable<tStore>> GetStores(string localizationId);
        Task<IEnumerable<tStore>> GetStores(string categoryId, string localizationId, string sortingOrder);


        Task<IEnumerable<StoreDto>> GetStoresByCategoryIdAsync(int catId, int pageNumber, int offSet);
        Task<tStore> GetStoreByIdAsync(string storeId);
        Task<tStoreCategory> GetStoreCategoryByIdAsync(string catId);
        Task<IEnumerable<tStoreCategory>> GetStoreCategoriesAsync();


        //Task<StoreDto> GetStoresByLocationIdAsync();

        Task<tStoreCategory> GetStoreCategoriesAsyncById(string Id);
        Task<IQueryable<tStore>> GetStoresByUserName(string userName);
        

        public void UpdateStoreCategory(string Id, StoreCategoryDto category);

        void DeleteStoreCategory(tStoreCategory storeCategory);
        void DeleteStoreCategory(string categoryId);
        
        Task<string> getImageUrl();
        Task<string> getImageInformationAsync();
        
        //Action<bool> StoreCreatedDel;
        //public Func<bool, int> StoreCreatedDel2;
        //IEnumerable<StoreDto> GetStores(int page, int size);
    }
}
