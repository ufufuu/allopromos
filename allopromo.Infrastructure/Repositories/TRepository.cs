using allopromo.Core.Abstract;
using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using allopromo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Infrastructure.Repositories
{
    public class TRepository<T> : IRepository<T> where T : class
    {
        #region fields
        private readonly AppDbContext _dbContext;
        private DbSet<T> _table;
        #endregion
        #region Public Method

        public TRepository(AppDbContext dbContext)
        {

            int y = 5;
            //_table = _dbContext.Set<T>();
            _dbContext = dbContext;

            _table = dbContext.Set<T>();
        }
        public TRepository(AppDbContext dbContext, DbSet<T> table)
        {
            _dbContext = dbContext;
            _table = table;
        }
        public Task Add(T obj)
        {
            _table.Add(obj);
            return obj as Task;
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public void Update(T obj)
        {
            _table.Attach(obj);
            _dbContext.Entry(obj).State = EntityState.Modified;
        }
        public Task<List<T>> GetAllAsync()
        {
            return _table.ToListAsync();
        }
        public async Task<T> GetByIdAsync(object id)
        {
            return await _table.FindAsync(id);
        }
        public void Delete(object Id)
        {
            T existing = _table.Find(Id);
            _table.Remove(existing);
        }

        Task IRepository<T>.Add(T obj)
        {
            throw new NotImplementedException();
        }

        void IRepository<T>.Update(T obj)
        {
            throw new NotImplementedException();
        }

        void IRepository<T>.Save()
        {
            throw new NotImplementedException();
        }

        Task<List<T>> IRepository<T>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<T> IRepository<T>.GetByIdAsync(object Id)
        {
            throw new NotImplementedException();
        }

        void IRepository<T>.Delete(object Id)
        {
            throw new NotImplementedException();
        }

        Task<ProductDto> IRepository<T>.CreateProductAsync(tProduct product)
        {
            throw new NotImplementedException();
        }

        Task<ProductDto> IRepository<T>.GetProductAsync(string productId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ProductDto>> IRepository<T>.GetProductsByStoreIdAsync(string Id)
        {
            throw new NotImplementedException();
        }

        Task IRepository<T>.Add(T obj, string imageUrl)
        {
            throw new NotImplementedException();
        }

        Task IRepository<T>.Add(string obj, string imageUrl)
        {
            throw new NotImplementedException();
        }

        Task<T> IRepository<T>.GetByIdAsync(int categoryId, int pageNumber, int offSet)
        {
            throw new NotImplementedException();
        }

        Task<T> IRepository<T>.GetByIdAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        void IRepository<T>.DeleteStoreCategory(T obj)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}//Generics : code reuse - type safety - performance - 
