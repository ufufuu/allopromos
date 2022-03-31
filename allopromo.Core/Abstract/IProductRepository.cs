using allopromo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace allopromo.Core.Abstract
{
    public interface IProductRepository
    {
        //MTAThreadAttribute<>
        Task<tProduct> GetProductAsync(string id);
        //Task<tProduct> GetProductAsync(string id);
        Task<tProduct> GetProductsByStoreIdAsync(string id);
    }
}
