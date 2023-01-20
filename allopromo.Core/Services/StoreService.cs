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
using Microsoft.EntityFrameworkCore;

namespace allopromo.Core.Model
{
    public delegate bool StoreCreatedEventHandler(object source, EventArgs e);
    public class StoreService : IStoreService
    {
        #region Properties
        public event StoreCreatedEventHandler StoreCreated;
        public Action<string> _StoreCreated;
        public static int _storesNumber { get; set; }
        public IRepository<tDepartment> _departmentRepository { get; set; }
        public HttpClient _httpClient { get; set; }//https://cdn.pixabay.com/photo/2013/10/15/09/12/flower-195893_150.jpg
        public string Url = "https://pixabay.com/api/?key=30135386-22f4f69d3b7c4b13c6e111db7&id=195893";
        public IRepository<tStoreCategory> _categoryRepository { get; set; }
        #endregion
        #region Fields
        private IRepository<tStore> _storeRepository;
        private IStoreManager _storeManager;
        private IProductService _productService { get; set; }
        IRepository<tStore> storeRepository;
        private IRepository<tStore> _tGenericRepository { get; set; }
        private UserService _userService { get; set; }
        #endregion
        #region Constructors
        public StoreService(IRepository<tStore> storeRepository, IRepository<tStoreCategory> categoryRepository,
            IRepository<tDepartment> departmentRepository)
        {
            _storeRepository = storeRepository;
            _categoryRepository = categoryRepository;
            _departmentRepository = departmentRepository;
        }
        public StoreService()
        {
        }

        event StoreCreatedEventHandler IStoreService.StoreCreated
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }
        #endregion
        #region Events
        public void OnStoreCreated()
        {
            if (StoreCreated != null)
            {
                StoreCreated(this, EventArgs.Empty);
            }
        }
        #endregion
        #region Public Properties - Getting Objects
        public async Task<IEnumerable<StoreDto>> GetStores()
        {
            //PaginationFilter validFilter = new PaginationFilter();
            IEnumerable<StoreDto> stores = new List<StoreDto>();
            var tStoreObj = await _storeRepository.GetAllAsync();
            stores = tStoreObj.AsQueryable()
                .Include(c=>c.Category)
                //.Skip((validFilter.pageNumber - 1) * validFilter.pageSize)
                //.Take(validFilter.pageSize)
                .AsNoTracking()
                .Select(s => new StoreDto
            {
                storeId = s.storeId.ToString(),
                storeName = s.storeName,
                storeDescription = s.storeDescription,
                Category= s.Category.storeCategoryName
            });
            if (stores!= null)
                return stores;
            else
                throw new NullReferenceException();
        }
        public async Task<IEnumerable<StoreDto>> GetStores(string categoryId)
        {
            var stores = (await _storeRepository.GetAllAsync()).AsQueryable()
                .Include(c => c.Category)
                .Include(v => v.City).Where(v => v.City.cityId.Equals(1))
                .Select(s => new StoreDto()
                {
                    storeId = s.storeId.ToString(),
                    storeName = s.storeName,
                    storeDescription = s.storeDescription,
                    Category = s.Category.storeCategoryName,
                    City = s.City.cityName.ToString()
                });
            if (stores != null)
                return stores;
            else
                throw new NullReferenceException();
        }
        public async Task<IEnumerable<StoreDto>> GetStores (string categoryId, string localizationId, string sortingOrder)
        {
            var validFilter = 10;
            int pageNumber = 1;
            int pageSize = 1;

            var stores = (await _storeRepository.GetAllAsync()).AsQueryable()
                .Include(c => c.Category).Where( category=>category.Category.storeCategoryId.Equals(categoryId))
                .Include(v => v.City).Where(v => v.City.cityId.Equals(localizationId))

                //.OrderBy()
                //.Skip((validFilter.pageNumber-1) * validFilter.pageSize)
                //.Take(validFilter.pageSize)
                //AsNoTracking()
                .Select(s => new StoreDto()
                {
                    storeId = s.storeId.ToString(),
                    storeName = s.storeName,
                    storeDescription = s.storeDescription,
                    Category = s.Category.storeCategoryName,
                    City = s.City.cityName.ToString()
                });
            switch (sortingOrder)
            {
                case "Date":
                   stores = stores.OrderByDescending(o => o.storeId);
                   break;

                case "popularityOrReview":
                    stores = stores.OrderByDescending(o => o.storeId);
                    break;
                default:
                    stores = stores.OrderByDescending(o => o.storeId);
                    break;
            }
                
            if (stores!= null)
                return stores;
            else
                throw new NullReferenceException();
        }
        public async Task<IEnumerable<StoreCategoryDto>> GetStoreCategoriesAsync()
        {
            IEnumerable<StoreCategoryDto> categories = null;
            var categoriesRepo = await _categoryRepository.GetAllAsync();
            var categoriesObj = categoriesRepo.AsQueryable().Include(x => x.Department)
                .Select(c => new StoreCategoryDto
                {
                    storeCategoryId = c.storeCategoryId.ToString(),
                    storeCategoryName = c.storeCategoryName,
                    DepartmentName = c.Department.departmentName
                });
            categories = AutoMapper.Mapper.Map
                    <IEnumerable<StoreCategoryDto>>(categoriesObj);
            if (categories == null)
                throw new ArgumentNullException();
            return categories;
        }
        
