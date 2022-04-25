using allopromo.Core.Abstract;
using allopromo.Core.Application.Dto;
using allopromo.Core.Model;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
namespace allopromo.Core.UnitTest.ServicesTests
{
    [TestFixture]
    public class StoreServiceTests
    {
        private Mock<IStoreRepository> storeRepositoryMock= new Mock<IStoreRepository>();
        //public StoreCreatedEventArgs storeCreated;
        [TestCase]
        public void StoreService_CreateStores_ReturnsStores_AndRaisesNotification()
        {
            var store_created = false;
            StoreCreatedEventArgs storeCreated = null ;
            IStoreService storeService = new StoreService(storeRepositoryMock.Object);
            StoreDto store = new StoreDto
            {
                storeName = "La Planque a Thierry",
                
                storeId = "348ireknf"
            };

            storeService.storeCreated+= delegate //delagate(object soure, EventArgs e) //storeService.storeCreated += (o, e) =>
            {
                storeCreated = new StoreCreatedEventArgs();
                store_created = true;
                return true;
            };
            storeService.CreateStore(store);
            Assert.IsNotNull(storeCreated);
            Assert.IsTrue(store_created);
        }
        //[Test]
        //public void StoreCrontroller_CreateStore_ReturnsStoreCreated_RaisesNotificationEvent()
        //{
        //    //Arrange
        //    //Mock<IStoreService> _storeServiceMock = new Mock<IStoreService>();
        //    Mock<INotifyService> _notificationServiceMock = new Mock<INotifyService>();
        //    StoreService storeService =
        //        new StoreService(storeRepositoryMock.Object); // _notificationServiceMock.Object);//, _notificationService.Object);
        //    var store = new StoreDto
        //    {
        //        storeId = "dsd",
        //        storeName = "Thierry Plank",
        //    };
        //    //Act
        //    var result = storeService.CreateStore(store);
        //    _notificationServiceMock.Object.storeCreated += (o, e) => notifySent = true;

        //    //_storeServiceMock.Object.storeCreated += delegate(o,e){ notifySent = true; } or Below

        //    _notificationServiceMock.Object.SendNotification(); // += (_, e) => notifySent = true;
        //    _notificationServiceMock.Object.SendNotification += (_, e) =>
        //    {
        //        storeCreatedEventArgs = (StoreCreatedEventArgs)e;
        //        StoreCreated(_, e);
        //        return true;
        //    };
        //    _notificationServiceMock.Object.storeCreated += (StoreCreated);
        //    _notificationServiceMock.Object.storeCreated += delegate (object source, EventArgs e)
        //    {
        //        storeCreatedEventArgs = e as StoreCreatedEventArgs;
        //        notifySent = true;
        //        return true;
        //    };
        //    _notificationServiceMock.Setup(x => x.CreateStore(It.IsAny<StoreDto>())).Returns(store);
        //    storeService.CreateStoreAsync(store);
        //    _notificationServiceMock.Verify(x => x.OnStoreCreated(), Times.Once);
        //    _notificationServiceMock.Verify(p => p.SendNotification(), Times.Once());
        //}
        //bool StoreCreated(object source, StoreCreatedEventArgs e)
        //{
        //    storeCreated =e;
        //    return true;
        //}

        [TestCase]
        public void StoresService_DeleteStore_Deletes()
        {
        }
        //[TestCase]
        public void StoresService_GetStores_ReturnStores()
        {
            var storeService = new StoreService(storeRepositoryMock.Object);
            List<StoreDto> listStores = new List<StoreDto>();
            //var stores = storeService.GetStoresAsync();
        }
        [TestCase]
        public void StoreService_GetCategories_ReturnsCategories()
        {
        }
    }
}