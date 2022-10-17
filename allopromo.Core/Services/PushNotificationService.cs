using allopromo.Core.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using FirebaseAdmin;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Net.Http;
using allopromo.Core.Services;
using allopromo.Core.Abstract;
using allopromo.Core.Model.ApiResponse;
using allopromo.Core.Model.Notifications;
using Microsoft.Extensions.Options;
namespace allopromo.Core.Infrastructure
{
    public class PushNotificationService :  INotifyService
    {
        private AccountService _accountService { get; set; }
        NotificationSettings _notificationSettings { get; set; }
        public PushNotificationService(IOptions<NotificationSettings> notificationSettings)
        {
            _notificationSettings = notificationSettings.Value;
        }
        public Task<ApiResponseModel> SendNotification(NotificationModel notificationModel)
        {
            ApiResponseModel apiResponseModel = new ApiResponseModel();
            {
                try
                {
                    //FcmSettings = new FcmSetting();
                    //FirebaseAdmin.
                }
                catch (Exception ex)
                {
                    //apiResponseModel.userResponse =;
                    //apiResponseModel.Message = "Something Went Wring";
                    //return apiResponseMode;
                    throw ex;
                }
            }
            return null;
        }
        public void SendNotification(object source, EventArgs e)
        {
            var currentUser = 
            _accountService = new AccountService();

            //Send Email through MailKIt or Other Service 
            //Pub.Event += Sub.Method;
            //_accountService.onUserAuthenticated += _emailService.SendEmailMessage(new EmailMessage(), 
              //  "kekvin.djo@allo.fr");
            //......
            //then Call Pub Event or Method to Raise Event !
            //FirebaseAdmin.
            var currentUser2 = this.getCurrentUser();
        }
        private Task getCurrentUser()
        {
            //var user2 = UserManager<User>
            //var cirrentUser = System.Web.HttpContext.Current.User.Identity.GetUserId();
            return null;
        }
        public void Dispose()
        {
        }
        public async Task<bool> SendNotifications(string to, string title, string body)
        {
            try
            {
                //Get Server key from FCM console
                var serverKey = string.Format("key={0}", "your server key - use app config");
                //GetSender id from FCM console
                var senderId = string.Format("id={0}", "your sender id ");
                var data = new
                {
                    to, //Recipient DEvice Token
                    notification = new { title, body }
                };
                var jsonBody = JsonConvert.SerializeObject(data); // vs webRequest ? or WebResponse
                using (var httpRequest = new HttpRequestMessage(HttpMethod.Post, "https://fmc.googleapis.com/fcm/send"))
                {
                    httpRequest.Headers.TryAddWithoutValidation("Authorization", serverKey);
                    httpRequest.Headers.TryAddWithoutValidation("Sender", senderId);
                    httpRequest.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                    using(var httpClient = new HttpClient())
                    {
                        var result = await httpClient.SendAsync(httpRequest);
                        if (result.IsSuccessStatusCode)
                            return true;
                        else
                        {
                            //_logger.LogError($"Error Seidng {result.StatusCode}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //_logger.LogError("$ Exception was thrown{ex}");
            }
            return false;
        }

        public bool SendNotification()
        {
            throw new NotImplementedException();
        }
        public Task<ApiResponseModel> SendNotificationsD(NotificationModel notificationModel)
        {
            throw new NotImplementedException();
        }
    }
}

/*
 *  https://www.thecodehubs.com
    https://www.thecodehubs.com/firebase-notification-in-net-core/
 */