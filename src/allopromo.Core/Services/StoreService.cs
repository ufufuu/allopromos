using allopromo.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using allopromo.Core.Entities;
using System.Net.Http;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using allopromo.Core.Interfaces;

namespace allopromo.Core.Services
{
    public class StoreService: IStoreService
    {
        public delegate bool StoreCreatedEventHandler(object source, EventArgs e);

        public string Url = "https://pixabay.com/api/?key=30135386-22f4f69d3b7c4b13c6e111db7&id=195893";
        public Action<string> _StoreCreated;
        public HttpClient _httpClient { get; set; }
        public IRepository<Store> _storeRepository { get; set; }

        public event StoreCreatedEventHandler StoreCreated;
        public static int _storesNumber { get; set; }
        public IUserService _userService { get; set; }
        public UserManager<ApplicationUser> _userManager { get; set; }
        public IHttpContextAccessor _httpContextAccessor { get; set; }
        public IDepartmentService _departmentService { get; set; }
       // public IRepository<Department> _departmentRepository { get; set; }
        public IRepository<StoreCategory> _storeCategoryRepository { get; set; }
        //private ICatalogService _catalogService { get; set; }
        private ILocationService _locationService { get; set; }
        public INotifyService _notificationService { get; set; }
        public StoreService(
          IRepository<Store> storeRepository,
          IRepository<StoreCategory> storeCategoryRepository,
          IDepartmentService departmentService,
          ILocationService locationService,
          IUserService userService
            )
        {
            _storeRepository = storeRepository;
            _storeCategoryRepository = storeCategoryRepository;
            _locationService = locationService;
            _departmentService = departmentService;
            _userService = userService;
        }
        protected virtual void OnStoreCreated()
        {
            if (this.StoreCreated == null)
                return;
            int num = this.StoreCreated((object)this, EventArgs.Empty) ? 1 : 0;
        }

        public async Task<bool> CreateStoreAsync( Store store, string proprioName, 
            string storeCityName, string storeCategoryName)
        {
            try
            {
                if (store == null)
                    return false;
                ApplicationUser currentUser = await this._userManager.FindByNameAsync(proprioName);
                if ((await this._userManager.GetRolesAsync(currentUser)).FirstOrDefault<string>().ToString() == "Merchants")
                    return false;

                Store storeObj = new Store();
                StoreCategory category = (await _storeCategoryRepository
                    .GetAllAsync()).Where(x => x.storeCategoryName.Equals(storeCategoryName))
                    .FirstOrDefault();
                                
                City cityByName = await _locationService.GetCityByName(storeCityName);
                storeObj.storeId = Guid.NewGuid();
                storeObj.storeName = store.storeName;
                storeObj.storeDescription = store.storeDescription;
                storeObj.User = currentUser;
                storeObj.storeCreatedOn = DateTime.UtcNow;
                storeObj.Category = category;
                this._storeRepository.Add(storeObj);
                this.OnStoreCreated();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> UpdateStoreAsync(string Id, Store store) => Task.FromResult<bool>(true);

        public Task<bool> UpdateStoreCategoryAsync(string Id, StoreCategory category)
        {
            return Task.FromResult<bool>(true);
        }

        public async Task CreateStoreCategoryAsync(StoreCategory storeCategory)
        {
            if (storeCategory == null)
                throw new NullReferenceException();
            DateTime dateTime = DateTime.Now;
            dateTime = dateTime.AddMonths(6);
            dateTime.Day.ToString("00");
            Department department = _departmentService.GetDepartmentsAsync()
                .Result.Where(x => x.departmentName == storeCategory.Department.departmentName)
                .FirstOrDefault<Department>();
            StoreCategory StoreCategory = new StoreCategory();
            StoreCategory.storeCategoryId = Guid.NewGuid();
            StoreCategory.storeCategoryName = storeCategory.storeCategoryName;
            StoreCategory.created = DateTime.Now;
            StoreCategory.expires = new DateTime?(DateTime.Now);
            StoreCategory.Department = department;
            string empty = string.Empty;
            if (this.posStoreCategoryImage() != null)
            {
                string imageUrl = await this.getImageUrl();
            }
            _storeCategoryRepository.Add(StoreCategory);
            StoreCategory = (StoreCategory)null;
        }


        public async Task<IEnumerable<Store>> GetStoresAsyncss()
        {
            IList<Store> storeList = (IList<Store>)new List<Store>();
            IList<Store> allAsync;
            try
            {
                allAsync = (IList<Store>)await this._storeRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return allAsync.AsEnumerable<Store>();
        }


        public async Task<IEnumerable<Store>> GeStoresByCategoryIdAsync( int categoryId, int pageNumber, int offSet)
        {
            offSet = 10;
            if (categoryId == null)
                throw new NullReferenceException();

            var stores = await this._storeRepository.GetByIdAsync(categoryId);
            return (IEnumerable<Store>)stores;
        }

        public async Task<IEnumerable<Store>> GeStoresByLocalizationAsync(
          int locationId,
          int page,
          int size)
        {
            IEnumerable<Store> stores;
            try
            {
                stores = (await this._storeRepository.GetAllAsync()).AsEnumerable<Store>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return stores;
        }

        public async Task<StoreCategory> GeStoreCategoryByIdAsync(string storeId)
        {
            return storeId == null ? (StoreCategory)null 
                : Mapper.Map<StoreCategory>(await _storeCategoryRepository.GetByIdAsync(storeId));
        }

        public async Task<Store> GeStoreByIdAsync(string storeId)
        {
            if (storeId == null)
                return (Store)null;
            StoreCreatedEventHandler createdEventHandler = (StoreCreatedEventHandler)((_param1, _param2) => true);
            return await this._storeRepository.GetByIdAsync(storeId);
        }

        public async Task<IQueryable<Store>> GeStoresByUserName(string Name)
        {
            if (string.IsNullOrEmpty(Name))
                throw new Exception();
            IEnumerable<Store> tObjs = this._storeRepository.GetEntitiesAsync().Result;
            (await this._storeRepository.GetEntitiesAsync()).AsQueryable<Store>()
                .Where (x => x.User.Email.Equals(Name));
            return (IQueryable<Store>)tObjs;
        }

        public void UpdateStoreCategory(string Id, StoreCategory storeCategory)
        {
            _storeCategoryRepository.Update(Mapper.Map<StoreCategory>((object)storeCategory));
        }

        public void UpdateStoreCategory(StoreCategory category)
        {
            _storeCategoryRepository.Update(Mapper.Map<StoreCategory>((object)category));
        }

        public void DeleteStore(Store store) => this._storeRepository.Delete(store);

        public void DeleteStoreCategory(string categoryId)
        {
        }

        public void DeleteStoreCategory(StoreCategory storeCategoryDto)
        {
            if (storeCategoryDto != null)
                return;
            StoreCategory Id = Mapper.Map<StoreCategory>((object)storeCategoryDto);
            this._storeRepository.GetByIdAsync("kjkjk");
            if (Id == null)
                throw new NullReferenceException();
            this._storeRepository.Delete((object)Id);
        }

        public async Task<string> getImageInformationAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage httpResponseMsg = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, new Uri("https://pixabay.com/api/?key=30135386-22f4f69d3b7c4b13c6e111db7&id=195893")));
                string str = await httpResponseMsg.Content.ReadAsStringAsync();
                JsonConvert.SerializeObject((object)httpResponseMsg);
                httpResponseMsg = (HttpResponseMessage)null;
            }
            return JsonConvert.SerializeObject((object)new
            {
                Id = "2332",
                Url = "https//allo.promo/images/92bw23fhj.jpg"
            });
        }

