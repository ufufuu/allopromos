using allopromo.Core.Entities;
using allopromo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace allopromo.Infrastructure.Repositories
{
    public class ProductRepository//: IEntityBaseRepository
    {
        public async Task<List<tProduct>> GetProductsAsync(string storeId)
        {
            //using (var db = new AppDbContext())
            //{
            //    var products= db.Products
            //         .Where(x => x.storeId == storeId)
            //         .ToListAsync();
            //    return await products;
            //}
            return null;
        }
        public async Task<tProduct> GetProductAsync(string id)
        {
            //using(var db = new AppDbContext())
            //{
            //    return db.Products
            //        .Where(x => x.storeId == id)
            //        .FirstOrDefault();
            //}
            return null;
        }
    }
}
