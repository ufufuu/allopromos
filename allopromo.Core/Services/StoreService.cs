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
using Microsoft.AspNetCore.Http;

namespace allopromo.Core.Model
{
    public delegate bool StoreCreatedEventHandler(object source, EventArgs e);
    public class StoreService : IStoreService
    {
        #region Constantes
        public HttpClient _httpClient { get; set; }//https://cdn.pixabay.com/photo/2013/10/15/09/12/flower-195893_150.jpg
        public string Url = "https://pixabay.com/api/?key=30135386-22f4f69d3b7c4b13c6e111db7&id=195893";
        #endregion

        #region Properties

        public event StoreCreatedEventHandler StoreCreated;

        public Action<string> _StoreCreated;
        public static int _storesNumber { get; set; }
       
        public IAccountService _accountService { get; set; }
        public IUserService _userService { get; set; }
        public UserManager<IdentityUser> _userManager { get; set; }
        public IHttpContextAccessor _httpContextAccessor { get; set; }
        #endregion
        public IDepartmentService _departmentService { get;set; }
        public IRepository<tDepartment> _departmentRepository { get; set; }
        public IRepository<tStoreCategory> _categoryRepository { get; set; }
        #region Fields
        private IRepository<tStore> _storeRepository;
        private IProductService _productService { get; set; }
        private IRepository<tStore> StoreRepository;
        private IRepository<tStore> _tGenericRepository { get; set; }

        private ILocalisationService _localisationService { get; set; }

        #endregion

        #region Constructors
        public StoreService(IRepository<tStore> storeRepository, IRepository<tStoreCategory> categoryRepository,
            IDepartmentService departmentService, ILocalisationService LocalisationService,
            IUserService userService, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor,
            IRepository<tDepartment> departmentRepository)
        {
            StoreRepository = storeRepository;
            _storeRepository = storeRepository;
            _categoryRepository = categoryRepository;
            _userService = userService;
            _userManager = userManager;
            _localisationService = LocalisationService;
            _departmentService = departmentService;
            _httpContextAccessor = httpContextAccessor;
            _departmentRepository = departmentRepository;
        }
        public StoreService()
        {}
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

        #region Creating Objects 
        public async Task<StoreDto> CreateStore(string storeDtoName)
        {
            if (storeDtoName == null)
                return null;
            else
            {
                tStore store = new tStore();
                tStoreCategory category = null;
                store.storeId = Guid.NewGuid();
                store.storeName = storeDtoName;
                store.City = new tCity { cityName = "Lome", cityId = 679 };
                store.Category = category;
                _storeRepository.Add(store);
            }
            return new StoreDto();
        }
        public async Task<StoreCategoryDto> CreateStoreCategoryAsync(StoreCategoryDto storeCategory)
        {
            if (storeCategory == null)
                return null;
            var dateExpiring = DateTime.Now.AddMonths(6).Day.ToString("00");

            var department = _departmentService.GetEntities().Result
                .Where(x => x.departmentName == storeCategory.DepartmentName).FirstOrDefault();

            var tStoreCategory = new tStoreCategory();
            tStoreCategory.storeCategoryId = Guid.NewGuid();
            tStoreCategory.storeCategoryName = storeCategory.storeCategoryName;
            tStoreCategory.created = DateTime.Now;
            tStoreCategory.expires = DateTime.Now;
            tStoreCategory.Department = department;
            var imageUrl = string.Empty;
            if (postStoreCategoryImage() != null)
            {
                imageUrl = await this.getImageUrl();
            }
            else
            {
                imageUrl = "http://www.noiamgesfornow.jpg";
            }
            _categoryRepository.Add(tStoreCategory);
            return storeCategory;
        }
        
