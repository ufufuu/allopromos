using System;
using System.Collections.Generic;
using System.Text;
using NUnit;
using NUnit.Framework;
using NUnit.Compatibility;
using allopromo.Admin.Areas.Manage.Controllers;
using Moq;
using allopromo.Admin.Models.ViewModel;
namespace allopromo.Admin.UnitTests.UnitTests.Controllers
{
    [TestFixture]
    public class UsersControllerTests
    {
        [Test]
        public void Return_SHOULD_ReturnUsersDto()
        {
            var userController = new UsersController();
            var listUsers = userController.Index(It.IsAny<IEnumerable<LoginViewModel>>());
            Assert.IsNotNull(listUsers);
        }
    }
}
