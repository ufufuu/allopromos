using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.Services
{
    public class OrderService
    {
    //    public event EventHandler<OrderPlacedEventArgs> OrderPlaced;
    //    public void PlaceOrder()
    //    {
    //        OrderPlaced?.Invoke(this, new OrderPlacedEventArgs());
    //    }
    }
    public enum OrderStatus
    {
        OrderMade,
        OrderAknowledged,
        OrderReused,
        OrderStarted,
        OrderComplete,
        OrderDelivered,
    }
}
