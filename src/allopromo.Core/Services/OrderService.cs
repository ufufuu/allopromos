using allopromo.Core.Abstract;
using allopromo.Core.Entities;

//using allopromo.Core.Application.Dto;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Core.Services
{
    public class OrderService : allopromo.Core.Abstract.IOrderService
    {
        //    public event EventHandler<OrderPlacedEventArgs> OrderPlaced;
        //    public void PlaceOrder()
        //    {
        //        OrderPlaced?.Invoke(this, new OrderPlacedEventArgs());
        //    }

        //Task<ProductCategoryDto> IOrderService.CreateOrder(ProductCategoryDto productCategoryDto)
        //{
        //    throw new NotImplementedException();
        //}

        public Task CreateOrderAsync(Entities.Product product, string Name)
        {
            throw new NotImplementedException();
        }

        public Task<Entities.Order> GetOrderById(string productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetOrdersByStore(string storeId)
        {
            throw new NotImplementedException();
        }
    }
    
}
