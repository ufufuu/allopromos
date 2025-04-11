using allopromo.Controllers;
using allopromo.Core.Abstract;
using Moq;
using NUnit.Framework;
namespace allopromo.Api.UnitTests
{

    //[TestFixture]

    public class RoleControllerTest
    {
        private Mock<IUserService> _userService;
        private RoleController _SUT; 

        //[Setup]
        public void Init()
        {
            _userService = new Mock<IUserService>();
            //_SUT= new RoleController(_userService.Object);
        }
        [TestCase]
        public void UserController_CreateRole_ReturnCreated_Role()
        {
            var role = _SUT.CreateRole("ADMINISTRATOR");
            Assert.IsNotNull(role);
        }
        [TestCase]
        public void UserController_CreateRole_UserNull_ReturnsException()
        {
        }
        [TestCase]
        public void UserController_GetRole_Returns_UserWithRole()
        {
        }

        public void RoleController_GetRole_Returns_RoleNumber()
        {
        }
    }
}