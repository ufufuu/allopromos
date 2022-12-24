using System.Collections.Generic;
using allopromo.Controllers;
using NUnit.Framework;
using Moq;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using allopromo.Core.Abstract;
using allopromo.Core.Model;
using allopromo.Core.Model.ApiResponse;
using allopromo.Core.Domain;
namespace allopromo.Api.UnitTests
{
    //[TestFixture]
    public class UserControllerTests
    {
        public UserControllerTests()
        {
            _userServiceMock = new Mock<IUserService>();
            _accountController = new UserController(_userServiceMock.Object);
        }
        private Mock<IUserService> _userServiceMock;
        private UserController _accountController;
        public void AccountController_CreateUser_UserIsInvalidOrNull_ReturnsNull()
        {
            ApplicationUser user1 = new ApplicationUser();
            _userServiceMock = new Mock<IUserService>();
            /*
            _userServiceMock.Setup(m => m.CreateUser(new ApplicationUser(), ""))
                .ReturnsAsync(null);
            */
            _userServiceMock.Setup(m => m.CreateUser(null, "")); //.ReturnsAsync(null);
            _accountController = new UserController(_userServiceMock.Object);
            var actualResult = _accountController.CreateUser(null).Result; //Why Result ?
            Assert.IsNull(actualResult);
        }
        void CreateUser()
        {
            throw new Exception("Password is invalid or Empty");
        }
        //[Test]
        public void AccountController_CreateUser_UserPassword_Invalid_Or_Empty_ReturnsException()
        {
            _userServiceMock = new Mock<IUserService>();
            var ApplicationUser = new Model.ViewModel.RegisterViewModel
            {
                Email = "alala@f.fr",
                UserName = "ff",
                UserPassword = string.Empty,
                PhoneNumber = ""
            };
            _accountController = new UserController(_userServiceMock.Object);
            //Act 
            //var actualResult = _accountController.CreateUser(ApplicationUser);
           // Assert.ThrowsAsync<Exception>(async () => await _accountController.CreateUser(ApplicationUser)); ;
        }
        //Collection Initializer IEnumerable !?
        //_userServiceMock.Setup(m => m.CreateUser(It.IsAny<ApplicationUser>,"")).Returns((Task<bool> result)=> {return result;});
        //.Returns((Task<bool> result, string nr) => { return Task.FromResult(new bool()); });
        //[Test]
        public async Task AccountController_CreateUser_UserValid_ReturnsOkCreated()
        {
            _userServiceMock = new Mock<IUserService>();
            var ApplicationUser = new Model.ViewModel.RegisterViewModel
            {
                Email = "alala@freee.fr",
                UserName = "fdfkdkff",
                UserPassword = "K@da120",
                PhoneNumber = "581-578-4401"
            };
            _userServiceMock.Setup(m => m.CreateUser(new ApplicationUser(), ""))
            .ReturnsAsync(true);
            _accountController = new UserController(_userServiceMock.Object);
            //Act
            //var actualResult = _accountController.CreateUser(ApplicationUser);
            //Assert
            //var result = actualResult as IActionResult;
            //var res1 = await actualResult;
            //var okResult = await actualResult as OkObjectResult;
            // When Do we Need Setup of Mock ?
            //Assert.AreEqual(okResult.StatusCode, 200);
            //var userT = okResult.Value as ApplicationUser;
            //Assert.IsNotNull(okResult);
        }
        public async Task AccountController_CreateUser_Returns_NotFound()
        {   
            //Arrange
            var ApplicationUser = new Model.ViewModel.RegisterViewModel
            {
                Email = "fddssd",
                UserName = "cvcvcv",
                UserPassword = "rt5465",
                PhoneNumber = "899-898-3566"
            };
            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(m => m.CreateUser(new ApplicationUser(), "hjkjkjk6687"))
                .ReturnsAsync(false);
            //Act
            _accountController = new UserController(_userServiceMock.Object);
            //var actualResult = _accountController.CreateUser(ApplicationUser);
            //var result = await actualResult;
            //var notFoundResult =  result as NotFoundResult;  // vs NotFoundObjectResult ?
            //Assert.IsNotNull(notFoundResult);
            //Assert.IsInstanceOf<NotFoundResult>(notFoundResult);
        }
        //[Test]
        public void AccountController_GetUsers_ShouldReturnUsersByRole()
        {
            var actualUsersList = new List<ApplicationUser>
            {
                new ApplicationUser{}, new ApplicationUser{}
            };
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service.GetUsersByRole("admin"))
                            .Returns(Task.FromResult<IList<ApplicationUser>>(actualUsersList));

