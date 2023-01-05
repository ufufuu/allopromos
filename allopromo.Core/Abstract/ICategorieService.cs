using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace allopromo.Core.Abstract
{
    public interface ICategorieService
    {
        Task<Application.Dto.StoreCategoryDto> CreateStoreCategoryAsync(StoreCategoryDto category);
        Task<IEnumerable<StoreCategoryDto>> GetStoreCategoriesAsync();
        Task<StoreCategoryDto>  GetStoreCategoryAsyncById(string Id);
        tStoreCategory GetCategoryById(string id);
        Task<string> GetImageUrl();
        public void UpdateStoreCategory(string Id, StoreCategoryDto categoryDto);

        void DeleteStoreCategory(StoreCategoryDto storeCategoryDto);
        void DeleteStoreCategory(string categoryId);
        
    }
}