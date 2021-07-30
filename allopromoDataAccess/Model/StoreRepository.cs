using allopromoDataAccess.Abstract;
using allopromoDataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace allopromoDataAccess.Model
{
    public class StoreRepository : IStoreRepository, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;
        
        public StoreRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Store> GetAllStores()
        {
            return _dbContext.Stores.AsQueryable().ToList();
        }

        public Store GetStoreById(string storeId)
        {
            return _dbContext.Stores.Find(storeId);
        }
        //public Store Insert(Store store)
        public void Insert(Store store)
        {
            store = new Store();
            //store.storeId = storeId;
            _dbContext.Stores.Add(store);
            Save();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        void IStoreRepository.Update(Store store)
        {
            throw new NotImplementedException();
        }

        void IStoreRepository.Delete(Store store)
        {
            throw new NotImplementedException();
        }

        
    }
}
