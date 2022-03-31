using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using allopromo.Core.Abstract;
using allopromo.Core.Infrastructure.Abstract;
using MailKit.Net;
using MailKit.Net.Smtp;
using MimeKit;
namespace allopromo.Core.Infrastructure
{
    public class EmailService:IEmailService
    {
        public readonly IEmailConfiguration _emailConfiguration;
        public EmailService()
        {
        }
        public EmailService(IEmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }
        //public bool SendEmailMessage(EmailMessage emailMessage, string userEmail)
        public EventHandler<UserAuthenticateEventArgs> SendEmailMessage(EmailMessage emailMessage, string userEmail)
        {
            //MailKit.Net.Pop3.Pop3Client
            emailMessage = new EmailMessage();
            var message = new MimeMessage();
            message.To.AddRange(emailMessage.ToAdresses
                .Select(x => new MailboxAddress(x.userName, x.userAdress)));
            message.Subject = emailMessage.messageSubject;
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = emailMessage.messageContent,
            };
            //using(var emailClient = new FluentEmail.Smtp.SmtpSender())
            using (var emailClient = new SmtpClient())
            {
                //The last parameter here is to use SSL (Which you should!)
                emailClient.Connect(_emailConfiguration.smtpServer, _emailConfiguration.smtpPort, true);

                //Remove any OAuth functionality as we won't be using it.
                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                emailClient.Authenticate(_emailConfiguration.smtpUsername, _emailConfiguration.smtpPassword);
                emailClient.Send(message);
                emailClient.Disconnect(true);
                return null;
            }
            //return false;
        }
    }
}
