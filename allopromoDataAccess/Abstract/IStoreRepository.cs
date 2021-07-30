using allopromoDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace allopromoDataAccess.Abstract
{
    public interface IStoreRepository
    {
        List<Store> GetAllStores();
        public Store GetStoreById(string storeId);
        public void Insert(Store store);
        public void Update(Store store);
        public void Delete(Store storeId);
        public void Save();
    }
}
