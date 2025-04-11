using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private Microsoft.AspNetCore.SignalR.IHubContext<Api.Infrastructure.Hubs.MessageHub,
            Api.Infrastructure.Hubs.IMessageHubClient> messageHub { get; set; }
        public MessageController(
            Microsoft.AspNetCore.SignalR.IHubContext<Api.Infrastructure.Hubs.MessageHub,
                Api.Infrastructure.Hubs.IMessageHubClient> _messageHub)
        {
            messageHub = _messageHub;
        }
        [Route("inbox")]
        [HttpPost]
        public string Post()
        {
            List<string> message = new List<string>();
            message.Add("hello Offer 1");
            message.Add("hello Offer 2");
            message.Add("hello Offer 2");
            messageHub.Clients.All.SendOffersToUser(message);

            return "Offers Sent Successfully to All Users";
        }
    }
}
