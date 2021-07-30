using System.Collections.Generic;
using allopromo.Controllers;
using NUnit.Framework;
using Moq;
using allopromoDataAccess.Model;
using allopromoServiceLayer.Abstract;
using System.Threading.Tasks;
namespace alloPromoTests.ControllerTests
{
    [TestFixture]
    public class UserControllerTests
    {
        private UserRepository _userRepository;
        private Mock<IUserService> _userServiceMock;
        [SetUp]
        public void Setup()
        {
            //user-- Init Setup
            _userServiceMock = new Mock<IUserService>();
        }
        [TearDown]
        public void TearDown()
        {
        }
        [Test]
        public void UserController_CreateUser_UserIsNull()
        {
            //Arrange
            ApplicationUser user = null;
            _userServiceMock.Setup(x => x.CreateUser(user, ""));
            //Act
            var userController = new UserController(_userServiceMock.Object);
            var actualResult = userController.CreateUser(new User { }).Result;

            var expectedResult = false;
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void UserController_CreateUser_UserInvalidPasswordIsEmpty()
        {
            //Arrange
            ApplicationUser user = new ApplicationUser { PasswordHash = "" };

            //Act

            //Assert
        }
        [Test]
        public void GetUsers_ShouldReturnUsersByRole()
        {
            var actualUsersList = new List<ApplicationUser>
            {
                new ApplicationUser{}, new ApplicationUser{}
            };
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service.GetUsersByRole("admin"))
                            .Returns(Task.FromResult<IList<ApplicationUser>>(actualUsersList));
            var userController = new UserController(userServiceMock.Object);
            var expectedUsersList = userController.GetUsersByRole("admin");
            //Act

            //Assert
            Assert.AreEqual(expectedUsersList.Result.Count,2);
        }
        public void UserController_Login_UserIsNull()
        {

        }
    }
}

// Cash On Delivery
// Wallets - Stored 
// Signup -- phone :
// Add to the Cart -->
// placing the order ---> driver Assigned -- > customer can track 
//| Admin Panel - Customer app - driver App --

// As Put Manually items ----from my merchant 
// onBoard Merchants --

//Once a delevery is made, driver is paid

//create item <-----> reflected on the customer application --
//delivery ---released on the Admin| Portal 

//Grocery Delivery ----uploading vegetable ---

//Merchant Panel ---!!!! Customer App //  ---

//$ 5000 (12 00$) -- milestones --- 20% --- bi-weekly --- 4/3 weeks ::::30% ---50 ---last payment ----:::live ongoing 

//http:// www-e@mail@:::
// next 3-months 


//free maintenance :::: 3 months --’’

/// Social market Social Marketing ------////
/// Assign Approach Merchants 
/// 
// Account Manager : business ongoing | Project Managers


// Prime Numbers and Composite Number btw/n 1-200
// biz manager --04 am -- 
// 4 pm ---><---

//1. Create and Assign Role to User
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
 * 
 * 
 * Change to 07.2021 to "Current", "Present"
 * Analyst - Programmer : Working Remotly 
 * Env. Libraires | Looking for new Learning Opportunity and Stability ---dec 2019
 * 
 * Reason depart: 228auto.com & toutoutil are owned 
 * 228auto & asked me to transfer to 
 * 
 * 05-
 * 
 * 10- 2017 ///04-2018::::did not do much ! ::::What ------> I:::::
 * Dakaya Sarl- 2010 
 * Valuable to Put 
 * Remove Uber Eats 
z * Create Another JoB ------::::for DAKAYA:::::::--------ELiminate Autres Experiences --->
 * Leave Personnal Project ::::::
 * 
 * 
 * 
 * Combine F-30
 * 
 * Take Item in F-30 and modify 
 * f-40 chart is the One I am going target !
 * Consolidate f-40
 * 
 */