        private async Task<string> posStoreCategoryImage()
        {
            string empty = string.Empty;
            string str = string.Empty;
            using (HttpClient httpClient = new HttpClient())
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri("https://thumbsnap.com/api/upload"));
                (await httpClient.PostAsync("https://thumbsnap.com/api/upload", (HttpContent)null)).StatusCode.ToString();
                JsonConvert.SerializeObject((object)null);
                str = (string)null;
            }
            return str;
        }

        public async Task<string> getImageUrl()
        {
            string empty = string.Empty;
            return await this.posStoreCategoryImage() ?? throw new Exception();
        }
        public T GetJsonInstance<T>(string propertyName, string json)
        {
            using (StringReader stringReader = new StringReader(json))
            {
                using (JsonTextReader jsonTextReader = new JsonTextReader((TextReader)stringReader))
                {
                    while (((JsonReader)jsonTextReader).Read())
                    {
                        if (jsonTextReader.TokenType.Equals(4) && (string)((JsonReader)jsonTextReader).Value == propertyName)
                        {
                            ((JsonReader)jsonTextReader).Read();
                            return new JsonSerializer().Deserialize<T>((JsonReader)jsonTextReader);
                        }
                    }
                    return default(T);
                }
            }
        }

        public async Task<IEnumerable<Store>> GetStoresByCategoryNameAsync(
          string categoryName,
          int pageNumber,
          int offSet)
        {
            IEnumerable<Store> storesAsync = await this.GetStoresAsync();
            int count = 3;
            Func<Store, bool> predicate = (Func<Store, bool>)(x => x.Category.storeCategoryName.Equals(categoryName.ToString()));
            IEnumerable<Store> source = storesAsync.Where<Store>(predicate);
            source.Skip<Store>(offSet - 1).Take<Store>(count).AsQueryable<Store>();
            return source;
        }
        public async Task<IEnumerable<Store>> GetStoresAsync()
        {
            List<Store> storeList1 = new List<Store>();
            List<ApplicationUser> users = await this._userManager.Users.ToListAsync<ApplicationUser>();
            List<Store> storesObj = await this._storeRepository.GetAllAsync();
            List<StoreCategory> categories = await _storeCategoryRepository.GetAllAsync();
            return storeList1;
        }
        public Task<Store> GetStoreByIdAsync(string storeId) => throw new NotImplementedException();

        public Task<StoreCategory> GetStoreCategoryByIdAsync(string catId)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<Store>> GetStoresByUserName(string userName)
        {
            if (userName == null)
                return (IQueryable<Store>)null;
            return (await this._storeRepository.GetEntitiesAsync()).AsQueryable<Store>()
                .Where(x => x.User.UserName.Equals(userName));
        }

        public Task<IEnumerable<Store>> GetStores(string localizationId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Store>> GetStores(string categoryId, string localizationId, string sortingOrder)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StoreCategory>> GetStoreCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<StoreCategory> GetStoreCategoriesAsyncById(string Id)
        {
            throw new NotImplementedException();
        }
    }

}

//public class OrderPlacedEventArgs : EventArgs
//{
//}

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