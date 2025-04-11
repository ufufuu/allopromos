

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

        Task<IEnumerable<tOrder>> GetOrdersByStore(string storeId);

        Task<tOrder> GetOrderById(string productId);
    }
}
