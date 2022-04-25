using allopromo.Core.Infrastructure;
using System;
namespace allopromo.Core.Abstract
{
    public interface ISmsNotificationService
    {
        public EventHandler<UserAuthenticateEventArgs> SendEmailMessage(EmailMessage emailMessage, string userEmail);
    }
}
