using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using allopromo.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace allopromo.Core.Abstract
{
    public interface IStoreService
    {
        #region Events
        event StoreCreatedEventHandler StoreCreated;
        void OnStoreCreated();
        #endregion

        #region Public Methods - Get Objects
        Task<IEnumerable<StoreDto>> GetStores();
        Task<IEnumerable<StoreDto>> GetStores(string localizationId);
        Task<IEnumerable<StoreDto>> GetStores(string categoryId, string localizationId, string sortingOrder);
        #endregion

        #region Public Methods - Create Objects
        Task<StoreDto> CreateStore(StoreDto store, StoreCategoryDto category, UserDto user);
        Task<StoreDto> CreateStore(StoreDto store);
        Task<StoreDto> CreateStore(string storeDtoName);
        #endregion

        #region Public Methods - Update Objects
        public void UpdateStoreCategory(string Id, StoreCategoryDto categoryDto);
        Task<StoreCategoryDto> CreateStoreCategoryAsync(StoreCategoryDto storeCategoryName);
        #endregion

        #region Public Methods | Categories
        Task<IEnumerable<StoreDto>> GetStoresByCategoryIdAsync(int catId, int pageNumber, int offSet);
        Task<StoreDto> GetStoreByIdAsync(string storeId);
        Task <StoreCategoryDto> GetStoreCategoryByIdAsync(string catId);
        Task<IEnumerable<StoreCategoryDto>> GetStoreCategoriesAsync();

        //Task<StoreDto> GetStoresByLocationIdAsync();
        Task<StoreCategoryDto> GetStoreCategoriesAsyncById(string Id);
        #endregion

        #region Public Methods - Delete Objects
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
