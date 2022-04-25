using allopromo.Controllers;
using allopromo.Core.Abstract;
using allopromo.Core.Application.Dto;
using allopromo.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
namespace allopromo.Api.UnitTests
{
    [TestFixture]
    public class StoreControllerTest
    {
        StoreCreatedEventArgs storeCreatedEventArgs;
        bool notifySent; // = false;
        [Test]
        public void StoreCrontroller_CreateStore_ReturnsUnauthorized()
        {
            //Arrange
            Mock<IStoreService> _storeServiceMock = new Mock<IStoreService>();
            Mock<INotifyService> _notificationServiceMock = new Mock<INotifyService>();
            StoreDto store = null;
            var storeController = new StoreController(_storeServiceMock.Object, _notificationServiceMock.Object);
            var result = storeController.CreateStoreAsync(store);
            Assert.IsInstanceOf<UnauthorizedResult>(result);
        }
        [Test]
        public void StoreCrontroller_CreateStoreAsync_ReturnsStoreCreated_RaisesNotificationEvent()
        {

            //Arrange
            Mock<IStoreService> _storeServiceMock = new Mock<IStoreService>();
            Mock<INotifyService> _notificationServiceMock = new Mock<INotifyService>();
            StoreController storeController =
                new StoreController(_storeServiceMock.Object, _notificationServiceMock.Object);//, _notificationService.Object);
            var store = new StoreDto
            {
                storeId = "dsd",
                storeName = "Thierry Plank",
            };

            _storeServiceMock.Setup(p => p.CreateStore(It.IsAny<StoreDto>()))
                .Returns(new StoreDto())
                .Raises(e => e.storeCreated += null, (StoreDto store) => new EventArgs { });

            //Act
            //var result = storeController.CreateStoreAsync(store);

            _storeServiceMock.Object.storeCreated += (o, e) => notifySent = true;
            //_storeServiceMock.Object.storeCreated += delegate(o,e){ notifySent = true; } or Below // += (_, e) => notifySent = true;
            _notificationServiceMock.Object.SendNotification();
            _storeServiceMock.Object.storeCreated += (_, e) =>
            {
                //storeCreatedEventArgs = (StoreCreatedEventArgs)e;
                //StoreCreated(_, e);
                notifySent = true;
                return true;
            };
            _storeServiceMock.Object.storeCreated += (StoreCreated);

            //_storeServiceMock.Setup(x => x.CreateStore(It.IsAny<Store>())).Returns(new Store())
            //    .Raises(e => e.storeCreated += _notificationService.Object.StoreCreatedEventHandler);
            //_storeServiceMock.Setup(x => x.CreateStore(It.IsAny<Store>())).Returns(store)
            //    .Raises((e)=>
            //    {
            //        storeCreatedEventArgs = (StoreCreatedEventArgs)e;
            //    });
            //.Raises(x => x.storeCreated+=StoreCreated);

            _storeServiceMock.Object.storeCreated += delegate (object source, EventArgs e)
            {
                //storeCreatedEventArgs = (StoreCreatedEventArgs)e;
                notifySent = true;
                return true;
            };

            //_storeServiceMock.Setup(x => x.CreateStore(It.IsAny<StoreDto>())).Returns(store);
            storeController.CreateStoreAsync(store);

            _storeServiceMock.Verify(x=> x.OnStoreCreated(), Times.Once);
            //Assert.IsNotNull(storeCreatedEventArgs);
            Assert.IsTrue(notifySent);
            _notificationServiceMock.Verify(p => p.SendNotification(), Times.Once());
        }

        public void GetStoreByCategoryId_ShouldReturn_StoresbyCategoryId()
        {
            int pageId = 2;
            int limitPerPage = 10;
            Mock<IStoreService> _storeServiceMock = new Mock<IStoreService>();                      //? is Core.Abstract ?How ?
            Mock<INotifyService> _notificationServiceMock = new Mock<INotifyService>();
            var storeController = new StoreController(_storeServiceMock.Object, _notificationServiceMock.Object);

        }

        bool StoreCreated(object source, System.EventArgs e)
        {
            //storeCreatedEventArgs = (StoreCreatedEventArgs)e;
            notifySent = true;
            return true;
        }
        //[Test]
        public void StoreController_GetStore_Returns_OkStoreFound()
        {
            //Arrange
            Mock<IStoreService> _storeServiceMock = new Mock<IStoreService>();
            Mock<INotifyService> _notificationServiceMock = new Mock<INotifyService>();
            StoreController storeController = new StoreController(_storeServiceMock.Object, _notificationServiceMock.Object);
            var store = new StoreDto
            {
                storeId = Guid.NewGuid().ToString(),
                storeName = "Thierry Plank",
                storeReferenceNumber = 9213
            };
           // var actualResult = storeController.GetStoreByIdAsync("dsd").Result as OkObjectResult;
            //Assert.AreEqual(actualResult.StatusCode, 200);
        }
        //[Test]
        public void StoreController_GetStore_Returns_StoreNotFound()
        {
            //Arrange
            Mock<IStoreService> _storeServiceMock = new Mock<IStoreService>();
            Mock<INotifyService> _notificationServiceMock = new Mock<INotifyService>();
            StoreDto store = new StoreDto(); // null;
            store.storeId = null;
            StoreController storeController = new StoreController(_storeServiceMock.Object, _notificationServiceMock.Object);
           // var result = storeController.GetStoreByIdAsync("null");//store);//.storeId);
            //Assert.AreEqual(result.GetType(), new NotFoundResult().GetType());
        }
    }
}
// Speed Up React Native Startup librarty 
//Replacing C# Events: https://rehansaeed.com/reactive-extensions-part1-replacing-events/
//kdjf
//https://docs.nunit.org/articles/nunit/writing-tests/assertions/classic-assertions/Assert.Throws.html
//https://www.callstack.com/blog/optimize-android-app-startup-time-with-hermes
// devjoy.com/blog/unikt-testing
//https://docs.educationsmediagroup.com/unit-testing-csharp/moq/verifications
//https://docs.educationsmediagroup.com/unit-testing-csharp/moq/events
// Delegates,(2) types 
// .single-Cast Delegates: holding references to Single Methosds vs  |
//Multiple Cast Deleagates: holding references to Multiple methods by single delegate declaration
//Delegates to Pass Methods as Parameters to Other Methods 
//By Using Delegates, We can Call MULTIPLES MEthods With a Single Event !
// We can use Invoke property to call Delegates or regularly 
/*https://www.justia.com/criminal/offenses/drug-crimes/drug-trafficking/
 * 1 store service raising event ? 2. notification subscribing 3. signalRing ? 4. Refactoring, Generic ing , Performance Testing */

//EnvironmentVariableTarget