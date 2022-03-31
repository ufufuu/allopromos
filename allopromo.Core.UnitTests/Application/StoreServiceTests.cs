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
        private Mock<IStoreRepository> storeRepository = new Mock<IStoreRepository>();

        //public StoreCreatedEventArgs storeCreated;
        [TestCase]
        public void StoreService_CreateStores_ReturnsStores_AndRaisesNotification()
        {
            var store_created = false;
            StoreCreatedEventArgs storeCreated = null ;
            IStoreService storeService = new StoreService(storeRepository.Object);
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
            var storeService = new StoreService(storeRepository.Object);
            List<StoreDto> listStores = new List<StoreDto>();
            //var stores = storeService.GetStoresAsync();
        }
        [TestCase]
        public void StoreService_GetCategories_ReturnsCategories()
        {
        }
    }
}