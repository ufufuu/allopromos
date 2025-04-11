
using allopromo.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Core.Services
{
    public class NotificationService : Abstract.INotifyService
    {
        public Microsoft.AspNetCore.SignalR.IHubContext <Hubs.NotificationHub, INotificationHubClient> 
            notificationHub { get; set; }
        public NotificationService()
        {
        }
        public bool SendNotification(object source, EventArgs e)
        {
            throw new NotImplementedException();
        }
        //public bool SendNotification(object source, Model.StoreCreatedEventArgs e)
        public bool SendNotification(int Id)
        {
            //var name = e.store;
            notificationHub.Clients.All.SendNotifcationsToUser(new List<string>());
            return true;
        }

        //public Task<ApiResponseModel> SendNotification(NotificationModel notificationModel)
        public void SendNotification(string message)
        {
            throw new NotImplementedException();
        }

        public bool SendNotification()
        {
            throw new NotImplementedException();
        }
    }
}
