using allopromoDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Model.DTO
{
    // Using AutoMapper !?
    public class StoreDTO
    {
        public string storeId { get; set; }
        public string storeName { get; set; }
        public string storeDescription { get; set; }
        public StoreDTO()
        {
        }
        public StoreDTO(Store store)
        {
            new StoreDTO();
            storeId = store.storeId;
        }
    }
    public class StoreDTOConverter
    {
        public StoreDTO ConvertToStoreDTO(Store store)
        {
            StoreDTO storeDTO = new StoreDTO();
            storeDTO.storeId = store.storeId;
            storeDTO.storeName = store.storeName;
            storeDTO.storeDescription = store.storeName;
            return storeDTO;
        }
        public List<StoreDTO> ConvertToStoreDTO(List<Store> stores)
        {
            List<StoreDTO> dtoStores = new List<StoreDTO>();
            foreach(var store in stores)
            {
                dtoStores.Add(ConvertToStoreDTO(store));
            }
            return dtoStores;
        }
    }
}
// lundi 02 aout 11h30 ->
//2160 rue lavoisier - saintefioy- michel udon - bottewx de securite ----
//cours numero1 
//
//2
//mercredii 04 aout : @ 11h30
///
//360 $ chaque ---
// 10 blocs de 4 heures
//200 $ rabais ----3400$
// contenu formation::
// 1----ronde deseuite ----inspection de securite ---- camion dseul transmission ----
//2 -----remorque ---- sans remorque ----- 