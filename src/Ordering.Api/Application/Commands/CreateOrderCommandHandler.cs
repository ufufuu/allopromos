//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

////Implementer la couche Application
////des microservices
////avec l'API Web


//namespace Ordering.Api.Application.Commands
//{
//    public class CreateOrderCommandHandler
//        //:IRequestHandler<CreateOrderCommand, bool> from mediatR // ? Command pattern Handler *
//    {
//        private readonly IOrderRepository _orderRepository;
//        private readonly IIdentityService _identyService;
//        private readonly IMediator _mediator;
//        private IOrderingIntegrationEventService _orderingIntegrationServiceEventService;
//        private readonly ILogger<CreateOrderCommandHandler> _logger;
//    }

//    public class CreateOrderCommand: IRequest<bool>
//    {
//List<OrderItemDto> _orderItems;
//public string UserId { get; private set; } // ...Name, city , street, state, country, zipcode, 
//[DataMember]
//public string CarNumber { get; private set; } //card holderName,  card Expiration , cvc 

//    }

// public class UpdateOrderCommand: IRequest<bool>
//}
//OrderItemDto{ public int productId, prodName, unitPrice, Discount, Units, pictureUrl public string }}