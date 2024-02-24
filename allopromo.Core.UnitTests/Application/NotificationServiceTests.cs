//using allopromo.Core.Application.Dto;


using allopromo.Core.Entities;
using allopromo.Core.Model;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace alloPromoTests.Services
{
    //[TestFixture] 
    public class NotificationServiceTests
    {
        private Mock<allopromo.Core.Services.StoreService> storeServiceMock = 
            new Mock<allopromo.Core.Services.StoreService>();
        //[Test]
        public void NotificationService_SendsNotification_When_Stores_Is_Created()
        {
            //var notificationService = new NotifyService(storeServiceMock.Object);

            storeServiceMock.Setup(p => p.CreateStoreAsync(It.IsAny<tStore>(),
                        It.IsAny<string>())) //UserDto>()))
                .Returns(Task.FromResult(new tStore()));

            //.Raises(p => p.storeCreated += new NotificationService(storeServiceMock.Object).StoreCreatedEventHandler);

            //var result = notificationService.SendNotification();

            //notificationService.StoreCreatedEventHandler
            
            //var mockAccountService = new Mock<IAccountService>();
            //mockAccountService.Setup(p => p.OnUserAuthenticated())
            //.Raises(ev => ev.onUserAuthenticated += null, this, true);
        }
    }
}
