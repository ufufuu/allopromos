using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Core.Abstract
{
    public interface IRepository<TEntity> where TEntity : class     
    {
        Task Add(TEntity obj);
        Task Add(TEntity obj, string imageUrl);
        Task Add(string obj, string imageUrl);
        void Update(TEntity obj);
        void Save();
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(object Id);
        Task<TEntity> GetByIdAsync(string Id);
        bool Delete(object Id);
        bool Delete(TEntity obj);


        IQueryable<TEntity> GetByIdAsync(int categoryId, int pageNumber, int offSet);
        
    }
}

