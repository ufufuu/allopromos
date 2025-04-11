using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
namespace allopromo.Api.Infrastructure.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendConnectionId(string connectionId)
        {
            await this.Clients.All.SendAsync("setClientMessage", (object)("Aconnection with ID " + connectionId + "  has just connected"));
        }

        public async Task SendMessage(string message)
        {
            await this.Clients.All.SendAsync("ReceiveMessage", (object)message);
        }

        public async Task SendMessageUse(string user, string message)
        {
            await this.Clients.All.SendAsync("ReceiveMessage", (object)user, (object)message);
        }
    }
}