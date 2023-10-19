using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace allopromo.Core.Abstract
{
    public interface IOrderService
    {
        Task<ProductCategoryDto> CreateOrder(ProductCategoryDto productCategoryDto);
        Task<ProductDto> CreateOrderAsync(ProductDto product, string Name);
        Task<IEnumerable<ProductDto>> GetOrdersByStore(string storeId);
        Task<ProductDto> GetOrderById(string productId);
        
    }
}
