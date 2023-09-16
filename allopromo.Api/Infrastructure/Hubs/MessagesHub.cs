using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Api.Infrastructure.Hubs
{
    public interface IMessageHubClient
    {
        Task SendOffersToUser(List<string> messages);
    }
    public class MessagesHub: Microsoft.AspNetCore.SignalR.Hub<IMessageHubClient>
    {
        public async Task SendOffersToUser(List<string> message)
        {
            await Clients.All.SendOffersToUser(message);
        }
    }
}
