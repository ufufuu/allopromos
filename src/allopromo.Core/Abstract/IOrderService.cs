

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
        //Task<tOrder> CreateOrderAsync(tOrder order, string Name);

        Task<IEnumerable<Order>> GetOrdersByStore(string storeId);

        Task<Order> GetOrderById(string productId);
    }
}
