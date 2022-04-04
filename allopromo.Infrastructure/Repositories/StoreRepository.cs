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
    public class StoreRepository: //allopromo.Core.Abstract.
        IStoreRepository
    {
        private readonly AppDbContext _dbContext;
        public StoreRepository()
        {
            //_dbContext = new AppDbContext();
        }
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
        public async Task<tStore> GetStoreByIdAsync(string Id)
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

        Task<List<tStore>> IStoreRepository.GetStoresByCatIdAsync(string catId)
        {
            throw new NotImplementedException();
        }

        Task<tStore> IStoreRepository.GetStoreByIdAsync(string storeId)
        {
            throw new NotImplementedException();
        }

        List<tStore> IStoreRepository.GetStoresAsync()
        {
            throw new NotImplementedException();
        }

        Task<List<tStore>> IStoreRepository.GetStoresByIdAsync(string catId)
        {
            throw new NotImplementedException();
        }

        public Task<tStore> GetStoreAsync(string storeId)
        {
            throw new NotImplementedException();
        }

        public Task<List<tStore>> GetStoresByCatIdAsync(string catId)
        {
            throw new NotImplementedException();
        }
    }
}
