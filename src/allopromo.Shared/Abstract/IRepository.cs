using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Shared.Abstract
{
    public interface IRepository<T> where T : class
    {
        Task Add(T obj);
        void Update(T obj);
        void Save();
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(object Id);
        void Delete(object Id);
    }
}
