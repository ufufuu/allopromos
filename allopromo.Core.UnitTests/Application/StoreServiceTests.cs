using allopromo.Core.Abstract;
using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using allopromo.Core.Model;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Core.UnitTest.ServicesTests
{
    [TestFixture]
    public class StoreServiceTests
    {
        private Mock<IRepository<tStore>> _storeRepositoryMock= new Mock<IRepository<tStore>>();
        private Mock<IRepository<tStoreCategory>> categoryRepositoryMock = new Mock<IRepository<tStoreCategory>>();
        private Mock<IRepository<tDepartment>> departmentRepositoryMock = new Mock<IRepository<tDepartment>>();
        private allopromo.Core.Services.StoreService _sut;
        public StoreServiceTests()
        {
            //_sut = new StoreService(_storeRepositoryMock.Object, categoryRepositoryMock.Object,
              //  departmentRepositoryMock.Object);
        }
        [Test]
        public void StoreService_GetStores_ReturnStores()
        {
            List<StoreDto> listStores = new List<StoreDto>();
            _storeRepositoryMock.Setup(x => x.GetAllAsync())
                .Returns(getStoresAsync());
            var stores  = _sut.GetStores().Result;
            Assert.IsNotNull(stores);
            Assert.AreEqual(stores.Count(), 3);
        }
        //[Test]
        //public async Task StoreService_GetStores_ByLocation_ReturnStoresByLocalization()
        //{
        //    List<StoreDto> listStores = new List<StoreDto>();
        //    _storeRepositoryMock.Setup(x => x.GetAllAsync())
        //        .Returns((Task<IQueryable<tStore>>)getStoresAsync());

        //    var stores = await _sut.GetStores(); // ByLocalizationAsync(1, 1, 2);          //GetStores(Guid.NewGuid().ToString());
        //    Assert.IsNotNull(stores);
        //    Assert.AreEqual(stores.Count(), 3);
        //}
        //[Test]
        //public void StoreService_GetStoresByLocalization_ReturnStores()
        //{
        //    List<StoreDto> listStores = new List<StoreDto>();
        //    _storeRepositoryMock.Setup(x => x.GetAllAsync())
        //        .Returns((Task<IQueryable<tStore>>)GetStores());
        //    var stores = _sut.GetStoresByLocalizationIdAsync("");
        //    Assert.IsNotNull(stores);
        //}
        //[Test]
        public void StoreService_GetStores_ReturnStoresCategories()
        {
            List<StoreDto> listStores = new List<StoreDto>();
            var stores = _sut.GetStoreCategoriesAsync();
        }
        [TestCase]
        public void StoreService_CreateStores_ReturnsStores_AndRaisesNotification()
        {
            StoreDto store = new StoreDto
            {
                storeName = "La Planque a Thierry",
            };
        }
        [Test]
        public void StoresService_DeleteStore_Deletes()
        {
        }
        [Test]
        public async Task StoreService_GetImageUrl_SHOULD_Return_ImageLink()
        {
            var storeCategoryUrl = await _sut.getImageUrl();
            Assert.IsNotNull(storeCategoryUrl);
            Assert.AreEqual(storeCategoryUrl.GetType(), typeof(string));
        }
        [Test]
        public void UpdateStoreCategory_DEVRAIT_RetournerUpdatedStoreCategory()
        {
            categoryRepositoryMock.Setup(x => x.Update(It.IsAny<tStoreCategory>()));
            //var updated =storeService.UpdateStoreCategory() 
        }
        private Task<List<tStore>> getStoresAsync()
        {
            tStoreCategory category = new tStoreCategory();
            tCity city = new tCity { cityId = 21, cityName = "Quebec" };
            var storeList = new List<tStore>();
            storeList.Add(new tStore {storeId =Guid.Parse(Guid.NewGuid().ToString()), storeName = "por", Category=category, City=city});
            storeList.Add(new tStore {storeId =Guid.Parse(Guid.NewGuid().ToString()), storeName = "rrt", Category = category, City = city});
            storeList.Add(new tStore {storeId = Guid.Parse(Guid.NewGuid().ToString()), storeName = "ooi", Category = category, City = city });
            return Task.FromResult(storeList.ToList());
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

