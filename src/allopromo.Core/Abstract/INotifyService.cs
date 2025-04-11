using allopromo.Core.Events;
using allopromo.Core.Infrastructure;
//using allopromo.Core.Model.ApiResponse;
using System;
using System.Threading.Tasks;
namespace allopromo.Core.Abstract
{
    public interface INotifyService
    {
        public bool StoreCreatedEventHandler(object source, EventArgs e)
        {
            return true;
        }
        bool SendNotification();
        //Task<ApiResponseModel> SendNotification(NotificationModel notificationModel);
    }
    public interface ISmsNotificationService
    {
        //public EventHandler<UserAuthenticateEventArgs> SendEmailMessage(EmailMessage emailMessage, string userEmail);
        public EventHandler<UserAuthenticatedEventArgs> SendEmailMessage(string emailMessage, string userEmail);
    }
}