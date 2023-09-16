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
using allopromo.Api;
using allopromo.Api.Controllers;
using allopromo.Api.ViewModel.ViewModels;

namespace allopromo.Api.UnitTests
{
    [TestFixture]
    public class UserControllerTests
    {
    #region Properties
        private Mock<IUserService> _userServiceMock;
        private Mock<IAccountService> _accountService;
        #endregion
        private Mock<UserManager<IdentityUser>> _userManagerMock= new Mock<UserManager<IdentityUser>>();
        public Mock<SignInManager<IdentityUser>> _signInManagerMock = new Mock<SignInManager<IdentityUser>>();
        private UserController _SUT;

        #region Constructors
        public UserControllerTests()
        {
            _userServiceMock = new Mock<IUserService>();
            _userManagerMock = new Mock<UserManager<IdentityUser>>();

            _SUT = new UserController(_userServiceMock.Object,
                _userManagerMock.Object);
        }
        //public UserControllerTests()
        //{
        //    _userServiceMock = new Mock<IUserService>();
        //    _accountService = new Mock<IAccountService>();

        //    _SUT = new UserController(_userServiceMock.Object,
        //        _accountService.Object);

        //    /*AutoMapper.Mapper.Initialize(cfg =>
        //    {
        //        cfg.AddProfile<AutoMapperProfile>();
        //    });*/
        //}
    #endregion


    #region Create
        [Test]
        public async Task UserController_CreateUser_UserValid_PasswordValid_ReturnsOkCreated()
        {
            var registerViewModel = new RegisterViewModel
            {
                UserEmail = "alala@freee.fr",
                UserName = "fdfkdkff",
                UserPassword = "K@da120",
                UserPhoneNumber = "581-578-4401"
            };
           _userServiceMock.Setup(x => x.CreateUser(It.IsAny<string>(), It.IsAny<string>()))
              .Returns(Task.FromResult(true));
            var okResult = await _SUT.CreateUser(registerViewModel);
            Assert.IsNotNull(okResult);
            Assert.AreEqual(okResult.GetType(), typeof(OkObjectResult));
        }
        
        [Test]
        public async Task UserController_CreateUser_User_Or_Password_Invalid_ReturnsException()
        {
            _userServiceMock = new Mock<IUserService>();
            var userManager = new Mock<UserManager<IdentityUser>>();
            var registerViewModel = new RegisterViewModel
            {
                UserEmail = "alala@f.fr",
                UserName = "ff",
                UserPassword = string.Empty,
                UserPhoneNumber = ""
            };
            
            var actualResult = await _SUT.CreateUser(registerViewModel);
            Assert.AreEqual(actualResult.GetType(), typeof(BadRequestResult));

            //Assert.ThrowsAsync<Exception>(async () => await _SUT.CreateUser(registerViewModel));
        }
        [Test]
        public void UserController_CreateUser_UserIsInvalid_OrNull_SHOULD_ThrowAnException()
        {
            ApplicationUser user1 = new ApplicationUser();
            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(m => m.CreateUser(null, ""));//.ReturnsAsync(null);
            
            Assert.ThrowsAsync<Exception>(() => _SUT.CreateUser(null));
        }
        void CreateUser()
        {
            throw new Exception("Password is invalid or Empty");
        }
        [Test]
        public async Task UserController_CreateUser_Returns_NotFound()
        {   
            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(m => m.CreateUser(new ApplicationUser().UserName, "hjkjkjk6687"))
                .Returns(Task.FromResult(false));

            RegisterViewModel registerViewModel = new RegisterViewModel();
            var actualResult = await _SUT.CreateUser(registerViewModel);
            
            //var notFoundResult =  result as NotFoundResult;  // vs NotFoundObjectResult ?

            Assert.IsNotNull(actualResult);
            Assert.IsInstanceOf<BadRequestResult>(actualResult);
        }
        #endregion

