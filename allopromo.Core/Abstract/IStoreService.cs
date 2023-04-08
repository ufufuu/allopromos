using allopromo.Core.Application.Dto;
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
        event StoreCreatedEventHandler StoreCreated;
        void OnStoreCreated();
        #region Getting Objects
        
        #endregion

        #region Create
        Task<StoreDto> CreateStoreAsync(StoreDto store, string userName); // UserDto user);

        Task<StoreDto> CreateStore(StoreDto store);
        Task<StoreDto> CreateStore(string storeDtoName);
        Task<StoreCategoryDto> CreateStoreCategoryAsync(StoreCategoryDto storeCategoryName);

        #endregion

        #region Read
        
        Task<IEnumerable<StoreDto>> GetStores();
        Task<IEnumerable<StoreDto>> GetStores(string localizationId);
        Task<IEnumerable<StoreDto>> GetStores(string categoryId, string localizationId, string sortingOrder);

        Task<IEnumerable<StoreDto>> GetStoresByCategoryIdAsync(int catId, int pageNumber, int offSet);
        Task<StoreDto> GetStoreByIdAsync(string storeId);
        Task<StoreCategoryDto> GetStoreCategoryByIdAsync(string catId);
        Task<IEnumerable<StoreCategoryDto>> GetStoreCategoriesAsync();
        #endregion

        //Task<StoreDto> GetStoresByLocationIdAsync();

        Task<StoreCategoryDto> GetStoreCategoriesAsyncById(string Id);
        Task<IQueryable<tStore>> GetStoresByUserName(string userName);
        
        #region Update
        public void UpdateStoreCategory(string Id, StoreCategoryDto categoryDto);
        #endregion

        #region Delete
        void DeleteStoreCategory(StoreCategoryDto storeCategoryDto);
        void DeleteStoreCategory(string categoryId);

        #endregion

        #region Public Methods - Other
        Task<string> getImageUrl();
        Task<string> getImageInformationAsync();
        
        //Action<bool> StoreCreatedDel;
        //public Func<bool, int> StoreCreatedDel2;
        //IEnumerable<StoreDto> GetStores(int page, int size);

        #endregion
    }
}
