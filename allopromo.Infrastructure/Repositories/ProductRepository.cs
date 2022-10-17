using allopromo.Core.Abstract;
using allopromo.Core.Application.Dto;
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
    public class ProductRepository //:IEntityBaseRepository
        : IProductRepository
    {
        public async Task<tProduct> CreateAsync(tProduct product)
        {
            tProduct tproduct = null;
            using (var db = new AppDbContext())
            {
                db.Products.Add(tproduct);
            }
            return tproduct;
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
        public async Task<List<tProduct>> GetProductsAsync(string storeId)
        {
            using (var db = new AppDbContext())
            {
                var products = db.Products
                     .Where(x => x.storeId == storeId)
                     .ToListAsync();
                return await products;
            }
        }
        public Task<tProduct> GetProductsByStoreIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
