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
        StoreDto CreateStore(StoreDto store, StoreCategoryDto category, UserDto user);
        Task<StoreDto> CreateStore(StoreDto store);  //, StoreCategoryDto category, UserDto user);
        Task <IEnumerable<StoreDto>> GetStoresByCategoryIdAsync(int catId, int pageNumber, int offSet);
        Task<StoreDto> GetStoreByIdAsync(string storeId);
        void OnStoreCreated();
        Task<IEnumerable<StoreCategoryDto>> GetStoreCategoriesAsync();
        tStoreCategory CreateStoreCategory(string storeCategoryName);
        void DeleteStoreCategory(StoreCategoryDto storeCategoryDto);

        //Action<bool> StoreCreatedDel;
        //public Func<bool, int> StoreCreatedDel2;
        //IEnumerable<StoreDto> GetStores(int page, int size);
        //public void DeleteStore(StoreDto store);
        //public void OnStoreCreated();
    }
}
