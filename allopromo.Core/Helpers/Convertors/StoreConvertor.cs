using allopromo.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
namespace allopromo.Core.Helpers.Convertors
{
    // when Do We need static Classes ? along with their Methods ?
    public class StoreConvertor
    {
        public tStore Convert(StoreDto store)
        {
            tStore obj = new tStore();
            obj.storeId = store.storeId;
            return obj;
        }
        public StoreDto ConvertStore(tStore tstore)
        {
            if (tstore == null)
                return null;
            var roleObj = new StoreDto { };
            //roleObj = (object)tstore as StoreDto;
            roleObj.storeId= tstore.storeId;
            roleObj.storeName = tstore.storeName;
            //roleObj.storeName= tstore.so
            return roleObj;
        }
        public List<StoreDto> ConvertStores(List<tStore> tstores)
        {
            var listObj = new List<StoreDto>();
            foreach(var t_store in tstores)
            {
                var store = new tStore();
                store.storeId = t_store.storeId.ToString();

                //listObj.Add(store);
            }
            return listObj;
        }
    }
    //public class StoreDTOConverter
    //{
    //    public StoreDTO ConvertToStoreDTO(Store store)
    //    {
    //        StoreDTO storeDTO = new StoreDTO();
    //        storeDTO.storeId = store.storeId;
    //        storeDTO.storeName = store.storeName;
    //        storeDTO.storeDescription = store.storeName;
    //        return storeDTO;
    //    }
    //    public List<StoreDTO> ConvertToStoreDTO(List<Store> stores)
    //    {
    //        List<StoreDTO> dtoStores = new List<StoreDTO>();
    //        foreach (var store in stores)
    //        {
    //            dtoStores.Add(ConvertToStoreDTO(store));
    //        }
    //        return dtoStores;
    //    }
    //}
}