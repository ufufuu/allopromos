using allopromo.Core.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using allopromo.Core.Application.Dto;
using allopromo.Core.Helpers.Convertors;
using allopromo.Core.Entities;
namespace allopromo.Core.Application
{
    public interface IStoreQuery
    {
        Task<tStore> GetStoreByIdAsync(string Id);
        Task<IEnumerable<tStore>> GetStoresByCatIdAsync(string catId);
        StoreDto CreateStore(StoreDto store);
    }
    public class StoreQuery//:IStoreQuery
    {
        private IStoreRepository _storeRepository;
        public StoreQuery(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public StoreDto CreateStore(StoreDto store)
        {
            if(store!=null)
                _storeRepository.Add(new StoreConvertor().Convert(store));
            return null;
        }

        //public async Task<tStore> GetStoreByIdAsync(string id)
        //{
        //        var query = await _storeRepository.GetStoreAsync(id);
        //        if (query == null)
        //            return null;
        //        return  query as tStore;
        //}
        //public async Task<IEnumerable<tStore>> GetStoresByCatIdAsync(string catId)
        //{
        //    if (catId == null)
        //        return null;
        //    return await _storeRepository.GetStoresByIdAsync(catId);
        //}
        //public async Task<tStore> GetStoresAsync(string usersRole)
        //{
        //    using (var db = new AppDbContext())
        //    {
        //        var queryUsers = from s in db.Users select s;

        //        var query43= from s in db.Stores
        //                    join u in db.Users
        //                    on s.userId equals u.Id
        //                    select new StoreOwners
        //                    {
        //                        StoreName = s.storeName,
        //                        StoreChef = u.userName
        //                    };

        //        var query469= from u in db.Users// Users ->UserRoles =>Roles : Pct=>ct=>Ta
        //                    join ur in db.UserRoles
        //                    on u.Id equals ur.UserId
        //                    where ur.Role.Equals(usersRole)

        //                    join r in db.Roles
        //                    on ur.RoleId equals r.Id
        //                    select new RolesUserss
        //                    {
        //                        userName = u.userName,
        //                        userRole = r.Name
        //                    };

        //        var query88 = db.Users
        //                    .Join(db.UserRoles, u => u.Id, ur => ur.UserId,
        //                    (u, ur) => new { });

        //        var query = db.Users
        //                    .Join(db.UserRoles, u => u.Id, ur => ur.UserId, 
        //                        (u, ur)=>new {u, ur})
        //                    .Join(db.Roles, r=>r.ur.RoleId, z=>z.Id,
        //                    (ur,z)=>new {})
        //                    .Select(m => new
        //                        tStore{
        //                        });


        //        return query.FirstOrDefault(); //.ToList();
        //    }
        //}
    }
    public class StoreOwners
    {
        public string StoreName { get; set; }
        public string StoreChef { get; set; }
    }
    public class RolesUserss
    {
        public string userName { get; set; }
        public string userRole { get; set; }
    }
}
// ???? Convrt List of Anomynmos to List of Type T?




// IUnitOfWork uO, IStore _sQ, ILogger<