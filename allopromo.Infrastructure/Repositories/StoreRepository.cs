using allopromo.Core.Abstract;
using allopromo.Core.Entities;
using allopromo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Infrastructure.Repositories
{
    public class StoreRepository:
        IStoreRepository
    {
        private readonly AppDbContext _dbContext;
        //public StoreRepository()
        //{
        //}
        public StoreRepository(AppDbContext dbContext)
            => _dbContext = dbContext;
        public tStore Add(tStore store)
        {
            store = new tStore();
            store.storeId = Guid.NewGuid().ToString();
            store.storeName = store.storeName;
            store.storeCreatedOn = DateTime.Now.Date;
            store.storeBecomesInactiveOn = DateTime.Now.AddMonths(6).Date;
            store.storeDescription = "ZZAAZ";
            store.userId = "1ec20d6f-e844-4865-b275-9c08a3249619";
            tStoreCategory tCategory = new tStoreCategory {storeCategoryName = "Epiceries" };
            _dbContext.StoreCategories.Add(tCategory);
            store.storeCategory = tCategory;
            //tCategory.tStores.Add(store);
            int e = 7;
            //store.storeCategoryId = 1;
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
                .Where(x => x.userId == Id.ToString()).FirstOrDefault();
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
            var stores = from q in _dbContext.Stores.Where(x => x.storeCategoryId == categoryId)
                         .AsNoTracking()
                         select q;
            return await stores.ToListAsync();
        }
        public async Task<IEnumerable<tStore>> GetStoresByCategoryIdAsync(int categoryId, int offSet, int limitPerPage)
        {
            var stores = from q in _dbContext.Stores.Where(x => x.storeCategoryId == categoryId)
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
