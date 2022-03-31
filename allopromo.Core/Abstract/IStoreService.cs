using allopromo.Core.Application.Dto;
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
        IEnumerable<StoreDto> GetStoresByCatIdAsync(string catId);
        Task<StoreDto> GetStoreByIdAsync(string storeId);

        //Action<bool> StoreCreatedDel;
        //public Func<bool, int> StoreCreatedDel2;
        //IEnumerable<StoreDto> GetStores(int page, int size);
        //public void DeleteStore(StoreDto store);
        //public void OnStoreCreated();
    }
}
