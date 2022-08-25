using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Infrastructure.Services.Emailing
{
    public class EmailService
    {
        //private IOrderRepository _orderService=null;
        // Adapter pattern Below !?
        public EmailService()
        // public EmailService(IOrderService orderService)
        {
            //_orderService = orderService;
        }
        public void SendEmails()
        {
            //_orderService.GetAll()
        }
        public void EmailService_EmailSendEventRaised_When_UserAuthenticatesInAccountService()
        {
            //var emailService = new EmailService();

            // Var User = new User
            // When he authenticates, is an Email Sent to him and how to Assert that ?
            //



            //var mockAccountService = new Mock<IAccountService>();
            ////mockAccountService.Setup(p => p.OnUserAuthenticated(It.IsAny<LoginModel>())).Raises
            //mockAccountService.Setup(p => p.OnUserAuthenticated())
            //    .Raises(ev => ev.onUserAuthenticated += null, this, true);
        }
    }
}
