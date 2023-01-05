using allopromo.Core.Abstract;
using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using allopromo.Core.Model;
using allopromo.Core.Services;
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
        private Mock<IMediaService> mediaServiceMock = new Mock<IMediaService>();
        private Mock<IRepository<tStore>> storeRepositoryMock= new Mock<IRepository<tStore>>();
        private Mock<IRepository<tStoreCategory>> categoryRepositoryMock = new Mock<IRepository<tStoreCategory>>();
        private Mock<IRepository<tDepartment>> departmentRepositoryMock = new Mock<IRepository<tDepartment>>();
        [Test]
        public void StoreService_CreateStoreCategory_ShouldReturn_CreatedStoreCategory()
        {
            var categoryService = new CategorieService(categoryRepositoryMock.Object, departmentRepositoryMock.Object);
            var restul = categoryService.CreateStoreCategoryAsync(It.IsAny<StoreCategoryDto>()).Result;
            categoryRepositoryMock.Verify<Task>(x => x.Add(It.IsAny<tStoreCategory>()), Times.Once);
        }

        [TestCase]
        public void StoreService_CreateStores_SHOULD_ReturnsStores_AndRaisesNotification()
        {
            StoreDto store = new StoreDto
            {
                storeName = "La Planque a Thierry",
                storeId = "348ireknf"
            };
        }
        [Test]
        public void StoreService_SHOULD_DeleteStore()
        {
        }
        [Test]
        public void StoresService_GetCategory_SHOULD_Return_storeCategory()
        {
            var storeService = new StoreService(storeRepositoryMock.Object,
                categoryRepositoryMock.Object);
            var actualCategory = new StoreCategoryDto
            {
                storeCategoryId = new Guid().ToString(),
                storeCategoryName = "Category"
            };
            var category = storeService.GetStoreCategoryByIdAsync(new Guid().ToString());
            Assert.IsNotNull(category);
        }
        
        [Test]
        public async Task StoreService_GetImageUrl_SHOULD_Return_ImageLink()
        {
            var storeService = new StoreService(storeRepositoryMock.Object, categoryRepositoryMock.Object);
            var storeCategoryUrl = await mediaServiceMock.Object.GetImageUrl();
            Assert.IsNotNull(storeCategoryUrl);
            Assert.AreEqual(storeCategoryUrl.GetType(), typeof(string));
        }
        [Test]
        public void UpdateStoreCategory_DEVRAIT_RetournerUpdatedStoreCategory()
        {
            categoryRepositoryMock.Setup(x => x.Update(It.IsAny<tStoreCategory>()));
            var storeService = new StoreService(storeRepositoryMock.Object, categoryRepositoryMock.Object);
            //var updated =storeService.UpdateStoreCategory() 
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

