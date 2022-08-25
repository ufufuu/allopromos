using allopromo.Admin.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Admin.Models.BusinessLogic
{
    public class StoreManager
    {
        public bool ChangeStoreStatus(StoreDto store, StoreStatus status)
        {
            var order = GetStoreById(store);
            if (order == null)
                return false;
            else
            {
                store.storeStatus = status;
                return true;
            }
        }
        private string GetStoreById(StoreDto store)
        {
            return store.storeId;
        }
    }
}
