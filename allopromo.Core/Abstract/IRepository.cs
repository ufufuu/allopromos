using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using System.Collections.Generic;
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
        void Delete(object Id);


        Task<TEntity> GetByIdAsync(int categoryId, int pageNumber, int offSet);
        Task<TEntity> GetByIdAsync(int categoryId); 


        Task<ProductDto> CreateProductAsync(tProduct product);
        Task<ProductDto> GetProductAsync(string productId);
        Task<IEnumerable<ProductDto>> GetProductsByStoreIdAsync(string Id);

        void DeleteStoreCategory(TEntity obj);
    }
}

