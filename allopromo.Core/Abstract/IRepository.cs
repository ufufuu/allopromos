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
        Task<TEntity> GetByIdAsync(int categoryId);
        Task<TEntity> GetByIdAsync(string categoryId);

        bool Delete(object Id);
        void Delete(TEntity obj);

        IQueryable<TEntity> GetByIdAsync(int categoryId, int pageNumber, int offSet);

        /*Task<ProductDto> CreateProductAsync(tProduct product);
        Task<ProductDto> GetProductAsync(string productId);
        
        Task<IEnumerable<ProductDto>> GetProductsByStoreIdAsync(string Id);
        */
    }
}

