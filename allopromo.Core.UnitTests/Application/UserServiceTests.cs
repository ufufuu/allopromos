using allopromo.Core.Abstract;
using allopromo.Core.Application.Dto;
using allopromo.Core.Domain;
using allopromo.Core.Model;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Core.UnitTests
{
    public class UserServiceTest
    {
        private UserService _sut;
        private Mock<IRepository<ApplicationUser>> _userRepoMock= new Mock<IRepository<ApplicationUser>>();
        private Mock<UserManager<ApplicationUser>> _userManagerMock = new Mock<UserManager<ApplicationUser>>();
        private Mock<SignInManager<ApplicationUser>> signInManager = new Mock<SignInManager<ApplicationUser>>();
        public UserServiceTest()
        {
            _sut = new UserService(_userRepoMock.Object, MockUserManager().Object, 
                GetSignInManagerMock().Object);
        }
        private static Mock<SignInManager<ApplicationUser>> GetSignInManagerMock()
        {
            var signManagerMock = new Mock<IRoleStore<ApplicationUser>>();
            //return signManagerMock.Object;
            return new Mock<SignInManager<ApplicationUser>>();
        }
        private Mock<SignInManager<ApplicationUser>> GetMockSignInManager()
        {
            var mockUsrMgr = MockUserManager();
            //var mockAuthMgr = new Mock<AuthenticationManager>();
            return new Mock<SignInManager<ApplicationUser>>(mockUsrMgr.Object); //, mockAuthMgr.Object);
        }
        private static Mock<UserManager<ApplicationUser>> MockUserManager()
        {
            var storeMock = new Mock<IUserStore<ApplicationUser>>();
            return new Mock<UserManager<ApplicationUser>>
                (
                storeMock.Object,null,null,null,null,null,null,null,null
         );
        }
        [Test]
        public void UserService_GetUsers_SHOULD_Return_Users_With_Roles()
        {
            _userManagerMock.Setup(x => x.Users).Returns(GetUsers());
            _userRepoMock.Setup(x => x.GetAllAsync()).Returns(GetUsersAsync());

            var t = _sut;
            var usersWithRoles = _sut.GetUsersWithRoles();
            var userWithRole = usersWithRoles.Result.FirstOrDefault();
            Assert.IsNotNull(usersWithRoles.Result.FirstOrDefault().UserRoles);
            Assert.IsNotNull(usersWithRoles);
            _userRepoMock.Verify(x => x.GetAllAsync(), Times.Once());
        }
        private IQueryable<ApplicationUser> GetUsers()
        {
            IList<ApplicationUser> users = new List<ApplicationUser>();
            return users.AsQueryable();
        }
        private async Task<IQueryable<ApplicationUser>> GetUsersAsync()
        {
            var result = await Task.Run(() => getUsers());
                return result.AsQueryable();
        }
        private List<ApplicationUser> getUsers()
        {
            IList<ApplicationUser> appUsers = new List<ApplicationUser>();
            return appUsers.ToList();
        }
        [Test]
        public async Task UserService_CreateUser_SHOULD_Return_True_UserCreated()
        {
            //Arrange
            ApplicationUser user = new ApplicationUser
            {
                 Email="dgdgdg@hhdhddh.fr",
            };
            //Act
            var result = await _sut?.CreateUser(user, "kjk788kkk");
            //Assert
            Assert.IsNotNull(result);
            //Assert.IsTrue(result.Equals(true));

        }
        [Test]
        public async Task UserService_CreateUser_SHOULD_Returns_False_ifUserNull()
        {
            _userRepoMock = new Mock<IRepository<ApplicationUser>>();
            var result = await _sut.CreateUser(null, "kjk788kkk");

            //Assert.Throws<Exception>(async () => await _sut.CreateUser(null, "akaj4i"));
            //Assert.ThrowsAsync<Exception>(async () =>await _sut.CreateUser(null, "kjk788kkk"));
            //Assert.Throws<>("");
            //User cann/ne eut etre null
            Assert.IsTrue(result.Equals(false));
        }
        //[Test]
        public void UserService_CreateUser_Returns_UserCreated()
        {
           Task<bool> result= _sut.CreateUser(new ApplicationUser { }, "");
            Assert.IsNotNull(result);
        }
        //[Test]
        public void UserService_CreateUser_Returns_Exception()
        {
            throw new  ArgumentNullException();
        }
    }
    //        C3 c2 = new C1();
    //        C1 c3 = new C3() as C1; //XXXXX QUI PEUT LE PLUS PEUT LE MOINS
}

/// new , present myself - intro if the course
/// 
//what i do ?
//start - present proecjt - like , sub
//pblm
// vs entreprise testing lines ! live uinit testing
//InlineData("six ' eight \"", false, 0) => Nuinit ??
//CreateUser_Suuceeess, cretePerson_throwsexc
//htmlAgilityPack - newtonSoft - Nuget.Core -
//ca va ca va
// ? unit for Work - Generic Repository - Logging - Query Pattenrs- Resilienccy