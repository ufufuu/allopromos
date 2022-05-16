using allopromo.Core.Abstract;
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

            tCity cityLocation = new tCity { cityGpsLongitude= "Lome - Maizerte"}; //get from Localization Library
            cityLocation.cityName = "Quarier Agbelepedogan 2ieme von apres Total Totsi en allant " +
                "vers Attikoume - 7VP3+PR6 Singapore  N 48.14305  E 17.13055 * ";
            cityLocation.cityGpsLatitude = "wekrfewjk wdlfkkl wekfdlfk ";

            //tUser user1 = new tUser {userId= "1ec20d6f-e844-4865-b275-9c08a3249619"};


            ApplicationUser user1 =new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
            };

            //allopromo.Core.Model.tUser
            //store = new tStore();

            store.storeId = Guid.NewGuid().ToString();
            store.storeName = store.storeName;
            store.storeCreatedOn = DateTime.Now.Date;
            store.storeBecomesInactiveOn = DateTime.Now.AddMonths(6).Date;
            store.storeDescription = store.storeDescription;

            store.user = user1;
            store.City = cityLocation;
            store.Category = category;

            int y = 6;
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
        public tStoreCategory AddCategory(tStoreCategory storeCategory)
        {
            if (_dbContext != null)
            {
                _dbContext?.StoreCategories.Add(storeCategory);
            }
            _dbContext.SaveChanges();
            return storeCategory;
        }
        public async Task<IEnumerable<tStoreCategory>> GetStoreCategoriesAsync()
        {
            return await _dbContext.StoreCategories.ToListAsync();
        }
        //public async Task<List<tStore>> GetStoresByCategoryIdAsync(int catId)
        //{
        //    return null;
        //GetStoreByIdAsync(string storeId)
        //}
        public async Task<IEnumerable<tStore>> GetStoresByCategoryIdAsync(int categoryId) //GetStoresByIdAsync GetStoresByCatIdAsync
        {
            var stores = from q in _dbContext.Stores.Where(x => x.Category.storeCategoryId == categoryId)
                         .AsNoTracking()
                         select q;
            return await stores.ToListAsync();
        }
        public async Task<IEnumerable<tStore>> GetStoresByCategoryIdAsync(int categoryId, int offSet, int limitPerPage)
        {
            var stores = from q in _dbContext.Stores.Where(x => x.Category.storeCategoryId == categoryId)
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
        //void IStoreRepository.Update(Store store)
        void Update(tStore store)
        {
        }
        //void IStoreRepository.Delete(Store store)
        void Delete(tStore store)
        {
        }
        //Task<tStore> IStoreRepository.GetStoreByIdAsync(string storeId)
        //{
        //    return null;
        //}
        //List<tStore> IStoreRepository.GetStoresAsync()
        //{
        //    return null;
        //}

        //Task<List<tStore>> GetStoresByIdAsync(string catId)
        //{
        //    return null;
        //}

        //public Task<tStore> GetStoreAsync(string storeId)
        //{
        //    return null;
        //}
        Task<List<tStore>> GetStoresByIdAsync(int categoryId, int limitPerPage)
        {
            throw new NotImplementedException();
        }
        //Task<tStore> GetStoreAsync(string storeId)
        //{
        //    return null;
        //}

        //tStore Add(tStore store)
        //{
        //    return null;
        //}
        Task<List<tStore>> GetStoresByCatIdAsync(string catId)
        {
            return null;
        }
        Task<IEnumerable<tStore>> GetStoresByCatIdAsync(int categoryId)
        {
            return null;
        }
    }
}
/* hat IS is it with that CancellationToken , in get Method argument at end ?
 * 
 * Method OverLoading vs method Overriding */
// vousbrillez-ca : Cegep de Ste Foy: intelligence d'Affaires et Mega-Donnees 
// other info: categor y cat, location loc, user user to passs to store 4 propagation !