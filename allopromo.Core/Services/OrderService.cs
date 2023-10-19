using allopromo.Core.Abstract;
using allopromo.Core.Application.Dto;
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
        Task<ProductCategoryDto> IOrderService.CreateOrder(ProductCategoryDto productCategoryDto)
        {
            throw new NotImplementedException();
        }

        Task<ProductDto> IOrderService.CreateOrderAsync(ProductDto product, string Name)
        {
            throw new NotImplementedException();
        }

        Task<ProductDto> IOrderService.GetOrderById(string productId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ProductDto>> IOrderService.GetOrdersByStore(string storeId)
        {
            throw new NotImplementedException();
        }
    }
    
}
