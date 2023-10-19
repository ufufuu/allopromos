using allopromo.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Core.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(int bsketId, Address shippingAdress);
    }
}
