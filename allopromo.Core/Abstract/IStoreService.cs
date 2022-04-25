using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace allopromo.Core.Abstract
{
    public delegate bool StoreCreatedEventHandler(object source, EventArgs e);
    public interface IStoreService
    {
        public event StoreCreatedEventHandler storeCreated;
        StoreDto CreateStore(StoreDto store);
        Task <IEnumerable<StoreDto>> GetStoresByCategoryIdAsync(int catId, int pageNumber, int offSet);
        Task<StoreDto> GetStoreByIdAsync(string storeId);
        void OnStoreCreated();
        IEnumerable<StoreDto> GetStoreCategoriesAsync();
        tStoreCategory CreateStoreCategory(StoreCategoryDto store);


        //Action<bool> StoreCreatedDel;
        //public Func<bool, int> StoreCreatedDel2;
        //IEnumerable<StoreDto> GetStores(int page, int size);
        //public void DeleteStore(StoreDto store);
        //public void OnStoreCreated();
    }
}
