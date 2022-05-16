using allopromo.Core.Abstract;
using allopromo.Core.Helpers.Convertors;
using System;
using System.Collections.Generic;
using allopromo.Core.Application;
using System.Threading.Tasks;
using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using System.Net.Http;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
using Microsoft.AspNetCore.Identity;
using allopromo.Core.Domain;
using AutoMapper;
using System.Linq;
namespace allopromo.Core.Model
{
    public delegate bool StoreCreatedEventHandler(object source, EventArgs e);
    public class StoreService : IStoreService
    {
        public event StoreCreatedEventHandler StoreCreated;
        public Action<string> _StoreCreated;
        public static int _storesNumber { get; set; }
        private IStoreQuery _storeQuery;
        private IProductService _productService;
        private IStoreRepository _storeRepository;
        IGenericRepository<tStore> _tGenericRepository;//= GenericRepositoryFactory.GetRepository();
        private UserService _userService { get; set; }

        //public StoreService(IGenericRepository<tStore> tGenericRepository, IStoreRepository storeRepository)
        //{
        //    _tGenericRepository = tGenericRepository;
        //    _storeRepository = storeRepository;
        //}
        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }
        public void OnStoreCreated()
        {
            if (StoreCreated != null)
            {
                StoreCreated(this, EventArgs.Empty);
            }
        }
        #region Stores
        public StoreDto CreateStore(StoreDto storeDto, StoreCategoryDto category, UserDto userDto)
        {
            var appUser = Mapper.Map<ApplicationUser>(userDto);
            var storesNumber = GetStoresProducts(appUser);
            if (storesNumber == 0)
                //throw "Argument Null Exception "; // Throw Customized StoreWithoutProductException !
                return null;

            var dateExpiring = DateTime.Now.AddMonths(6).Day.ToString("00");
            if (storeDto != null)
            {
                var tUser = Mapper.Map<ApplicationUser>(userDto);
                var t_store = TConvertor.ConvertToObj(storeDto);
                var tCategory = AutoMapper.Mapper.Map<tStoreCategory>(category);
                var store = Mapper.Map<tStore>(storeDto);
                var location = new tLocation();
                var city = new tCity { cityName = "kara" };

                store.Category = tCategory;
                store.user = tUser;
                store.City = city;

                //t_stre.user = new User { userId = Guid.NewGuid().ToString() };
                //_tGenericRepository.Add(t_stre);
                //_tGenericRepository.Save();

                _storeRepository.Add(store);
                _storeRepository.Save();
                OnStoreCreated();
                return (StoreDto)storeDto;
            }
            return null;
        }
        public async Task<IEnumerable<StoreDto>> GetStoresByCategoryIdAsync(int categoryId, int pageNumber, int offSet)
        {
            offSet = 10;
            if(categoryId.Equals(null))
               return null;
            else
            {
                var storesByCategory =  TConvertor.
                    ConverToListObj(await _storeRepository.GetStoresByCategoryIdAsync(categoryId, pageNumber, offSet));
                return (IEnumerable<StoreDto>)storesByCategory;
            }
        }
        public async Task<IEnumerable<StoreDto>> GetStoresByLocationAsync(int locationId, int page, int size)
        {
            if (locationId.Equals(null))
                return null;
            else
            {
                var storesByLocation = TConvertor.
                    ConverToListObj(await _tGenericRepository.GetAllAsync());
                return (IEnumerable<StoreDto>)storesByLocation;
            }
        }
        public async Task<StoreDto> GetStoreByIdAsync(string storeId)
        {
            if (storeId == null)
                return null;
            StoreCreatedEventHandler del = delegate
            {
                return true;
            };
            var tStore = await _storeQuery.GetStoreByIdAsync(storeId);
            var storeDto = new StoreConvertor().ConvertStore(tStore);
            if (storeDto == null)
                return null;
            return storeDto;
        }
        public void DeleteStore(StoreDto store)
        {
        }
        async Task<StoreDto> GetStoreBy(string storeId)
        {
            var stores = await _storeQuery.GetStoreByIdAsync(storeId);
            return new StoreConvertor().ConvertStore(stores);
        }
        public IEnumerable<StoreDto> GetStoreCategoriesAsync()
        {
            var storeCategories = _storeRepository.GetStoreCategoriesAsync();

            return (IEnumerable<StoreDto>)storeCategories;
        }
        private int GetStores(ApplicationUser user)
        {
            var Id = _userService.GetUserbyId(user.Id);
            var query = from q in _storeRepository.GetStoresAsync()
                        where q.user.Equals(user)
                        select q;
            int numberStores = query.Count();
            return numberStores;
        }
        #endregion Stores

