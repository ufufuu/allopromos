using allopromoDataAccess.Abstract;
using allopromoDataAccess.Model;
using allopromoServiceLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
namespace allopromoServiceLayer.Model
{
    public class StoreService : IStoreService
    {
        // Repository Pattern ?
        public IStoreRepository _storeRepo { get; set; }
       
        public StoreService(IStoreRepository storeRepo)
        {
            _storeRepo = storeRepo;
        }
        public IEnumerable<Store> GetStores()
        {
            return _storeRepo.GetAllStores();
        }
        public Store GetStore(string storeId)
        {
            return _storeRepo.GetStoreById(storeId);
        }
        public void CreateStore(Store store)
        {
            _storeRepo.Insert(store);
        }
        public void DeleteStore(Store store)
        {
            _storeRepo.Delete(store);
        } 
    }
}
