using allopromo.Controllers;
using allopromo.Core.Abstract;
using allopromo.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
namespace allopromo.Api.UnitTests
{
    [TestFixture]
    public class ProductControllerTest
    {
        StoreCreatedEventArgs storeCreatedEventArgs;
        bool productCreated;

        //[TestCase]
        //public void StoreCrontroller_CreateStore_ReturnsUnauthorized()
        //{
        //    allopromo.Core.Application.Dto.StoreDto store = null;
        //    var storeController = new StoreController(_storeServiceMock.Object, _productServiceMock.Object);
        //    var result = storeController.CreateStore(store);
        //    Assert.IsInstanceOf<UnauthorizedResult>(result);
        //}
        [TestCase]
        public void StoreCrontroller_CreateProduct_ReturnsCreatedProduct_RaisesNotificationEvent()
        {
            Mock<IStoreService> _storeServiceMock = new Mock<IStoreService>();
            Mock<IProductService> _productServiceMock = new Mock<IProductService>();

            storeCreatedEventArgs = null;
            productCreated = false;

            _storeServiceMock.Object.storeCreated += (_, e) =>
              {
                  storeCreatedEventArgs = (StoreCreatedEventArgs )e;
                  StoreCreated(_, e);
                  return true;
              };
            _storeServiceMock.Object.storeCreated +=(StoreCreated);

            _storeServiceMock.Object.storeCreated += (o, e) => notifySent = true;

            
            _storeServiceMock.Object.storeCreated += delegate(object source, EventArgs e) 
                {
                    storeCreatedEventArgs = e as StoreCreatedEventArgs;
                    notifySent = true;
                    return true;
                };
            _storeServiceMock.Object.storeCreated += (o, e) =>
            {
                storeCreatedEventArgs = (StoreCreatedEventArgs)e;
                return true;
            };
            _storeServiceMock.Setup(x => x.CreateStore(It.IsAny<Store>())).Returns(store);

            _sut.StoreCreated += delegate (object o, EventArgs e)
            {
                notifySent = true;
                return true;
            };
            _sut.CreateStore(store);

            Assert.IsTrue(productCreated);
        }
        bool StoreCreated(object source, System.EventArgs e)
        {
            storeCreatedEventArgs =(StoreCreatedEventArgs )e;
            productCreated = true;
            return true;
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