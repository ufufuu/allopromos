

using allopromo.Api.Infrastructure.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

#nullable disable
namespace allopromo.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private IHubContext<MessageHub, IMessageHubClient> messageHub { get; set; }

        public MessageController(
          IHubContext<MessageHub, IMessageHubClient> _messageHub)
        {
            this.messageHub = _messageHub;
        }

        [Route("inbox")]
        [HttpPost]
        public string Post()
        {
            this.messageHub.Clients.All.SendOffersToUser(new List<string>()
      {
        "hello Offer 1",
        "hello Offer 2",
        "hello Offer 2"
      });
            return "Offers Sent Successfully to All Users";
        }
    }
}