            //var userController = new RoleController(userServiceMock.Object);
            //var expectedUsersList = userController.GetUsersByRole("admin");
            //Act
            //Assert
            // Assert.AreEqual(expectedUsersList.Result.Count,2);
            //Are result result scenario equivalent to Test Scenario ?

        }
        [Test]
        public void AccountController_Login_Returns_User()
        {
            //Arrange
            //Mock<UserService> userServiceMock = new Mock<UserService>() @errAbaophone43;
            var ApplicationUser = new ApplicationUser
            {
                UserName = "couli.mama@free.fr",
                PasswordHash = "errAbaophone43"
            };
            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(x => x.LoginUser(ApplicationUser)).Returns(true);
            _userServiceMock.Setup(y => y.GetUserIfExist(ApplicationUser.UserName)).Returns(ApplicationUser);

            //var ApplicationUser = new ApplicationUser {Email = "couli.mama@free.fr"};
            var userDto = new ApplicationUser
            {
                UserName = "couli.mama@free.fr",
                //UserRole = "Merchant",
            };
            var userLoginResponse = new ApiResponseModel
            {
                userResponse = userDto,
                jwtToken = "TOEKEKEKNN"
            };
            //var loginUser = null //new LoginModel{
                //userName = "couli.mama@free.fr",
                //userPassword= "@errAbaophone43",
            //};
            //Act
            var userController = new UserController(_userServiceMock.Object);//,GetUserManagerMock().Object);
            //var okUser = userController.Login(loginUser);

            //Assert
           // Assert.IsNotNull(okUser);

            //Assert.IsInstanceOf<OkObjectResult>(okUser);
            //Assert.IsTrue(okUser.Equals((IActionResult)userDto));
        }
        [Test]
        public void AccountController_Login_ReturnsBad_Request_OrNotFound()
        {
            //Arrange
            Mock<IUserService> userService = new Mock<IUserService>();
            Mock<UserManager<IAccountService>> userManager = new Mock<UserManager<IAccountService>>();
            //Act
            //Assert
        }
        [Test]
        public void AccountController_Login_ReturnsNull()
        {
            //Arrange
            Mock<IUserService> userService = new Mock<IUserService>();
            Mock<UserManager<IAccountService>> userManager = new Mock<UserManager<IAccountService>>();
        }
        private static Mock<UserManager<ApplicationUser>> GetUserManagerMock()
        {
            var storeMock = new Mock<IUserStore<ApplicationUser>>();
            return new Mock<UserManager<ApplicationUser>>(storeMock.Object,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null);
        }
    }
}
// Cash On Delivery - Wallets - Stored - Signup -- phone : -- Add to the Cart -->
// placing the order ---> driver Assigned -- > customer can track 
//| Admin Panel - Customer app - driver App --
// As Put Manually items ----from my merchant -  onBoard Merchants --
//Once a delevery is made, driver is paid
//create item <-----> reflected on the customer application --
//delivery ---released on the Admin| Portal 

//Grocery Delivery ----uploading vegetable ---Merchant Panel ---!!!! Customer App //  ---

//$ 5000 (12 00$) -- milestones --- 20% --- bi-weekly --- 4/3 weeks ::::30% ---50 ---last payment ----:::live ongoing 

//http:// www-e@mail@::: - next 3-months - free maintenance :::: 3 months --’’

/// Social market Social Marketing ------////
/// Assign Approach Merchants - Account Manager : business ongoing | Project Managers

// Prime Numbers and Composite Number btw/n 1-200 - biz manager --04 am --  4 pm ---><---

//1. Create and Assign Role to ApplicationUser
// 2. Test 
//3. Seed Roles 
//4. Add Column or Create Table for Wallet ?
//
//Curriculum en Anglais !
/*
 * Modification - in the 
 * Customize my Resume
 * After 3 months Probation Period -- Ready to Relocate to Montreal
 * Downtown Montreal | 
 * Grow to 2 more Back-end Developers - 2 more front-end 
 * Challenging 
 * Opportunity to Grow Professional | 
 * Change to 07.2021 to "Current", "Present"
 * Analyst - Programmer : Working Remotly 
 * Env. Libraires | Looking for new Learning Opportunity and Stability ---dec 2019
 * Reason depart: 228auto.com & toutoutil are owned 
 * 228auto & asked me to transfer to 
 * 05-
 * 10- 2017 ///04-2018::::did not do much ! ::::What ------> I:::::
 * Dakaya Sarl- 2010 
 * Valuable to Put 
 * Remove Uber Eats 
 * Create Another JoB ------::::for DAKAYA:::::::--------ELiminate Autres Experiences --->
 * Leave Personnal Project ::::::
 * Combine F-30
 * Take Item in F-30 and modify 
 * f-40 chart is the One I am going target !
 * Consolidate f-40
 * //DealDash !q
 */
public class T1
{

}
public class T2 : T1
{

}
public class Vei
{
    T1 t1 = new T2();
    //T2 ett = new T1();
}