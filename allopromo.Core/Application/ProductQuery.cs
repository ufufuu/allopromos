using allopromo.Core.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using allopromo.Infrastructure.Repositories;
using allopromo.Core.Entities;
namespace allopromo.Core.Application
{
    public interface IProductQuery
    {
        Task<tProduct> GetStoreAsync(string productId);
        Task<tProduct> GetProductsByStoreIdAsync(string storeId);
        Task<tProduct> GetProductAsync(string id);
    }
    public class ProductQuery:IProductQuery
    {
        private allopromo.Core.Abstract.IProductRepository _productRepository;
        public ProductQuery(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<tProduct> GetStoreAsync(string id)
        {
                var query = _productRepository.GetProductAsync(id.ToString());
                if (query == null)
                    return null;
            return (tProduct)query.Result;
        }

        public async Task<tProduct> GetProductsByStoreIdAsync(string storeId)
        {
            if(storeId!=null)
                return await _productRepository.GetProductsByStoreIdAsync(storeId);
            return null;
        }

        public Task<tProduct> GetProductAsync(string id)
        {
            return null;
        }

        // ???? Convrt List of Anomynmos to List of Type T?

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
}
