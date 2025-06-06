﻿using allopromo.Core.Abstract;
//using allopromo.Core.Model.ApiResponse;
using FluentEmail.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
namespace allopromo.Core.Model
{

    public class EmailNotificationService23
    {
        private readonly
#nullable disable
    IStoreService _storeService;

        public EmailNotificationService(IStoreService storeService)
        {
            this._storeService = storeService;
        }

        public bool RaisesEmailEventHandler(object source, EventArgs e)
        {
            this.SendSingleEmail((IFluentEmail)new Email());
            return true;
        }

        public bool SendNotification()
        {
            this._storeService.StoreCreated += new StoreCreatedEventHandler(this.RaisesEmailEventHandler);
            return true;
        }

        private async Task<object> SendSingleEmail([FromServices] IFluentEmail singleEmail)
        {
            SendResponse sendResponse = await singleEmail.To("test-email@allopromo.co").Subject("Testing allopromom").Body("Hit is A Single E-mail To Be Sent Out", false).SendAsync(new CancellationToken?());
            return (object)true;
        }

        private async Task<object> SendMultipleEmails([FromServices] IFluentEmailFactory emailFactory)
        {
            SendResponse sendResponse = await emailFactory.Create().To("aliwiyao@gmail.com").Subject("Testing Servies allopromo - Emailing").Body(" Fucnking Testing Email", false).SendAsync(new CancellationToken?());
            return (object)true;
        }
    }
}

public class EmailNotificationService//:INotifyService
    {
        private readonly IStoreService _storeService;

        //private readonly IFluentEmail _email;

        public EmailNotificationService(IStoreService storeService)
        {
            _storeService = storeService;
        }
        //public async Task<bool> RaisesEmailEventHandler(object source, EventArgs e)
        public bool RaisesEmailEventHandler(object source, EventArgs e)
        {
            var email = new Email();
            var mail = SendSingleEmail(email);
            return true;
        }
        public bool SendNotification()
        {
            _storeService.StoreCreated += RaisesEmailEventHandler;
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
        private async Task<object> SendMultipleEmails([FromServices] IFluentEmailFactory emailFactory)
        {
            var email1 = emailFactory
                .Create()
                .To("aliwiyao@gmail.com")
                .Subject("Testing Servies allopromo - Emailing")
                .Body(" Fucnking Testing Email");
            await email1.SendAsync();
            return true;
        }

        //public Task<ApiResponseModel> SendNotification(NotificationModel notificationModel)


        //public void SendNotification()
        //{
        //    throw new NotImplementedException();
        //}

    }
}

//Here Send SMS Notification ! - Iterfacing - Are SOLID principles followed - Decoupling 
//FluentEmail.Smtp.SendMailEx.SendMailExAsync();
//_email.S
//then SignalR - Send Notifiation to Client


//https://www.thecodehubs.com/firebase-notification-in-net-core/