using allopromo.Core.Application.Dto;
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

        Task<tProduct> CreateAsync(tProduct product);
        Task<tProduct> GetProductAsync(string id);
        Task<tProduct> GetProductsByStoreIdAsync(string id);
    }
}
