using allopromo.Controllers;
using allopromo.Core.Abstract;
using allopromo.Core.Application.Dto;
using allopromo.Core.Domain;
using allopromo.Core.Entities;
using allopromo.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using allopromo.Api.Controllers;
namespace allopromo.Api.UnitTests
{
    [TestFixture]
    public class StoreControllerTest
    {
        //StoreCreatedEventArgs storeCreatedEventArgs;
        private bool NotifySent { get; set; }

        Mock<IStoreService> _storeServiceMock;
        Mock<IProductService> _productService;
        Mock<INotifyService> _notificationServiceMock;
        StoreController SUT;
        [SetUp]
        public void Init()
        {
            _storeServiceMock = new Mock<IStoreService>();
            _productService = new Mock<IProductService>();
            _notificationServiceMock = new Mock<INotifyService>();
            SUT = new StoreController(_storeServiceMock.Object, _productService.Object, _notificationServiceMock.Object);
        }
        [Test]
        public void StoreController_Put_StoreCategory_Null_SHOULD_ReturnStoreNotFoundResult()
        {
            SUT = new StoreController(_storeServiceMock.Object, _productService.Object, _notificationServiceMock.Object);
            var result = SUT.PutStoreCategory(null);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.GetType(), typeof(NotFoundResult));
        }
        [Test]
        public void StoreController_Put_StoreCategory_SHOULD_ModifyStoreCategory()
        {
            SUT = new StoreController(_storeServiceMock.Object, _productService.Object, _notificationServiceMock.Object);
            var result = SUT.PutStoreCategory(It.IsAny<StoreCategoryDto>());
            Assert.IsNotNull(result);
        }
        public void StoreCrontroller_CreateStore_ReturnsNotFound()
        {
            //Arrange
            Mock<IStoreService> _storeServiceMock = new Mock<IStoreService>();
            Mock<INotifyService> _notificationServiceMock = new Mock<INotifyService>();
            StoreDto store = null;
            var SUT = new StoreController(_storeServiceMock.Object, _productService.Object,
                _notificationServiceMock.Object);
            //var result = SUT.CreateStoreAsync(store);
            //Assert.IsInstanceOf<NotFoundResult>(result);
        }
        [Test]
        public void StoreCrontroller_CreateStoreAsync_ReturnsStoreCreated_RaisesNotificationEventAsync()
        {
            //Arrange
            Mock<IStoreService> _storeServiceMock = new Mock<IStoreService>();
            Mock<INotifyService> _notificationServiceMock = new Mock<INotifyService>();
            StoreController SUT =
                new StoreController(_storeServiceMock.Object,
                _productService.Object,
                _notificationServiceMock.Object);//, _notificationService.Object);
            var store = new StoreDto
            {
                //storeId = "dsd",
                storeName = "Thierry Plank",
            };

            _storeServiceMock.Setup(p => p.CreateStore(It.IsAny<StoreDto>(), It.IsAny<StoreCategoryDto>(),
                It.IsAny<UserDto>()))
                .Returns(Task.FromResult(new StoreDto()))

                .Raises(e => e.StoreCreated += null, (StoreDto store) => new EventArgs { });

            _storeServiceMock.Setup(x => x.CreateStore(It.IsAny<StoreDto>(), It.IsAny<StoreCategoryDto>(),
                It.IsAny<UserDto>()))
                .Returns(Task.FromResult(store));
            //Act
            _storeServiceMock.Object.StoreCreated += (o, e) => NotifySent = true;

            //_storeServiceMock.Object.storeCreated += delegate(o,e){ notifySent = true; } 
            //or Below // += (_, e) => notifySent = true;

            _notificationServiceMock.Object.SendNotification();
            _storeServiceMock.Object.StoreCreated += (_, e) =>
            {
                //storeCreatedEventArgs = (StoreCreatedEventArgs)e;
                //StoreCreated(_, e);
                NotifySent = true;
                return true;
            };
            _storeServiceMock.Object.StoreCreated += StoreCreated;

            _storeServiceMock.Setup(x => x.CreateStore(It.IsAny<StoreDto>(), It.IsAny<StoreCategoryDto>(),
                It.IsAny<UserDto>())).Returns(Task.FromResult(new StoreDto()))
            //.Raises(e => e.StoreCreated += _notificationServiceMock.Object.StoreCreatedEventHandler)
            //.Raises(e =>
            //{
            //    storeCreatedEventArgs = (StoreCreatedEventArgs)e;
            //});
            .Raises(x => x.StoreCreated += StoreCreated);

            _storeServiceMock.Object.StoreCreated += delegate (object source, EventArgs e)
            {
                //storeCreatedEventArgs = (StoreCreatedEventArgs)e;
                NotifySent = true;
                return true;
            };

            //SUT.CreateStoreAsync(store);

            //var result = SUT.CreateStoreAsync(store);

            //Assert.IsNotNull(storeCreatedEventArgs);

            //Assert.IsNotNull(result);

            //Assert.IsTrue(notifySent);

            //_notificationServiceMock.Verify(p => p.SendNotification(), Times.Once());
            //return Task.CompletedTask;
        }

