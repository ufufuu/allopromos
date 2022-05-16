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
        //Task<tStore> GetStoreAsync(string storeId);
        //Task<tStore> GetStoreByIdAsync(string storeId);

        Task<IEnumerable<tStoreCategory>> GetStoreCategoriesAsync();
        Task<IEnumerable<tStore>> GetStoresByCategoryIdAsync(int categoryId);
        Task<IEnumerable<tStore>> GetStoresByCategoryIdAsync(int categoryId, int limitPerPage, int offSet);
        IEnumerable<tStore> GetStoresAsync();
        tStoreCategory AddCategory(tStoreCategory storeCategory);


        //Task<List<tStore>> GetStoresByCategoryIdAsync(string catId);
        //Task<List<tStore>> GetStoresByCatIdAsync(string catId);
    }
}








//services.AddScoped<IStoreRepository, allopromo.Infrastructure.Repositories.
//StoreRepository>();