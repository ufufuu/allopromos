using allopromo.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Core.Abstract
{
    public interface IRepository<TEntity> where TEntity : class     
    {
        #region Create
        void Add(TEntity obj);
        Task Add(TEntity obj, string imageUrl);
        Task Add(string obj, string imageUrl);
        #endregion

        #region Read
        Task<List<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetEntitiesAsync();
        Task<TEntity> GetByIdAsync(object Id);
        Task<TEntity> GetByIdAsync(int categoryId);
        Task<TEntity> GetByIdAsync(string categoryId);
        IQueryable<TEntity> GetByIdAsync(int categoryId, int pageNumber, int offSet);
        #endregion

        #region Update
        void Update(TEntity obj);
        void Save();
        #endregion

        #region Delete
        bool Delete(object Id);
        void Delete(TEntity obj);
        #endregion
    }
}

