using allopromo.Infrastructure.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
//namespace allopromo.Core.Abstract
namespace allopromo.Infrastructure.Abstract
{
    public interface IStoreRepository
    {
        Task<List<tStore>> GetStoresByIdAsync(string catId);
        Task<tStore> GetStoreAsync(string storeId);
        List<tStore> GetStoresAsync();
        tStore Add(tStore store);
    }
}
