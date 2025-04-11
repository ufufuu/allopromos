using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Api.Infrastructure.Mapping.Profiles
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            this.CreateMap<OrderDto, Order>().ForMember<int>((Expression<Func<Order, int>>)(vm => vm.orderDate), (Action<IMemberConfigurationExpression<OrderDto, Order, int>>)(map => map.MapFrom<string>((Expression<Func<OrderDto, string>>)(m => m.OrderId))));
        }
    }
}