        public async Task<StoreCategoryDto> GetStoreCategoriesAsyncById(string Id)
        {
            var categories = await this.GetStoreCategoriesAsync();
            var query = from q in categories
                        where q.storeCategoryId.ToString() == Id
                        select q;
            return query.FirstOrDefault();
        }
        private async Task<int> GetUserStoresAsync(ApplicationUser user)
        {
            var Id = _userService.GetUserbyId(user.Id);
            var query = from q in await _storeRepository.GetAllAsync()
                        where q.user.Equals(user)
                        select q;
            int numberStores = query.Count();
            return numberStores;
        }
        public async Task<IEnumerable<ProductDto>> GetProductsByStoresAndCategories(string storeId)
        {
            if (storeId == null)
                return null;
            return await _productService.GetProductsByStore(storeId);
        }

        private int GetStoresProducts(ApplicationUser user)
        {
            var Id = String.Empty;
            var productQuery = from q
                               in _productService.GetProductsByStore(Id).Result
                               select q;
            return productQuery.Count();
        }
        public async Task<IEnumerable<StoreDto>> GetStoresByCategoryIdAsync(int categoryId,
            int pageNumber, int offSet)
        {
            offSet = 10;
            if (categoryId.Equals(null))
                return null;
            else
            {
                var storesByCategory = await _storeRepository.GetByIdAsync(categoryId);
                //pageNumber, offSet);
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
            }
            return null;
        }
        public async Task<StoreCategoryDto> GetStoreCategoryByIdAsync(string storeId)
        {
            if (storeId == null)
                return null;
            var cat = await _categoryRepository.GetByIdAsync(storeId);
            return AutoMapper.Mapper.Map<StoreCategoryDto>(cat);
        }
        public async Task<StoreDto> GetStoreByIdAsync(string storeId)
        {
            if (storeId == null)
                return null;
            StoreCreatedEventHandler del = delegate
            {
                return true;
            };
            var tStore = await _storeRepository.GetByIdAsync(storeId);
            return AutoMapper.Mapper.Map<StoreDto>(tStore);
        }
        #endregion
        #region Creating Objects
        public async Task<StoreDto> CreateStore(//StoreDto storeDto)
            string storeDtoName)
        {
            if (storeDtoName == null)
                return null;
            else
            {
                tStore store = new tStore();
                tStoreCategory category = null;

                store.storeId = Guid.NewGuid();
                store.storeName = storeDtoName;
                store.City = new tCity { cityName = "Lome", cityId = 679, countryId = 990 };
                store.Category = category;
                await _storeRepository.Add(store);
            }
            return new StoreDto();
        }
        public async Task<StoreCategoryDto> CreateStoreCategoryAsync(StoreCategoryDto storeCategory)
        {
            if (storeCategory == null)
                return null;
            var dateExpiring = DateTime.Now.AddMonths(6).Day.ToString("00");
            var storeCategoryDto = new StoreCategoryDto();
            var tStoreCategory = new tStoreCategory();

            tStoreCategory.storeCategoryName = storeCategory.storeCategoryName;
            tStoreCategory.storeCategoryId = Guid.NewGuid();
            var imageUrl = string.Empty;
            if (postStoreCategoryImage() != null)
            {
                imageUrl = await this.getImageUrl();
            }
            else
            {
                imageUrl = "http://www.noiamgesfornow.jpg";
            }
            //tStoreCategory.storeCategoryImageUrl = imageUrl;
            await _categoryRepository.Add(tStoreCategory); //, imageUrl);
            return storeCategoryDto;
        }
        //public async Task<StoreDto> CreateStore(StoreDto storeDto)
        //{
        //    return null;
        //}
        public async Task<StoreDto> CreateStoreAsync(StoreDto store, StoreCategoryDto category, UserDto userDto)
        {
            if(store!=null)
            {
                StoreDto storeDto = null;
                tStore tStore = null;

                var appUser = Mapper.Map<ApplicationUser>(userDto);
                var storesNumber = GetStoresProducts(appUser);
                var dateExpiring = DateTime.Now.AddMonths(6).Day.ToString("00");
                var tUser = Mapper.Map<ApplicationUser>(userDto);
                var tCategory = AutoMapper.Mapper.Map<tStoreCategory>(category);

                storeDto = Mapper.Map<StoreDto>(store);
                var location = new tLocation();
                var city = new tCity { cityName = "kara" };

                tStore.Category = tCategory;
                tStore.user = tUser;
                tStore.City = city;
                _storeRepository.Add(tStore);
                _storeRepository.Save();
                _tGenericRepository.Save();
                OnStoreCreated();
                return storeDto;
            }
            else
                return null;
        }
        #endregion

