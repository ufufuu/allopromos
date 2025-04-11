using System;
using System.Collections.Generic;
using System.Text;
namespace allopromo.Core.Abstract
{
    public interface IUnitofWork
    {
        //private IRepository<TEntity>

        void Save();
    }
}

//public interface IProductRepository
//{
//    //MTAThreadAttribute<>

//    Task<tProduct> CreateAsync(tProduct product);
//    Task<tProduct> GetProductAsync(string id);
//    Task<tProduct> GetProductsByStoreIdAsync(string id);
//}