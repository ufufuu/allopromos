using System.Collections.Generic;
using System.Threading.Tasks;
namespace allopromo.Core.Abstract
{
    public interface IGenericRepository<T> where T:class
    {
        void Add(T obj);
        void Update(T obj);
        void Save();
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(object Id);
        void Delete(object Id);
    }
}
