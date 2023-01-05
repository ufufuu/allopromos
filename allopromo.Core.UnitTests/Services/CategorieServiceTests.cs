using allopromo.Core.Abstract;
using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using allopromo.Core.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
namespace allopromo.Core.UnitTests.Application
{
    [TestFixture]
    public class CategorieServiceTests
    {
        private Mock<IRepository<tStoreCategory>> _categorieRepositoryMock = new Mock<IRepository<tStoreCategory>>(); //{ get; set;}
        private Mock<IRepository<tDepartment>> _departmentRepositoryMock = new Mock<IRepository<tDepartment>>(); // { get; set; }
        private Mock<HttpClient> httClientMock { get; set; }
        [Test]
        public void GetStoreCategoriesAsync_SHOULD_Return_Categories()
        {
            var categorieService = new CategorieService(_categorieRepositoryMock.Object,
                _departmentRepositoryMock.Object);
            var categories = categorieService.GetStoreCategoriesAsync();
            _categorieRepositoryMock.Setup(x => x.GetAllAsync())
                .Returns((System.Threading.Tasks.Task<List<tStoreCategory>>)
                It.IsAny<IEnumerable<tStoreCategory>>());
            Assert.IsNotNull(categories);
            //categorieService.Verify(x => x.GetStoreCategoriesAsync(), Times.Once());
        }
        [Test]
        public void CategorieService_GetStores_SHOULD_ReturnStores()
        {
            var categorieService = new CategorieService();//_categorieRepositoryMock.Object,
                //_categorieRepositoryMock.Object);
            List<StoreDto> listStores = new List<StoreDto>();
            var stores = categorieService.GetStoreCategoriesAsync();
        }
        [Test]
        public void CategorieService_GetCategories_SHOULD_ReturnsCategories()
        {
            var CategorieService = new CategorieService(); // storeRepositoryMock.Object, categoryRepositoryMock.Object);
            var result = CategorieService.GetStoreCategoriesAsync();
            Assert.IsNotNull(result);
        }
        [Test]
        public void getImageInformationUrlAsync_SHOULD_Return()
        {
        }
    } 
}
