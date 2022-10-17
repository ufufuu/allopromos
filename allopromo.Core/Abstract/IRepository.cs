using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace allopromo.Core.Abstract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Add(TEntity obj);
        void Update(TEntity obj);
        void Save();
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(object Id);
        void Delete(object Id);


        Task<ProductDto> CreateProductAsync(tProduct product);
        Task<ProductDto> GetProductAsync(string productId);
        Task<IEnumerable<ProductDto>> GetProductsByStoreIdAsync(string Id);
    }
}

