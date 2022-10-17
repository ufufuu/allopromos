using allopromo.Core.Abstract;
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

        public TRepository(AppDbContext db)
        {
            _table = _dbContext.Set<T>();
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
        #endregion
    }
}
    //Generics : code reuse - type safety - performance - 
