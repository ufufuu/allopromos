using allopromo.Core.Abstract;
using allopromo.Core.Model.ViewModel;
//using allopromo.Infrastructure.Notifications;


using Moq;
#pragma warning disable CS0246 // The type or namespace name 'NUnit' could not be found (are you missing a using directive or an assembly reference?)
using NUnit.Framework;
#pragma warning restore CS0246 // The type or namespace name 'NUnit' could not be found (are you missing a using directive or an assembly reference?)
namespace alloPromoTests.Services
{
#pragma warning disable CS0246 // The type or namespace name 'TestFixtureAttribute' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning disable CS0246 // The type or namespace name 'TestFixture' could not be found (are you missing a using directive or an assembly reference?)
    [TestFixture]
#pragma warning restore CS0246 // The type or namespace name 'TestFixture' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning restore CS0246 // The type or namespace name 'TestFixtureAttribute' could not be found (are you missing a using directive or an assembly reference?)
    public class EmailServiceTests
    {
#pragma warning disable CS0246 // The type or namespace name 'Test' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning disable CS0246 // The type or namespace name 'TestAttribute' could not be found (are you missing a using directive or an assembly reference?)
        [Test]
#pragma warning restore CS0246 // The type or namespace name 'TestAttribute' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning restore CS0246 // The type or namespace name 'Test' could not be found (are you missing a using directive or an assembly reference?)
        public void SendEmailMessageReturns_True()
        {
        }
#pragma warning disable CS0246 // The type or namespace name 'Test' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning disable CS0246 // The type or namespace name 'TestAttribute' could not be found (are you missing a using directive or an assembly reference?)
        [Test]
#pragma warning restore CS0246 // The type or namespace name 'TestAttribute' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning restore CS0246 // The type or namespace name 'Test' could not be found (are you missing a using directive or an assembly reference?)
        public void EmailService_EmailSendEventRaised_When_UserAuthenticatesInAccountService()
        {
            //var emailService = new EmailService();

            // Var User = new User
            // When he authenticates, is an Email Sent to him and how to Assert that ?
            //

            var mockAccountService = new Mock<IAccountService>();
            //mockAccountService.Setup(p => p.OnUserAuthenticated(It.IsAny<LoginModel>())).Raises
            mockAccountService.Setup(p => p.OnUserAuthenticated())
                .Raises(ev => ev.onUserAuthenticated += null, this, true);
        }
    }
}
