using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace allopromo.Core.Abstract
{
    public interface IProductService
    {
        Task<ProductDto> CreateAsync(tProduct product);
        Task<IEnumerable<ProductDto>> GetProductsByStore(string storeId);
        Task<ProductDto> GetProductById(string productId);
        Task<IEnumerable<ProductDto>> GetProductsByStore();
        Task<IEnumerable<ProductDto>> GetProductsByCategoryId(string id);
    }
}
