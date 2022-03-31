using allopromo.Core.Abstract;
using FluentEmail.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
namespace allopromo.Core.Model
{
    public class NotificationService:INotificationService
    {
        private readonly IStoreService _storeService;
        private readonly FluentEmail.Core.IFluentEmail _email;
        public NotificationService(IStoreService storeService)
        {
            _storeService = storeService;
        }
        public bool StoreCreatedEventHandler(object source, EventArgs e)
        {
            var email = new FluentEmail.Core.Email();
            SendSingleEmail(email);
            return true;
        }
        public bool SendNotification()
        {
            _storeService.storeCreated += StoreCreatedEventHandler;
            _storeService.storeCreated += RaisesNotification;
            return true;
        }
        public bool RaisesNotification(object source, EventArgs e)
        {
            //Here Send SMS Notification ! - Iterfacing - Are SOLID principles followed - Decoupling 
            //FluentEmail.Smtp.SendMailEx.SendMailExAsync();
            //_email.S
            //then SignalR - Send Notifiation to Client
            var email = new FluentEmail.Core.Email();
            SendSingleEmail(email);
            return true;
        }
        private async Task<object> SendSingleEmail([FromServices] IFluentEmail singleEmail)
        {
            var email = singleEmail
                .To("test-email@allopromo.co")
                .Subject("Testing allopromom")
                .Body("Hit is A Single E-mail To Be Sent Out");
            await email.SendAsync();
            return true;
        }
        public async Task<object> SendMultipleEmails([FromServices] IFluentEmailFactory emailFactory)
        {
            var email1 = emailFactory
                .Create()
                .To("aliwiyao@gmail.com")
                .Subject("Testing Servies allopromo - Emailing")
                .Body(" Fucnking Testing Email");
            await email1.SendAsync();
            return true;
        }
    }
}
