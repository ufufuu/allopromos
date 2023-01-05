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
        
        Task<StoreDto> CreateStore(string storeDtoName);
        Task <IEnumerable<StoreDto>> GetStoresByCategoryIdAsync(int catId, int pageNumber, int offSet);
        Task<StoreDto> GetStoreByIdAsync(string storeId);

        void OnStoreCreated();
        
        Task<string> getImageInformationAsync();

        //void DeleteStoreCategory(StoreCategoryDto storeCategoryDto);
        //void DeleteStoreCategory(string categoryId);
        //Task<StoreCategoryDto> GetStoreCategoryAsyncById(string Id);
        //public void UpdateStoreCategory(string Id, StoreCategoryDto categoryDto);
        //Task<IEnumerable<StoreCategoryDto>> GetStoreCategoriesAsync();
        //Task <StoreCategoryDto> GetStoreCategoryByIdAsync(string catId);
        //Task<StoreCategoryDto> CreateStoreCategoryAsync(StoreCategoryDto storeCategoryName);

        //Action<bool> StoreCreatedDel;
        //public Func<bool, int> StoreCreatedDel2;
        //IEnumerable<StoreDto> GetStores(int page, int size);
        //Task<StoreDto> CreateStore(StoreDto store);


    }
}