        #region Read
        [Test]
        public async Task UserController_LOGIN_SHOULD_Return_Login_OrPassword_Incorrect_Error()
        {
            var result = _SUT.Login(new LoginViewModel());
            Assert.Throws<Exception>(() => _SUT.Login(new LoginViewModel()));
        }
        [Test]
        public async Task UserController_LOGIN_SHOULD_Return_UserOK()
        {
            var loginViewModel = new LoginViewModel
            {
                UserName = "support@allopay.tech",
                UserPassword = "atlanticConso@78"
            };
            var user = new IdentityUser
            {
                Id = Guid.NewGuid().ToString(),
                Email = loginViewModel.UserName,
                PasswordHash = loginViewModel.UserPassword
            };
            //_userManagerMock.Setup(x => x.CreateAsync(new RegisterViewModel())).Returns().
            var usersList = new List<IdentityUser>();

            _SUT = new UserController(_userServiceMock.Object,
                getUserManagerMock(usersList).Object);
            var result = await _SUT.Login(loginViewModel);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.GetType(), typeof(OkObjectResult));

            /*_userServiceMock.Setup(x => x//.LoginUser(user))
                                            //.LoginUser(It.IsAny<IdentityUser>()))
                                           .ValidateUserAsync(loginViewModel.UserName))
                .Returns(Task.FromResult(user));        
            _userServiceMock.Setup(x => x.ValidateUser(loginViewModel.UserName, loginViewModel.UserPassword))
                                    .Returns(true);
            */
            /*
            _userServiceMock.Setup(x => x.ValidateUser(loginViewModel.UserName, loginViewModel.UserPassword))
                            .Returns(true);
            */
            /*
            userManagerMock.Setup(x => x.FindByEmailAsync(loginViewModel.UserName))
                .Returns(Task.FromResult(user));
            */
            //Assert.IsInstanceOf<OkObjectResult>(result);
            //_userServiceMock.Verify(
            //x => x.LoginUser(It.IsAny<IdentityUser>()), Times.Once());
            //Verify((_SUT.Login(It.IsAny<LoginViewModel>), Times.Once());
        }

        [Test]
        public void UserController_GetUsers_ShouldReturnUsers_ByRole()
        {
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service.GetUsersByRole("admin"))
                            .Returns(Task.FromResult<IList<IdentityUser>>(GetUsers()));

            //var userController = new RoleController(userServiceMock.Object);
            //var expectedUsersList = userController.GetUsersByRole("admin");
            //Act
            //Assert
            // Assert.AreEqual(expectedUsersList.Result.Count,2);
            //Are result result scenario equivalent to Test Scenario ?
        }
        
        private IList<IdentityUser> GetUsers()
        {
            return new List<IdentityUser>()
            {
                new IdentityUser{ }, new IdentityUser{ }
            };
        }
        
        public void UserController_User_LOGIN_SOULD_Return_NotOKLoginOrInvalidPassword()
        {
        }
        [Test]
        public void UserController_LOGIN_ReturnsBad_Request_OrNotFound()
        {
            Mock<IUserService> userService = new Mock<IUserService>();
            Mock<UserManager<IAccountService>> userManager = new Mock<UserManager<IAccountService>>();
        }
        [Test]
        public void UserController_LOGIN_SHOULD_ReturnsNull()
        {
            Mock<IUserService> userService = new Mock<IUserService>();
            Mock<UserManager<IAccountService>> userManager = 
                new Mock<UserManager<IAccountService>>();

        }
        private static Mock<UserManager<IdentityUser>> GetUserManagerMock()
        {
            var storeMock = new Mock<IUserStore<IdentityUser>>();
            return new Mock<UserManager<IdentityUser>>(storeMock.Object,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null);
        }
        #endregion
        public static Mock<UserManager<TUser>> getUserManagerMock<TUser>(List <TUser> usersList) where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            var manager = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
            manager.Object.UserValidators.Add(new UserValidator<TUser>());
            manager.Object.PasswordValidators.Add(new PasswordValidator<TUser>());

            manager.Setup(x => x.DeleteAsync(It.IsAny<TUser>())).ReturnsAsync((IdentityResult.Success));
            manager.Setup(x=>x.CreateAsync(It.IsAny<TUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success)
                .Callback<TUser, string>((x, y)=>usersList.Add(x));
            manager.Setup(x => x.UpdateAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);
            return manager;

        }

    #region Update
    #endregion


    }

    #region DELETE
    #endregion



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
/*
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

//Collection Initializer IEnumerable !?
//_userServiceMock.Setup(m => m.CreateUser(It.IsAny<ApplicationUser>,""))
//.Returns((Task<bool> result)=> {return result;});
//.Returns((Task<bool> result, string nr) => { return Task.FromResult(new bool()); });

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