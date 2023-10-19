using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace allopromo.Core.Abstract.Interfaces
{
    public interface INotificationHubClient
    {
        Task SendNotifcationsToUser(List<string> messages);
        public Task SendNotificationToUsers();
        public Task SendNotificationToUser();
    }
}
