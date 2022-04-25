using allopromo.Core.Abstract;
using allopromo.Core.Entities;
using allopromo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace allopromo.Infrastructure.Abstract
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;
        private DbSet<T> _table;
        public GenericRepository()
        {
            //_dbContext = new AppDbContext();
            _table = _dbContext.Set<T>();
        }
        public GenericRepository(AppDbContext dbContext, DbSet<T> table)
        {
            _dbContext = dbContext;
            _table = table;
        }
        public void Add(T obj)
        {
            _table.Add(obj);
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
    }
}
