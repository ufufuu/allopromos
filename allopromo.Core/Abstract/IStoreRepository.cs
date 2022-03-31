using allopromo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace allopromo.Core.Abstract                   //?  Some Would Call it Domain 
{
    public interface IStoreRepository
    {
        Task<List<tStore>> GetStoresByIdAsync(string catId);
        Task<tStore> GetStoreAsync(string storeId);
        List<tStore> GetStoresAsync();
        tStore Add(tStore store);

        Task<List<tStore>> GetStoresByCatIdAsync(string catId);
        Task<tStore> GetStoreByIdAsync(string storeId);


        //List<tStore> GetStoresAsync();
        //tStore Add(tStore store);

        //tStore Read(tStore store);
        //tStore Update(tStore store);
        //tStore Delete(tStore store);
    }
}
//services.AddScoped<IStoreRepository, allopromo.Infrastructure.Repositories.
                //StoreRepository>();