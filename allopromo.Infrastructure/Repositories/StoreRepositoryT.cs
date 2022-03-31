using allopromo.Data.Entities;
using allopromo.Infrastructure.Abstract;
using allopromo.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Infrastructure.Data.Repositories
{
    public class StoreRepositoryX
    {
        public async Task<tStore> GetStoreAsync(string id)
        {
            using (var db = new AppDbContext())
            {
                var store = db.Stores.FindAsync()
                    .Result;
                return store;
            }
        }
    }
    public class StoreRepositoryR:IStoreRepository     //, EntityBaseRepository
    {
        private readonly AppDbContext _dbContext;
        public StoreRepositoryR()
        {
            _dbContext = new AppDbContext();
        }
        public StoreRepositoryR(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<tStore> GetStoresA()
        {
            var stores = _dbContext.Stores.AsQueryable().ToList();
            int y = 5;
            return stores;
        }
        public void GetStoreByIdAsync(string storeId)
        {
            //return _dbContext.Stores.Find(storeId);
        }
        //public Store Insert(Store store)
        public void Insert(tStore store)
        {
            store = new tStore();
        }
        //void IStoreRepository.Update(Store store)
        void Update(tStore store)
        {
            throw new NotImplementedException();
        }
        void Delete(tStore store)
        {
            throw new NotImplementedException();
        }
    }
    //public interface IStoreRepository
    //{
    //    Task<List<tStore>> GetStoresByIdAsync(string catId);
    //    Task<tStore> GetStoreAsync(string storeId);
    //    List<tStore> GetStoresAsync();
    //    tStore Add(tStore store);
    //}
}
