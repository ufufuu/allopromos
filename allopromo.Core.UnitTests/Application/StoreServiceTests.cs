using allopromo.Core.Abstract;
using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using allopromo.Core.Model;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace allopromo.Core.UnitTest.ServicesTests
{
    [TestFixture]
    public class StoreServiceTests
    {
        private Mock<IRepository<tStore>> _storeRepositoryMock= new Mock<IRepository<tStore>>();
        private Mock<IStoreRepository> storeRepositoryMock = new Mock<IStoreRepository>();
        [TestCase]
        public void StoreService_CreateStores_ReturnsStores_AndRaisesNotification()
        {
            StoreDto store = new StoreDto
            {
                storeName = "La Planque a Thierry",
                storeId = "348ireknf"
            };
        }
        [Test]
        public void StoresService_DeleteStore_Deletes()
        {
        }
        [Test]
        public void StoreService_GetStores_ReturnStores()
        {
            var storeService = new StoreService(storeRepositoryMock.Object);
            List<StoreDto> listStores = new List<StoreDto>();
            var stores = storeService.GetStoreCategoriesAsync();
        }
        [Test]
        public void StoreService_GetCategories_ReturnsCategories()
        {
            var storeService = new StoreService(storeRepositoryMock.Object);
            var result = storeService.GetStoreCategoriesAsync();
            Assert.IsNotNull(result);
        }
        [Test]
        public async Task StoreService_GetImageUrl_SHOULD_Return_ImageLink()
        {
            var storeService = new StoreService(storeRepositoryMock.Object);
            var storeCategoryUrl = await storeService.getImageUrl();
            Assert.IsNotNull(storeCategoryUrl);
            Assert.AreEqual(storeCategoryUrl.GetType(), typeof(string));
        }
    }

}

//storeService.storeCreated+= delegate 
////delagate(object soure, EventArgs e) //storeService.storeCreated += (o, e) =>
//{
//    storeCreated = new StoreCreatedEventArgs();
//    store_created = true;
//    return true;
//};1`0