        public void GetStoreByCategoryId_ShouldReturn_StoresbyCategoryId()
        {
            //int pageId = 2;
            //int limitPerPage = 10;

            Mock<IStoreService> _storeServiceMock = new Mock<IStoreService>();//? is Core.Abstract ?How ?
            Mock<INotifyService> _notificationServiceMock = new Mock<INotifyService>();
            var storeController = new StoreController(_storeServiceMock.Object,
                _productService.Object,
                _notificationServiceMock.Object);
        }
        bool StoreCreated(object source, System.EventArgs e)
        {
            //storeCreatedEventArgs = (StoreCreatedEventArgs)e;
            NotifySent = true;
            return true;
        }
        //[Test]
        public void StoreController_GetStore_Returns_OkStoreFound()
        {
            //Arrange
            Mock<IStoreService> _storeServiceMock = new Mock<IStoreService>();
            Mock<INotifyService> _notificationServiceMock = new Mock<INotifyService>();
            StoreController storeController = new StoreController(_storeServiceMock.Object,
                _productService.Object,
                _notificationServiceMock.Object);
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
            StoreController storeController = new StoreController(_storeServiceMock.Object,
                _productService.Object,
                _notificationServiceMock.Object);
            //var result = storeController.GetStoreByIdAsync("null");//store);//.storeId);
            //Assert.AreEqual(result.GetType(), new NotFoundResult().GetType());
        }
        [Test]
        public void StoreController_CreateProductAsync_SHOULDReturn_CreatedProduct()
        {
            Mock<IStoreService> _storeServiceMock = new Mock<IStoreService>();
            Mock<IProductService> _productServiceMock = new Mock<IProductService>();
            var _sut = new StoreController(_storeServiceMock.Object, _productServiceMock.Object, _notificationServiceMock.Object);

            var productDto = new tProduct { };

            var result = _sut.CreateProductAsync(productDto);
            Assert.IsNotNull(result);
        }
        [Test]
        public void StoreController_CreateProductAsync_SHOULD_Return_NotAuthenticated_IfUserNotAuthenticated()
        {
            Mock<IStoreService> _storeServiceMock = new Mock<IStoreService>();
            Mock<IProductService> _productServiceMock = new Mock<IProductService>();
            var _sut = new StoreController(_storeServiceMock.Object, _productServiceMock.Object, 
                _notificationServiceMock.Object);
            //UserDto user = null;
            tProduct tproduct = new tProduct();
            var result = _sut.CreateProductAsync(tproduct);
            Assert.AreEqual(result.Result.GetType(), typeof(UnauthorizedResult));
        }
        [Test]
        public void PutStoreCategory_SHOULD_Update()
        {

        }
        public void Create_SHOULDReturn_PageToLogin_ifNotAuthenticated()
        {
        }
        [Test]
        public void StoreController_GetProductsByCategoryIdAsync_SHOULD_Return_Products()
        {
            SUT = new StoreController(_storeServiceMock.Object,
                _productService.Object,
                _notificationServiceMock.Object);

            //var products = SUT.GetProducts();
            //Assert.IsNotNull(products);
        }
        [Test]
        public void StoreController_ModifyStoreCategory_SHOULD_ReturnStatus()
        {
            var sut = new StoreController(_storeServiceMock.Object,
                _productService.Object, _notificationServiceMock.Object);
            string categoryId = "";
            StoreCategoryDto category = new StoreCategoryDto
            {
                storeCategoryId = "1",
                storeCategoryName = "", //storeCategoryStatus = true };
            };
            var storeStatus = sut.PutStoreCategory(category);
            //var storeStatus = sut.PutStoreCategory(categoryId, category);
            Assert.IsNotNull(storeStatus);
        }
        [Test]
        public void StoreController_DeleteStoreCategory_SHOULD_Delete()
        {
            StoreCategoryDto category = new StoreCategoryDto
            {
                storeCategoryId = "1nmnm-kkjkk-kmkmkmk-jnjjv88",
                storeCategoryName = "", //storeCategoryStatus = true };
            };
            var result = new StoreController(_storeServiceMock.Object,
                _productService.Object, _notificationServiceMock.Object)
                .DeleteStoreCategory(category.storeCategoryId);
            Assert.IsNotNull(result);
        }
        [Test]
        public void StoreController_DeleteStoreCategory_SHOULD_NotReturnNotfound()
        {
            var result = new StoreController(_storeServiceMock.Object,
                _productService.Object, _notificationServiceMock.Object)
                .DeleteStoreCategory(null);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.GetType(), typeof(BadRequestResult));
        }
        [Test]
        public void StoreController_GetStorCategoryThumbnail_SHOULD_ReTurnImageDirectory()
        {
        }
        [Test]
        public void PostCreateShouldSaveCustomerAndReturnDetailsView()
        {
        }
        [Test]
        public void StoreCrontroller_CreateStore_ReturnsStoreCreated_RaisesNotificationEvent()
        {
            //Arrange
            Mock<IStoreService> _storeServiceMock = new Mock<IStoreService>();
            Mock<INotifyService> _notificationServiceMock = new Mock<INotifyService>();

            StoreController storeController =
                new StoreController(_storeServiceMock.Object, _productService.Object, _notificationServiceMock.Object); 
            var store = new StoreDto
            {
                storeId = "dsd",
                storeName = "Thierry Plank",
            };
            //Act
            //var result = storeController.CreateStoreAsync(store);

            //_notificationServiceMock.Object.storeCreated += (o, e) => notifySent = true;
            //_storeServiceMock.Object.storeCreated += delegate(o,e){ notifySent = true; } or Below

            _notificationServiceMock.Object.SendNotification(); // += (_, e) => notifySent = true;

            //_notificationServiceMock.Object.SendNotification += (_, e) =>
            //{
            //    storeCreatedEventArgs = (StoreCreatedEventArgs)e;
            //    StoreCreated(_, e);
            //    return true;
            //};
            //_notificationServiceMock.Object.SendNotification += (StoreCreated);
            //_notificationServiceMock.Object.storeCreated += delegate (object source, EventArgs e)
            //{
            //    storeCreatedEventArgs = e as StoreCreatedEventArgs;
            //    notifySent = true;
            //    return true;
            //};
            //_notificationServiceMock.Setup(x => x.CreateStoreAync(It.IsAny<StoreDto>())).Returns(store);
            //storeService.CreateStoreAsync(store);
            //_notificationServiceMock.Verify(x => x.OnStoreCreated(), Times.Once);

            _notificationServiceMock.Verify(p => p.SendNotification(), Times.Once());
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


/*
 * https://www.c-sharpcorner.com/article/learn-about-web-api-validation/
 * 
 * Number of occurence in a Word , number of words in a Phrase !
 */
/* Asynchronous Method vs , whhen should I make a methdos Asynchronous ? What are Callbacks ?
 */
/* Fields vs Properties ??? */
/* Store Servcice having StoerRepo as Fields ? Why ?
 */
/*
 * //Singleton Pattern : Why Use ? //Extension Class  //Extensions Methods 0001-01-01 00:00:00.0000000 //Direct Casting vs Operator casting
 * 
 * */
/*
 * //[Authorize(AuthenticationSchemes = "Test")]
        //[Authorize(Roles = "users")]
*/
//[Authorize(AuthenticationSchemes = "Test")]//[BasicAuthenticationFilter]//[BasicJwtAuthorize] //vs [AuthorizeAttribute]?

//Delegates //Generic Delegates //Structs

//[Authorize(AuthenticationSchemes ="Test")] //[allopromo.Infrastructure.Providers.BasicAuthenticationFilter]
// ? Custom Authorization ?
//ActionExecutingContext actionContext)bwith [BasicJwt Attrib]!

//return Unauthorized();
//Secured Api Action

/* 4.. Shared kernel  Project ::::
 * Base Entity - Base value Object - Base Domain Events -Base specications - Common INterface
 * Common Exceptions - Comom Auth - Common Guards - Common Libraries , DI, Loggin, Validators
/****
 * 
 * Api Endpoint- Razor pages - Controllers - Views  - Api Models - ViewModels - Filters - Mmodel Binders -Tag Helpers
 * 
 * Interface rrurn types 
 *  COmpostion Root ?
 **
//Infrastructure Prject:
//Repositoriies - Api Clients ?  - DbContext Classes  - Cached Repositories  - File System Accessort - Azure Storeage
//Accessort - Emimailing Implement - SMS implementations - System Clock - Other Services , Interfaces 

///*github.com/ardalis/CleanArchitecture 
/*Ardalis Clean Archiecture Template from nuget 
/* CORE, What Beloing in the Core Project 
 * Interface
 * 
 * Aggregates (grouoing Entiites)
 * ValuesObjects( time , not Id contrary to Entities
 * 
 * Domain Services
 * 
 * Domain Exceptions 
 * Domain Events 
 * Evendt Handlers
 * 
 * Specification : library  ?
 * Validations : fluent Validation lib
 * Enurms
 * Custom Guards ? 
 */