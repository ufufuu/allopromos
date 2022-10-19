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
        event StoreCreatedEventHandler StoreCreated;
        Task<StoreDto> CreateStore(StoreDto store, StoreCategoryDto category, UserDto user);
        Task<StoreDto> CreateStore(StoreDto store);
        Task <IEnumerable<StoreDto>> GetStoresByCategoryIdAsync(int catId, int pageNumber, int offSet);
        Task<StoreDto> GetStoreByIdAsync(string storeId);
        void OnStoreCreated();
        Task<IEnumerable<StoreCategoryDto>> GetStoreCategoriesAsync();
        Task<string> getImageInformationAsync();
        Task<StoreCategoryDto> CreateStoreCategoryAsync(StoreCategoryDto storeCategoryName);
        void DeleteStoreCategory(StoreCategoryDto storeCategoryDto);
        Task<string> getImageUrl();
        void DeleteStoreCategory(string categoryId);
        Task<StoreCategoryDto> GetStoreCategoriesAsyncById(string Id);

        //Action<bool> StoreCreatedDel;
        //public Func<bool, int> StoreCreatedDel2;
        //IEnumerable<StoreDto> GetStores(int page, int size);
        //public void DeleteStore(StoreDto store);
        //public void OnStoreCreated();

    }
}
