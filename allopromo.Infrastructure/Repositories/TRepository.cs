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
    public class TRepository<T> : IRepository<T> where T : class        /// Unit of Work ?
    {
        #region fields
        private readonly AppDbContext _dbContext;
        private DbSet<T> _table;
        #endregion
        #region Public Method
        public TRepository(AppDbContext dbContext)
        {
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
            if (obj != null)
            {
                _dbContext.Entry<T>(obj);
                this.Save();
                return obj as Task;
            }
            throw new  NullReferenceException();
        }
        Task IRepository<T>.Add(T obj, string imageUrl)
        {
            if (obj == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                _dbContext.Add(obj);
            }
            return Task.FromResult(obj);
        }
        Task IRepository<T>.Add(string obj, string imageUrl)
        {
            if (obj == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                _dbContext.Add(obj);
            }
            return Task.FromResult(obj);
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
        public Task<List<T>> GetAllAsync() ////Task<List<T>> IRepository<T>.GetAllAsync()
        {
            return _table.ToListAsync();
        }
        Task<T> IRepository<T>.GetByIdAsync(int categoryId, int pageNumber, int offSet)
        {
            throw new NotImplementedException();
        }
        public async Task<T> GetByIdAsync(int Id)
        {
            return await _table.FindAsync(Id);
        }
        public bool Delete(object Id) //void IRepository<T>.Delete(object Id)
        {
            T obj = _table.Find(Id);
            _table.Remove(obj);
            return true;
        }
        void IRepository<T>.Update(T obj)
        {
            throw new NotImplementedException();
        }
        Task<T> IRepository<T>.GetByIdAsync(object Id)
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
        void IRepository<T>.DeleteStoreCategory(T obj)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}//Generics : code reuse - type safety - performance - 
