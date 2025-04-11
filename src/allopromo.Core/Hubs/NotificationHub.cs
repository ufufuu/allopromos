using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
namespace allopromo.Core.Hubs
{

    public class NotificationHub:Hub<Abstract.Interfaces.INotificationHubClient>
    {
        public async Task SendOffersToUser(List<string> message)
        {
            await Clients.All.SendNotifcationsToUser(new List<string>());
        }
        public async Task SendMessage(string userName, string message)
        {
            await Clients.All.SendNotificationToUsers();
        }
        public async Task SendNotification(string userName, string message)
        {
            await Clients.All.SendNotificationToUser();
        }
    }

    public class NotifyHub : Hub
    {}
}