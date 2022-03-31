using allopromo.Infrastructure.Data.Entities;
using allopromo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using allopromo.Core.Application.Interface;
//namespace allopromo.Core.Abstract
namespace allopromo.Infrastructure.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly AppDbContext _dbContext;

        //public StoreRepository()
        //{
        //    _dbContext = new AppDbContext();
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
            if (_dbContext != null)

                _dbContext.Stores.Add(store);
            int r = 6;
            _dbContext.SaveChanges();
            return store;
        }
        public async Task<List<tStore>> GetStoresByIdAsync(string catId) //GetStoresByIdAsync
        {
            return await _dbContext.Stores
                .Where(x => x.storeId == catId).ToListAsync();
        }
        public List<tStore> GetStoresAsync()
        {
            var stores = _dbContext.Stores.AsQueryable().ToList();
            int y = 5;
            return stores;
        }
        public async Task<tStore> GetStoreAsync(string Id)
        {
            var store = _dbContext.Stores
            .Where(x => x.userId == Id.ToString()).FirstOrDefault();
            if (store != null)
                return store;
            return null;
        }
        private async Task<AppDbContext> GetDatabaseContext()
        {
            return null;
        }
        //void IStoreRepository.Update(Store store)
        void Update(tStore store)
        {
            throw new NotImplementedException();
        }
        //void IStoreRepository.Delete(Store store)
        void Delete(tStore store)
        {
            throw new NotImplementedException();
        }
    }
}
