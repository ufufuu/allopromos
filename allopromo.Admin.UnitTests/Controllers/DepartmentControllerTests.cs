using NUnit.Framework;
using System.Net.Http;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using allopromo.Admin.Models.Dto;
using allopromo.Api.Controllers;

namespace allopromo.Admin.UnitTests.Controllers
{
    [TestFixture]
    public class DepartmentControllerTests
    {
        private event delRe deEvent;
        private DepartmentController SUT;
        private Mock<ILogger<Admin.Controllers.DepartmentController>> _loggerMock =
            new Mock<ILogger<Admin.Controllers.DepartmentController>>();
        private Admin.Controllers.DepartmentController departmentController;
        private Mock<HttpClient> _httpMock = new Mock<HttpClient>();
        private Mock<IHttpClientFactory> _httpFactoryMock = new Mock<IHttpClientFactory>();
        [SetUp]
        public void Init()
        {
            //SUT = new DepartmentController()
        }
        //[Test]
        //public void DepartmentController_
        //[Test]
        public void DepartmentController_Create_Should_Return_CreatedDeparment()
        {
            _httpFactoryMock.Setup(x => x.CreateClient(It.IsAny<string>()))
                .Returns(new HttpClient()).Verifiable();
            var result = departmentController.Create(It.IsAny<DepartmentDto>());
            Assert.IsNotNull(result);
        }
        [Test]
        public void DepartmentController_Create_Should_Return_BadRequestion_When_Department_IS_Null()
        {
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
            var result = departmentController.Index();
            Assert.IsNotNull(result);

            /*
            var result = Assert.Throws<ArgumentNullException>(() => departmentController.Index());
            Assert.That(result.Message.GetType().Equals(typeof(ArgumentNullException)));
            Assert.That(() => departmentController.Create(null), Throws.TypeOf<ArgumentNullException>());*/
        }
    }
}
