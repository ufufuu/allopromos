using allopromo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace allopromo.Core.Abstract                   //?  Some Would Call it Domain 
{
    public interface IStoreRepository
    {
        void Save();
        tStore Add(tStore store);
        Task<IEnumerable<tStoreCategory>> GetStoreCategoriesAsync();
        Task<IEnumerable<tStore>> GetStoresByCategoryIdAsync(int categoryId);
        Task<IEnumerable<tStore>> GetStoresByCategoryIdAsync(int categoryId, int limitPerPage, int offSet);
        IEnumerable<tStore> GetStoresAsync();

        tStoreCategory AddStoreCategory(string storeCategoryName, string imageUrl);

        void DeleteStoreCategory(tStoreCategory storeCategory);
        Task<tStoreCategory> GetStoreByIdAsync(string storeId);




        //Task<List<tStore>> GetStoresByCategoryIdAsync(string catId);
        //Task<List<tStore>> GetStoresByCatIdAsync(string catId);

        //Task<tStore> GetStoreAsync(string storeId);
        //Task<tStore> GetStoreByIdAsync(string storeId);
    }
}






//services.AddScoped<IStoreRepository, allopromo.Infrastructure.Repositories.
//StoreRepository>();