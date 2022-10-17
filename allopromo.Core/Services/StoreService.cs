using allopromo.Core.Abstract;
using System;
using System.Collections.Generic;
using allopromo.Core.Application;
using System.Threading.Tasks;
using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using System.Net.Http;
using Microsoft.AspNetCore.Identity;
using allopromo.Core.Domain;
using AutoMapper;
using System.Linq;
using allopromo.Core.Services;
using System.Text;
using Newtonsoft.Json;
using System.IO;
namespace allopromo.Core.Model
{
    public delegate bool StoreCreatedEventHandler(object source, EventArgs e);
    public class StoreService : IStoreService
    {
        public event StoreCreatedEventHandler StoreCreated;
        public Action<string> _StoreCreated;
        public static int _storesNumber { get; set; }
        private IProductService _productService { get; set; }


        private IRepository<tStore> _storeRepository;


        allopromo.Shared.Abstract.IRepository<tStore> storeRepository;

        private IRepository<tStore> _tGenericRepository { get; set; }
        private UserService _userService { get; set; }
        public HttpClient _httpClient { get; set; }//https://cdn.pixabay.com/photo/2013/10/15/09/12/flower-195893_150.jpg
        public string Url = "https://pixabay.com/api/?key=30135386-22f4f69d3b7c4b13c6e111db7&id=195893";
        public StoreService(IRepository<tStore> storeRepository)
        {
            _storeRepository = storeRepository;
        }
        public StoreService(allopromo.Shared.Abstract.IRepository<tStore> storeRepo)
        {
            storeRepository = storeRepo;
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

                var tCategory = AutoMapper.Mapper.Map<tStoreCategory>(category);
                var store = Mapper.Map<tStore>(storeDto);
                var location = new tLocation();
                var city = new tCity { cityName = "kara" };
                store.Category = tCategory;
                store.user = tUser;
                store.City = city;
                _storeRepository.Add(store);
                _storeRepository.Save();
                _tGenericRepository.Save();
                OnStoreCreated();
                return (StoreDto)storeDto;
            }
            return null;
        }
        public async Task<IEnumerable<StoreDto>> GetStoresByCategoryIdAsync(int categoryId,
            int pageNumber, int offSet)
        {
            offSet = 10;
            if (categoryId.Equals(null))
                return null;
            else
            {
                var storesByCategory = await _storeRepository.GetByIdAsync(categoryId,
                    pageNumber, offSet);

                //return (IEnumerable<StoreDto>)storesByCategory;
            }
            return null;
        }
        public async Task<IEnumerable<StoreDto>> GetStoresByLocationAsync(int locationId, int page, int size)
        {
            if (locationId.Equals(null))
                return null;
            else
            {
                var storesByLocation = 
                await _tGenericRepository.GetAllAsync();

                //return (IEnumerable<StoreDto>)storesByLocation;
            }
            return null;
        }
        public async Task<StoreDto> GetStoreByIdAsync(string storeId)
        {
            if (storeId == null)
                return null;
            StoreCreatedEventHandler del = delegate
            {
                return true;
            };
            var tStore =await _storeRepository.GetByIdAsync(storeId);
            return AutoMapper.Mapper.Map<StoreDto>(tStore);
        }
        public void DeleteStore(StoreDto store)
        {
            storeRepository.Delete(store);
        }
        public async Task<IEnumerable<StoreCategoryDto>> GetStoreCategoriesAsync()
        {
            var categories = Mapper.Map<IEnumerable<StoreCategoryDto>>
                (await _storeRepository.GetAllAsync());
            return categories;
        }
        public async Task<StoreCategoryDto> GetStoreCategoriesAsyncById(string Id)
        {
            var categories = await this.GetStoreCategoriesAsync();
            var query = from q in categories
                        where q.storeCategoryId == Id
                        select q;
            return query.FirstOrDefault();
        }
        private async Task<int> GetStoresAsync(ApplicationUser user)
        {
            var Id = _userService.GetUserbyId(user.Id);
            var query = from q in await _storeRepository.GetAllAsync()
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
        #region StoresCategories
        public async Task<StoreCategoryDto> CreateStoreCategoryAsync(StoreCategoryDto storeCategory)
        {
            if (storeCategory == null)
                return null;
            var dateExpiring = DateTime.Now.AddMonths(6).Day.ToString("00");
            var storeCategoryDto = new StoreCategoryDto();
            var tStoreCategory = new tStoreCategory();
            tStoreCategory.storeCategoryName = storeCategory.storeCategoryName;
            tStoreCategory.storeCategoryId = new Guid();
            tStoreCategory.storeCategoryImageUrl = storeCategory.storeCategoryImageUrl;
            var imageUrl = string.Empty;
            if (postStoreCategoryImage() != null)
                imageUrl = await this.getImageUrl();
            else
                imageUrl = "http://www.noiamgesfornow.jpg";
            tStoreCategory.storeCategoryImageUrl = imageUrl;
            _storeRepository.Add(tStoreCategory.storeCategoryName, imageUrl);
            return storeCategoryDto;
        }
        public Task<StoreDto> CreateStore(StoreDto store)
        {
            throw new NotImplementedException();
        }
        #endregion StoresCategories
        public void DeleteStoreCategory(string categoryId)
        {

        }
        public void DeleteStoreCategory(StoreCategoryDto storeCategoryDto)
        {
            if (storeCategoryDto == null)
            {
                var storeCategory = AutoMapper.Mapper.Map<tStoreCategory>(storeCategoryDto);

               // _storeRepository.DeleteStoreCategory(storeCategory);


                var category = storeRepository.GetByIdAsync("kjkjk");
                if (storeCategory == null)
                {
                    throw new NullReferenceException();
                }
                else
                {
                    storeRepository.Delete(storeCategory);
                }
            }
        }
        public async Task<string> getImageInformationAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var imageInformationUlr = new Uri("https://pixabay.com/api/?key=30135386-22f4f69d3b7c4b13c6e111db7&id=195893");
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, imageInformationUlr);
                var httpResponseMsg = await httpClient.SendAsync(httpRequest);
                var content = await httpResponseMsg.Content.ReadAsStringAsync();       //httpResponseMsg
                var response = Newtonsoft.Json.JsonConvert.SerializeObject(httpResponseMsg);
                var image = (string)response;
            }
            var data = new metaData { Id = "1232", Url = "https//allo.promo/images/92bw23fhj.jpg" };
            var res = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return res;
        }
        private async Task<string> postStoreCategoryImage()
        {
            string response = string.Empty;
            var jsonObj = "{" +
                " \"data\": {" +
                " \"id\": \"soLHmGdX\", " +
                " \"url\": \"https://thumbsnap.com/soLHmGdX\", " +
                " \"media\": \"https://thumbsnap.com/i/soLHmGdX.png\", " +
                " \"thumb\": \"https://thumbsnap.com/t/soLHmGdX.jpg\", " +
                " \"width\": 224, " +
                " \"height\": 224 " +
                "}," +
                " \"success\": true, " +
                "  \"status\": 200 " +
            " }";
            //var jsonData = JObject.Parse(jsonObj);
            string imageUrl = string.Empty;
            using (var httpClient = new HttpClient())
            {
                var Url = new Uri
                    ("https://thumbsnap.com/api/upload");
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, Url);
                //var content = new HttpMessageContent(httpRequest);
                var result = await httpClient.PostAsync("https://thumbsnap.com/api/upload", null);//, content);
                if (result.IsSuccessStatusCode)
                {
                    response = result.StatusCode.ToString();
                    var obj = JsonConvert.DeserializeObject<ThumbyModel>(jsonObj);
                    MediaApiResponseModel dataObj = obj.data;
                    var image = JsonConvert.SerializeObject(dataObj);

                    var media = JsonConvert.DeserializeObject<MediaApiResponseModel>(image);
                    imageUrl = media.url;
                }
            }
            return imageUrl;
        }
        public async Task<string> getImageUrl()
        {
            MediaApiResponseModel data1 = new MediaApiResponseModel();
            string img = string.Empty;
            var response = await this.postStoreCategoryImage();
            if (response == null)
            {
                throw new Exception();
            }
            else
            {
                img = response;
            }
            return img;
        }
        public T GetJsonInstance<T>(string propertyName, string json)
        {
            using (var stringReader = new StringReader(json))
            {
                using (var jsonReader = new JsonTextReader(stringReader))
                {
                    while (jsonReader.Read())
                    {
                        if (jsonReader.TokenType == JsonToken.PropertyName
                            && (string)jsonReader.Value == propertyName)
                        {
                            jsonReader.Read();
                            var serializer = new JsonSerializer();
                            return serializer.Deserialize<T>(jsonReader);
                        }
                    }
                    return default(T);
                }
            }
        }
    }
    public class metaData
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public metaData(string id, string url)
        {
            Id = string.Empty;
            Url = string.Empty;
        }
        public metaData()
        {
        }

    }
    public class MediaApiResponseModel
    {
        public string id { get; set; }
        public string url { get; set; }
        public string media { get; set; }
        public string thumb { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
    public class ThumbyModel
    {
        public MediaApiResponseModel data { get; set; }
        public int status { get; set; }
        public bool success { get; set; }
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


/* particulier a particulier : entreprises*/