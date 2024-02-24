using NUnit.Framework;
using System.Net.Http;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using allopromo.Admin.Models.Dto;
using allopromo.Api.Controllers;
using System;

namespace allopromo.Admin.UnitTests.Controllers
{
    [TestFixture]
    public class DepartmentControllerTests
    {
        private event delRe deEvent;
        private DepartmentController _SUT;
        private Mock<ILogger<Admin.Controllers.DepartmentController>> _loggerMock =
            new Mock<ILogger<Admin.Controllers.DepartmentController>>();
        
        private Mock<HttpClient> _httpMock = new Mock<HttpClient>();
        private Mock<IHttpClientFactory> _httpFactoryMock = new Mock<IHttpClientFactory>();
        [SetUp]
        public void Init()
        {
            ///_SUT = new DepartmentController();
        }
        //[Test]
        //public void DepartmentController_
        //[Test]
        public void DepartmentController_Create_Should_Return_CreatedDeparment()
        {
            _httpFactoryMock.Setup(x => x.CreateClient(It.IsAny<string>()))
                .Returns(new HttpClient()).Verifiable();
            //var result = _SUT.CreateDepartment(It.IsAny<>());
            //Assert.IsNotNull(result);
        }
        [Test]
        public void DepartmentController_Create_Should_Return_BadRequest_When_Department_IS_Null()
        {
            var result = _SUT.CreateDepartment(null);
            Assert.AreEqual(typeof(BadRequestResult), result.GetType());
            Assert.Throws<NullReferenceException>(() => _SUT.CreateDepartment(null));

            //Assert.That(() => departmentController.Create(null), Throws.TypeOf<NullReferenceException>());
            //Assert.IsNull(result);
            //Assert.That(result.Message.GetType().Equals(typeof(NullReferenceException)));
        }
        [Test]
        public void DepartmentController_Get_Should_Return_Departments()
        {
            _httpFactoryMock.Setup(x => x.CreateClient(It.IsAny<string>()))
                .Returns(deEvent);
            var result = _SUT.GetDepartments();
            Assert.IsNotNull(result);

            /*
            var result = Assert.Throws<ArgumentNullException>(() => departmentController.Index());
            Assert.That(result.Message.GetType().Equals(typeof(ArgumentNullException)));
            Assert.That(() => departmentController.Create(null), Throws.TypeOf<ArgumentNullException>());*/
        }
    }
}
