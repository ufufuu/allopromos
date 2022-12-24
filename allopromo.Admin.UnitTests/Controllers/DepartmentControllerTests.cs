using NUnit.Framework;
using System.Net.Http;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using allopromo.Admin.Models.Dto;
namespace allopromo.Admin.UnitTests.Controllers
{
    [TestFixture]
    public class DepartmentControllerTests
    {
        private event delRe deEvent;
        private Mock<ILogger<Admin.Controllers.DepartmentController>> _loggerMock =
            new Mock<ILogger<Admin.Controllers.DepartmentController>>();
        private Admin.Controllers.DepartmentController departmentController;
        private Mock<HttpClient> _httpMock = new Mock<HttpClient>();
        private Mock<IHttpClientFactory> _httpFactoryMock = new Mock<IHttpClientFactory>();
        [Test]
        public void DepartmentController_Create_Should_Return_CreatedDeparment()
        {
            _httpFactoryMock.Setup(x => x.CreateClient(It.IsAny<string>()))
                .Returns(new HttpClient()).Verifiable();
            departmentController = new Admin.Controllers.DepartmentController(_httpFactoryMock.Object, _loggerMock.Object);
            var result = departmentController.Create(It.IsAny<DepartmentDto>());
            Assert.IsNotNull(result);
        }
        [Test]
        public void DepartmentController_Create_Should_Return_BadRequestion_When_Department_IS_Null()
        {
            var departmentController = new Admin.Controllers.DepartmentController(_httpFactoryMock.Object, _loggerMock.Object);
            var result = departmentController.Create(null);
            Assert.AreEqual(typeof(BadRequestResult), result.GetType());

            //var result = Assert.Throws<NullReferenceException>(() => departmentController.Create(null));
            //Assert.That(() => departmentController.Create(null), Throws.TypeOf<NullReferenceException>());
            //Assert.IsNull(result);
            //Assert.That(result.Message.GetType().Equals(typeof(NullReferenceException)));
        }
        [Test]
        public void DepartmentController_Get_Should_Return_Departments()
        {
            _httpFactoryMock.Setup(x => x.CreateClient(It.IsAny<string>()))
                .Returns(deEvent);
            var departmentController = new Admin.Controllers.DepartmentController(_httpFactoryMock.Object, _loggerMock.Object);
            var result = departmentController.Index();
            Assert.IsNotNull(result);

            /*
            var result = Assert.Throws<ArgumentNullException>(() => departmentController.Index());
            Assert.That(result.Message.GetType().Equals(typeof(ArgumentNullException)));
            Assert.That(() => departmentController.Create(null), Throws.TypeOf<ArgumentNullException>());*/
        }
    }
}
