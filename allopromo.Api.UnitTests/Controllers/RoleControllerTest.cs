using allopromo.Controllers;
using allopromo.Core.Abstract;
using Moq;
using NUnit.Framework;
namespace alloPromoTests.ApiControllers
{
    //[TestFixture]
    public class RoleControllerTest
    {
        private Mock<IUserService> _userService;
        //[Setup]
        public void Init()
        {
            _userService = new Mock<IUserService>();
        }
        [TestCase]
        public void UserController_CreatesUser_UserNull_ReturnsException()
        {
            
        }
        [TestCase]
        public void UserController_CreatesUser_ReturnCreated_User()
        {

        }
        [TestCase]
        public void UserController_GetUser_Returns_UserWithRole()
        {
        }
        //[Test]
        public void RoleController_GetRole_Returns_RoleNumber()
        {
            //var roleController = new RoleController(_userService.Object);

            //var result = userController(null);
            //Assert
            //Assert.IsTrue(result.Exception.Equals(result));
        }
    }
}