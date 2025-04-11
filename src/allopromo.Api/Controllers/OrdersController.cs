// Decompiled with JetBrains decompiler
// Type: allopromo.Api.Controllers.OrdersController
// Assembly: allopromo.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9E70BF9-6813-49CA-B8B2-EE280C9B986F
// Assembly location: C:\Users\MonPC\Downloads\allopromo.Api.dll

using allopromo.Api.DTOs;
using allopromo.Core.Abstract;
using allopromo.Core.Hubs;
using allopromo.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

#nullable disable
namespace allopromo.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly INotifyService _notifyService;
        private IOrderService _orderService;
        private readonly IShippingService shippingService;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        private NotificationHub _notificationHub { get; set; }

        public OrdersController(IMapper mapper) => this._mapper = mapper;

        [HttpPost]
        public IActionResult Post()
        {
            this._notificationHub.SendMessage("Hello Baby");
            return (IActionResult)this.Ok((object)"hey");
        }

        [HttpGet]
        [Route("customerId")]
        public IActionResult GetOrders(string customerId)
        {
            return customerId == null ? (IActionResult)this.NoContent() : (IActionResult)this.Ok((object)this._mapper.Map<IEnumerable<OrderDto>>((object)this._orderService.GetOrdersByCustomerId(customerId)));
        }

        [HttpGet]
        [Route("{orderId}")]
        [ActionName("Details")]
        public IActionResult GetDetails(string orderId) => (IActionResult)this.Ok();

        [HttpGet]
        [Route("invoicing/{invoiceId}")]
        public IActionResult GetPdfInvoice(string invoiceId)
        {
            return (IActionResult)this.Ok((object)invoiceId);
        }

        [HttpPut]
        [Route("cancel-order/{orderId}")]
        public IActionResult CancelOrder(string orderId) => (IActionResult)this.Ok();
    }
}


/*
 * CQRS : Commmands - Queries - Handlers 


















//https://stackoverflow.com/questions/4181198/how-to-hash-a-password

// 6/ Test React - Login Automation

// 3- Resiliency , login, auth, crating store <- mediatR or other Patterns !

// 4 - Caching 
// 5 - MVC Super Admin,  Admin
// 7 - store Type : store just or restaurant ? integration abstract , interface -> solid principles
// 8 - DesJardins Courtage en Ligne | AMF ?
// 9 , 2- Odoo Infrastucture integrated - Delivery Order ????


// 1 -  store status | enum ? , struct, | ensure User Status
// 2/ 10 - Integrage Identity Server in Infrastructure

// Onion | Clean Architecture Notes
/* project Root is the Startup or ConfigureServices. where Infrastructure project is referenced
 * and not anywhere else
*/