        #region Products
        public async Task<IEnumerable<ProductDto>> GetProductsByStoresAndCategories(string storeId)
        {
            if (storeId == null)
                return null;
            return await _productService.GetProductsByStore(storeId);
        }
        #endregion Products
        private int GetStoresProducts(ApplicationUser user)
        {
            var productQuery = from q
                               in _productService.GetProductsByStore().Result
                               select q;
            return productQuery.Count();
        }

        #region  StoresCategories
        public tStoreCategory CreateStoreCategory(StoreCategoryDto storeCategory)
        {
            var dateExpiring = DateTime.Now.AddMonths(6).Day.ToString("00");
            var t_store = TConvertor.ConvertToObj(storeCategory);
            _storeRepository.AddCategory(t_store as tStoreCategory);
            return new tStoreCategory { storeCategoryId = 1, storeCategoryName = "rlelel" };
        }
        #endregion StoresCategories
        //IEnumerable<StoreDto> IStoreService.GetStoresByCatIdAsync(string catId)
        //{
        //    throw new NotImplementedException();
        //}
    }
    public class StoreLocator
    {
        HttpClient _httpClient { get; set; }
        public StoreLocator(HttpClient httpClient)
        {
            _httpClient = httpClient;      
        }
        public string GetLocation()
        {
            var location = getAddress(23.5270797, 77.2548046);
            return location.ToString();
        }
        private string ReturnGPSCoordinates()
        {
            var rootObjc= getAddress(23.5270797, 77.2548046);
            return ""; //rootObj.display_Name;
        }
        private static RootObject getAddress (double Longitude, double Latitude) // getAddress(23.5270797, 77.2548046);
        {
            //onst double longitude = Longitude;
            //const double latitude = Latitude;

            string pathUrl = " https://nominatim.openstreetmap.org/reverse?format=json&lat=30.4573699&lon=-97.8247654";
            const string  mapBox= " https://api.mapbox.com/geocoding/v5/{endpoint}/";
            const string reverseGeoCodingApiEndPoint = " http://nominatim.openstreetmap.org/reverse?format=json&lat= "; // + Latitude + "&lon=" + Longitude;

            HttpResponseMessage msg = new HttpResponseMessage();
            RootObject obj = null;
            using (var httpClient = new HttpClient())
            {
                //msg = await httpClient.GetFromJsonAsync(pathUrl);
            }
            using (var webClient = new WebClient())
            {
                var jsonData = webClient.DownloadData(reverseGeoCodingApiEndPoint);
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(RootObject));
                obj = (RootObject)ser.ReadObject(new MemoryStream(jsonData));
            }
                return obj;
        }
    }
    [DataContract]
    public class RootObject
    {
        [DataMember]
        public string place_id { get; set; }
        [DataMember]
        public string licence { get; set; }
        [DataMember]
        public string osm_type { get; set; }
        [DataMember]
        public string osm_id { get; set; }
        [DataMember]
        public string lat { get; set; }
        [DataMember]
        public string lon { get; set; }
        [DataMember]
        public string display_name { get; set; }
        [DataMember]
        public Address address { get; set; }
    }
    [DataContract]
    public class Address
    {
        [DataMember]
        public string road { get; set; }
        [DataMember]
        public string suburb { get; set; }
        [DataMember]
        public string city { get; set; }
        [DataMember]
        public string state_district { get; set; }
        [DataMember]
        public string state { get; set; }
        [DataMember]
        public string postcode { get; set; }
        [DataMember]
        public string country { get; set; }
        [DataMember]
        public string country_code { get; set; }
    }
    //public class OrderPlacedEventArgs : EventArgs
    //{
    //}

    ////return new StoreRepository().GetAllStores().AsEnumerable();//GetStoresCategories()
    //return _storeRepo.GetAllStores().AsEnumerable();//(page, size).AsEnnumerable();
}
/* 1. table jointure
 * 2. re architecture
 * 3. I QUery Patterns
 */

// ? Builder !

//public delegate bool StoreCreatedEventHandler(object source, EventArgs e);
//What are Service Layers in Practice anyway ?
//public UnitOfWork _unitOfWork { get; set; }
// IOC by DIP
//IGenericsRepository _repo = GenericRepositoryFactory.GetRepository();
/*
* MapBox token: pk.eyJ1IjoiYWxpd2l5YW8iLCJhIjoiY2twaXo5bnVvMHYzNTJucGUzbTE3NXRodSJ9.qGOJOXU4ys9x_LU9Arj_MA
*/
//https://api.mapbox.com/geocoding/v5/{endpoint}/{

//IQuery Pattern ?

/*
 * Latitude: 46.861114 / N 46° 51' 40.012''
Longitude: -71.268900 / W 71° 16' 8.04''
*/
/*
 * https://www.gps-coordinates.net/api
 * 
 */


