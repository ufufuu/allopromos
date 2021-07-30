using allopromoDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;
namespace allopromoServiceLayer.Abstract
{
    public interface IStoreService
    {
        IEnumerable<Store> GetStores();
        public Store GetStore(string storeId);
        void CreateStore(Store store);
        public void DeleteStore(Store store);
    }
}
