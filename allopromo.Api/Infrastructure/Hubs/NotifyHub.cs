using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
namespace allopromo.Api.Infrastructure.Hubs
{
    public class NotifyHub:Hub
    {
        public async Task SendMessage(string userName, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", userName, message);
        }
    }
}