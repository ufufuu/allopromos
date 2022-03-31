using allopromo.Core.Infrastructure;
using System;
namespace allopromo.Core.Abstract
{
    public interface IEmailService
    {
        public EventHandler<UserAuthenticateEventArgs> SendEmailMessage(EmailMessage emailMessage, string userEmail);
    }
}
