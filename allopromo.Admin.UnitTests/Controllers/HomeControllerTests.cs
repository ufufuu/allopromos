using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using allopromo.Admin;
using System.Net.Http;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace allopromo.Admin.UnitTests.Controllers
{
    public delegate IActionResult delRe();
    [TestFixture]
    public class HomeControllerTests
    {
        private event delRe deEvent;
        private Mock<ILogger<Admin.Controllers.HomeController>> _loggerMock =
            new Mock<ILogger<Admin.Controllers.HomeController>>();
        private Admin.Controllers.HomeController homeController; // =
        private Mock<HttpClient> _httpMock = new Mock<HttpClient>();
        private Mock<IHttpClientFactory> _httpFactoryMock = new Mock<IHttpClientFactory>();

        [Test]
        public void HomeController_Index_Should_Return_View()
        {
            var homeController = new Admin.Controllers.HomeController(_httpFactoryMock.Object, null);
            var result = homeController.Index();
            Assert.IsNotNull(result);
            Assert.AreEqual(result.GetType(), typeof(ViewResult));
        }
        //[Test]
        public void HomeController_Login_Should_Return_LoginFailed()
        {
            _httpFactoryMock.Setup(x => x.CreateClient(It.IsAny<string>()))//"", It.IsAny<StringContent>()))
                .Returns(new HttpClient()).Verifiable();
            var homeController = new Admin.Controllers.HomeController(_httpFactoryMock.Object, null);
            var result = homeController.Index(It.IsAny<Models.ViewModel.LoginViewModel>());
            Assert.IsNotNull(result);
        }
        [Test]
        public void HomeController_Login_Should_Raise_Exception_When_Argument_IsNull()
        {
            var homeController = new Admin.Controllers.HomeController(_httpFactoryMock.Object, null);
            //var result = homeController.Index();
            //Assert.IsNotNull(result);
            var result = Assert.Throws<ArgumentNullException>(() => homeController.Index(null));
        }
        //[Test]
        public void HomeController_Should_Return_Failed_When_ExceptionRaised()
        {
            var homeController = new Admin.Controllers.HomeController(_httpFactoryMock.Object, null);
            var result = Assert.Throws<ArgumentNullException>(() => homeController.Index());

            deEvent += RaiseException;
            _httpFactoryMock.Setup(x => x.CreateClient(It.IsAny<string>()))
                .Returns(deEvent);
        }
        [Test]
        public void HomeController_Login_Should_Return_Succeded()
        {
        }
        private IActionResult RaiseException()
        {
            return new  NotFoundResult();
        }
        private Exception ArgumentNUllRaisesException()
        {
            throw new ArgumentNullException();
        }
    }
}