        #region Updating Entities
        public void UpdateStoreCategory(string Id, StoreCategoryDto categoryDto)
        {
            if (Id != categoryDto.storeCategoryId.ToString())
                throw new Exception();
            var obj = AutoMapper.Mapper.Map<StoreCategoryDto, tStoreCategory>(categoryDto);
            obj.storeCategoryId = Guid.Parse(Id);
            obj.storeCategoryName = categoryDto.storeCategoryName;
            _categoryRepository.Update(obj);
        }
        public void UpdateStoreCategory(StoreCategoryDto category)
        {
            var obj = AutoMapper.Mapper.Map<tStoreCategory>(category);
            _categoryRepository.Update(obj);
        }
        #endregion
        //public Task<StoreDto> CreateStore(StoreDto store, StoreCategoryDto category, UserDto user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<IEnumerable<ProductDto>> GetStoresByLocalizationIdAsync(string storeId)
        //{
        //    return null;
        //}
        //Task<IEnumerable<StoreDto>> IStoreService.GetStoresByCategoryIdAsync(int catId, int pageNumber, int offSet)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<StoreDto> IStoreService.GetStoreByIdAsync(string storeId)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<StoreCategoryDto> IStoreService.GetStoreCategoryByIdAsync(string catId)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<StoreDto> IStoreService.GetStoresByLocationIdAsync()
        //{
        //    throw new NotImplementedException();
        //}
        //Task<StoreCategoryDto> IStoreService.GetStoreCategoriesAsyncById(string Id)
        //{
        //    throw new NotImplementedException();
        //}
        
        #region DELETE Objects
        public void DeleteStore(StoreDto store)
        {
            storeRepository.Delete(store);
        }
        public void DeleteStoreCategory(string categoryId)
        {
        }
        public void DeleteStoreCategory(StoreCategoryDto storeCategoryDto)
        {
            if (storeCategoryDto == null)
            {
                var storeCategory = AutoMapper.Mapper.Map<tStoreCategory>(storeCategoryDto);
                //_storeRepository.DeleteStoreCategory(storeCategory);
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
        #endregion
        #region Utilities Methods
        public async Task<string> getImageInformationAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var imageInformationUlr = new Uri("https://pixabay.com/api/?key=30135386-22f4f69d3b7c4b13c6e111db7&id=195893");
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, imageInformationUlr);
                var httpResponseMsg = await httpClient.SendAsync(httpRequest);
                var content = await httpResponseMsg.Content.ReadAsStringAsync();//httpResponseMsg
                var response = Newtonsoft.Json.JsonConvert.SerializeObject(httpResponseMsg);
                var image = (string)response;
            }
            //var data = new metaData { Id = "1232", Url = "https//allo.promo/images/92bw23fhj.jpg" };

            var res = Newtonsoft.Json.JsonConvert.SerializeObject(new 
            {
                Id="2332", 
                Url= "https//allo.promo/images/92bw23fhj.jpg" }
            );
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
                var result = await httpClient.PostAsync("https://thumbsnap.com/api/upload", null);
                //if (result.IsSuccessStatusCode)
                //{
                    response = result.StatusCode.ToString();
                    var obj = JsonConvert.DeserializeObject<ThumbyModel>(jsonObj);
                    MediaApiResponseModel dataObj = obj.data;
                    var image = JsonConvert.SerializeObject(dataObj);
                    var media = JsonConvert.DeserializeObject<MediaApiResponseModel>(image);
                    imageUrl = media.url;
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
        #endregion
        #region Other
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
        void IStoreService.OnStoreCreated()
        {
            throw new NotImplementedException();
        }

        Task<StoreDto> IStoreService.CreateStore(StoreDto store, StoreCategoryDto category, UserDto user)
        {
            throw new NotImplementedException();
        }
        Task<StoreDto> IStoreService.CreateStore(StoreDto store)
        {
            throw new NotImplementedException();
        }
        Task<StoreDto> IStoreService.CreateStore(string storeDtoName)
        {
            throw new NotImplementedException();
        }
        void IStoreService.UpdateStoreCategory(string Id, StoreCategoryDto categoryDto)
        {
            throw new NotImplementedException();
        }

        Task<StoreCategoryDto> IStoreService.CreateStoreCategoryAsync(StoreCategoryDto storeCategoryName)
        {
            throw new NotImplementedException();
        }

        
        void IStoreService.DeleteStoreCategory(StoreCategoryDto storeCategoryDto)
        {
            throw new NotImplementedException();
        }

        void IStoreService.DeleteStoreCategory(string categoryId)
        {
            throw new NotImplementedException();
        }

        Task<string> IStoreService.getImageUrl()
        {
            throw new NotImplementedException();
        }

        Task<string> IStoreService.getImageInformationAsync()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
    
    //public class OrderPlacedEventArgs : EventArgs
    //{
    //}
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
/* particulier a particulier : entreprises
 * Latitude: 46.861114 / N 46° 51' 40.012''
Longitude: -71.268900 / W 71° 16' 8.04''
*/
/*
 * https://www.gps-coordinates.net/api
 */