        private IdentityUser getCurrentUtili()
        {
            var currentUser = _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User).Result;
            return currentUser;
        }
        public async Task<StoreDto> CreateStoreAsync(StoreDto storeDto, string userDtoName)
        {
            var y = getCurrentUtili();
            try
            {
                if (storeDto != null)
                {
                    var currentUser = await _userManager.FindByNameAsync(userDtoName);
                    var storeObj = new tStore();
                    
                    var category = (from q in _categoryRepository.GetAllAsync().Result.AsQueryable()
                                   select q).Where(x => x.storeCategoryName.ToString() == storeDto.storeCategory).FirstOrDefault();
                    var ci= (from q in _categoryRepository.GetAllAsync().Result.AsQueryable()
                             select q).Where(x => x.storeCategoryName.ToString() == storeDto.storeCategory).FirstOrDefault();

                    var dateExpiring = DateTime.Now.AddMonths(6).Day.ToString("00");

                    //var tStoreObj = Mapper.Map<tStore>(store);
                    //storeDto = Mapper.Map<StoreDto>(store);

                    var location = new tLocation();

                    var city = new tCity { cityName = "Kara" };

                    tCity cityObj = new tCity();

                    //using (ILocalisationService locService = new Contracts.LocalisationService())//_cityRepository, _countryRepository)) ;
                    //{
                    //    cityObj = await locService.GetCityByName("Kara");
                    //}

                    cityObj = await _localisationService.GetCityByName("Kara");
                    city.cityGpsLatitude = "";
                    city.cityGpsLongitude = "";
                    city.cityCountry = null;

                    storeObj.storeId = Guid.NewGuid();
                    storeObj.storeName = storeDto.storeName;
                    storeObj.User = currentUser;
                    storeObj.Category = category;
                    storeObj.City = cityObj;

                    _storeRepository.Add(storeObj);

                    OnStoreCreated();
                    return storeDto;
                }
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                throw;
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
                //.Include(c=>c.Category)
                //.Skip((validFilter.pageNumber - 1) * validFilter.pageSize)
                //.Take(validFilter.pageSize)
                .AsNoTracking()
                .Select(s => new StoreDto
                {
                storeName = s.storeName,
                storeDescription = s.storeDescription,
                storeCategory= "Restaurants"                        //s.Category.storeCategoryName
                });
            if (stores!= null)
                return stores;
            else
                throw new NullReferenceException();
        }
        public async Task<List<StoreDto>> GetStoresAsync()
        {
            IList<StoreDto> stores = new List<StoreDto>();
            try
            {
                var storeObjs = await _storeRepository.GetAllAsync();
                foreach (var storeObj in storeObjs)
                {
                    stores.Add(new StoreDto
                    {
                        storeName=storeObj.storeName,
                        storeCategory= storeObj.storeDescription,
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return stores.ToList();
        }
        public async Task<IEnumerable<StoreDto>> GetStores(string categoryId)
        {
            var stores = (await _storeRepository.GetAllAsync()).AsQueryable()
                .Include(c => c.Category)
                .Include(v => v.City).Where(v => v.City.cityId.Equals(1))
                .Select(s => new StoreDto()
                {
                    storeName = s.storeName,
                    storeDescription = s.storeDescription,
                    storeCategory = s.Category.storeCategoryName,
                    City = s.City.cityName.ToString()
                });
            if (stores != null)
                return stores;
            else
                throw new NullReferenceException();
        }
        public async Task<IEnumerable<StoreDto>> GetStores (string categoryId, string localizationId, string sortingOrder)
        {
            //var validFilter = 10;
            //int pageNumber = 1;
            //int pageSize = 1;

            var stores = (await _storeRepository.GetAllAsync()).AsQueryable()
                .Include(c => c.Category).Where( category=>category.Category.storeCategoryId.Equals(categoryId))
                .Include(v => v.City).Where(v => v.City.cityId.Equals(localizationId))

                //.OrderBy()
                //.Skip((validFilter.pageNumber-1) * validFilter.pageSize)
                //.Take(validFilter.pageSize)
                //AsNoTracking()
                .Select(s => new StoreDto()
                {
                    storeName = s.storeName,
                    storeDescription = s.storeDescription,
                    storeCategory = s.Category.storeCategoryName,
                    City = s.City.cityName.ToString()
                });
            switch (sortingOrder)
            {
                case "Date":
                   //stores = stores.OrderByDescending(o => o.storeId);
                   break;

                case "popularityOrReview":
                    stores = stores.OrderByDescending(o => o.City);
                    break;
                default:
                    stores = stores.OrderByDescending(o => o.storeCategory);
                    break;
            }
                
            if (stores!= null)
                return stores;
            else
                throw new NullReferenceException();
        }
        public async Task<IEnumerable<StoreCategoryDto>> GetStoreCategoriesAsync()
        {
            //IEnumerable<StoreCategoryDto> categories = null;
            var categoriesRepo = await _categoryRepository?.GetAllAsync();
            var categoriesObj = categoriesRepo.AsQueryable().Include(x => x.Department)
                .Select(c => new StoreCategoryDto
                {
                    storeCategoryName = c.storeCategoryName,
                    DepartmentName = c.Department.departmentName
                });
            var categories = AutoMapper.Mapper.Map
                    <IEnumerable<StoreCategoryDto>>(categoriesObj);
            if (categories == null)
                throw new ArgumentNullException();
            return categories;
        }
        
        public async Task<StoreCategoryDto> GetStoreCategoriesAsyncById(string Id)
        {
            var categories = await this.GetStoreCategoriesAsync();
            var query = from q in categories
                        where q.storeCategoryName==Id
                        select q;
            return query.FirstOrDefault();
        }
        private async Task<int> GetUserStoresAsync(ApplicationUser user)
        {
            var Id = _userService.GetUserById(user.Id);
            var query = from q in await _storeRepository.GetAllAsync()
                        where q.User.Equals(user)
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
        public async Task<IEnumerable<StoreDto>> GetStoresByLocalizationAsync(int locationId, int page, int size)
        {
            try
            {
                var storesByLocation = await _tGenericRepository.GetAllAsync();
                return AutoMapper.Mapper.Map<IEnumerable<StoreDto>>(storesByLocation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
        public async Task<IQueryable<tStore>> GetStoresByUserName(string Name)
        {
            if (string.IsNullOrEmpty(Name))
                throw new Exception();
            else
            {
                var tObjs = _storeRepository.GetEntitiesAsync().Result;
                var sd = 78;
                var tObjsg = (await _storeRepository.GetEntitiesAsync()).AsQueryable()
                    .Where(x => x.User.Email.Equals(Name));
                var hg = 76;
                return (IQueryable<tStore>)tObjs;
            }
        }
        #endregion

       

        #region Updating Entities
        public void UpdateStoreCategory(string Id, StoreCategoryDto categoryDto)
        {
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
            StoreRepository.Delete(store);
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
                var category = StoreRepository.GetByIdAsync("kjkjk");
                if (storeCategory == null)
                {
                    throw new NullReferenceException();
                }
                else
                {
                    StoreRepository.Delete(storeCategory);
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

        public Task<StoreDto> CreateStore(StoreDto store)
        {
            throw new NotImplementedException();
        }

        //Task<StoreDto> IStoreService.CreateStore(StoreDto store, StoreCategoryDto category, UserDto user)
        //{
        //    throw new NotImplementedException();
        //}


        //Task<StoreDto> IStoreService.CreateStore(StoreDto store)
        //{
        //    throw new NotImplementedException();
        //}


        //Task<StoreDto> IStoreService.CreateStore(string storeDtoName)
        //{
        //    throw new NotImplementedException();
        //}

        /*Task<StoreCategoryDto> IStoreService.CreateStoreCategoryAsync(StoreCategoryDto storeCategoryName)
        {
            throw new NotImplementedException();
        }*/


        //void IStoreService.UpdateStoreCategory(string Id, StoreCategoryDto categoryDto)
        //{
        //    throw new NotImplementedException();
        //}

        //void IStoreService.DeleteStoreCategory(StoreCategoryDto storeCategoryDto)
        //{
        //    throw new NotImplementedException();
        //}

        //void IStoreService.DeleteStoreCategory(string categoryId)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<string> IStoreService.getImageUrl()
        //{
        //    throw new NotImplementedException();
        //}

        //Task<string> IStoreService.getImageInformationAsync()
        //{
        //    throw new NotImplementedException();
        //}
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