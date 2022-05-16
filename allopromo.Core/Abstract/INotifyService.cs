using allopromo.Core.Infrastructure;
using allopromo.Core.Model.ApiResponse;
using System;
using System.Threading.Tasks;
namespace allopromo.Core.Abstract
{
    public interface INotifyService
    {
        public bool StoreCreatedEventHandler(object source, EventArgs e)//(string msg, int userId)
        {
            return true;
        }
        bool SendNotification();
        Task<ApiResponseModel> SendNotification(NotificationModel notificationModel);
    }
    public interface ISmsNotificationService
    {
        public EventHandler<UserAuthenticateEventArgs> SendEmailMessage(EmailMessage emailMessage, string userEmail);
    }
}