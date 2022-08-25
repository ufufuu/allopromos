using allopromo.Core.Abstract;
using allopromo.Core.Application.Dto;
using allopromo.Core.Domain;
using allopromo.Core.Entities;
using allopromo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Infrastructure.Repositories
{
    public class StoreRepository: IStoreRepository
    {
        private readonly AppDbContext _dbContext;
        public StoreRepository(AppDbContext dbContext)
            => _dbContext = dbContext;
        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public tStore Add(tStore store)
        {
            tStoreCategory category = new tStoreCategory { storeCategoryName = "Commercants" };
            _dbContext.StoreCategories.Add(category);

            tCity cityLocation = new tCity { cityGpsLongitude= "Lome - Maizerte"}; 
            //get from Localization Library
            cityLocation.cityName = "Quarier Agbelepedogan 2ieme von apres Total Totsi en allant " +
                "vers Attikoume - 7VP3+PR6 Singapore  N 48.14305  E 17.13055 * ";
            cityLocation.cityGpsLatitude = "wekrfewjk wdlfkkl wekfdlfk ";

            ApplicationUser user1 =new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
            };

            store.storeId = Guid.NewGuid(); //.ToString();
            store.storeName = store.storeName;
            store.storeCreatedOn = DateTime.Now.Date;
            store.storeBecomesInactiveOn = DateTime.Now.AddMonths(6).Date;
            store.storeDescription = store.storeDescription;

            store.user = user1;
            store.City = cityLocation;
            store.Category = category;

            //_dbContext.StoreCategories.Add(tCategory);
            //tCategory.tStores.Add(store);

            if (_dbContext != null)
                _dbContext.Stores.Add(store);

            _dbContext.SaveChanges();
            return store;
        }
        public async Task<tStore> GetStoreAsync(string Id)
        {
            tStore store = null;
            if (Id == null)
            {
                return null;
            }
            else
            {
                store = _dbContext.Stores
                .Where(x => x.user.Id == Id.ToString()).FirstOrDefault();
            }
            return store;
        }
        //public tStoreCategory AddStoreCategory(tStoreCategory storeCategory)
        //{
        //    return null;
        //}
        public tStoreCategory AddStoreCategory(string storeCategoryName)
        {
            if (storeCategoryName != null)
            {
                using (var dbContext = new AppDbContext())
                {
                    var storeCategory = new tStoreCategory();
                    storeCategory.storeCategoryName = storeCategoryName;
                    dbContext?.StoreCategories?.Add(storeCategory);

                    //}

                    dbContext.SaveChanges();
                    return storeCategory;
                }
            }
            else
                return null;
        }
        public async Task<IEnumerable<tStoreCategory>> GetStoreCategoriesAsync()
        {
            var tCategories= await _dbContext.StoreCategories.ToListAsync();
            return tCategories ;
        }

        public async Task<IEnumerable<tStore>> GetStoresByCategoryIdAsync(int catId)
        {
            return null;
        }
        public async Task<IEnumerable<tStore>> GetStoresByCategoryIdAsync(int catId, int fd, int t)
        {
            return null;
        }
        tStoreCategory AddStoreCategory(tStoreCategory storeCategory)
        {
            return null;
        }
        //GetStoreByIdAsync(string storeId)
        //}

        public async Task<IEnumerable<tStore>> GetStoresByCategoryIdAsync(string categoryId) 
            //GetStoresByIdAsync GetStoresByCatIdAsync
        {
            var stores = from q in _dbContext.Stores.Where(x => x.Category.storeCategoryId.ToString() == categoryId)
                         .AsNoTracking()
                         select q;
            return await stores.ToListAsync();
        }
        public async Task<IEnumerable<tStore>> GetStoresByCategoryIdAsync(string categoryId, int offSet, int limitPerPage)
        {
            var stores = from q in _dbContext.Stores.Where(x => x.Category.storeCategoryId.ToString()
                         == categoryId)
                         .Skip((offSet-1) * limitPerPage)
                         .Take(limitPerPage)
                         .AsNoTracking()
                            select q;
            return await stores.AsNoTracking().ToListAsync();
        }
        public IEnumerable<tStore> GetStoresAsync()
        {
            var stores = _dbContext.Stores.AsQueryable().ToList().AsEnumerable();
            return stores;
        }
        private int Count()
        {
            return _dbContext.Stores.Count();
        }
        private async Task<AppDbContext> GetDatabaseContext()
        {
            return null;
        }
        public void DeleteStoreCategory(tStoreCategory storeCategory)
        {
            if(storeCategory!=null)
            using(var db= new AppDbContext())
            {
                db.StoreCategories.Remove(storeCategory);
            }
        }
        void Update(tStore store)
        {
        }
        //void IStoreRepository.Delete(Store store)
        void Delete(tStore store)
        {
        }
        Task<List<tStore>> GetStoresByIdAsync(int categoryId, int limitPerPage)
        {
            throw new NotImplementedException();
        }
        Task<List<tStore>> GetStoresByCatIdAsync(string catId)
        {
            return null;
        }
        Task<IEnumerable<tStore>> GetStoresByCatIdAsync(int categoryId)
        {
            return null;
        }

        public tStoreCategory GetStoreByIdAsync(string storeId)
        {
            throw new NotImplementedException();
        }
    }
}
/* hat IS is it with that CancellationToken , in get Method argument at end ?
 * 
 * Method OverLoading vs method Overriding */
// vousbrillez-ca : Cegep de Ste Foy: intelligence d'Affaires et Mega-Donnees 
// other info: categor y cat, location loc, user user to passs to store 4 propagation !