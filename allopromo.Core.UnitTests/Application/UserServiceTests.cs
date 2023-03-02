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
        private Mock<UserManager<IdentityUser>> _userManagerMock = new Mock<UserManager<IdentityUser>>();
        private Mock<SignInManager<ApplicationUser>> _signInManager = new Mock<SignInManager<ApplicationUser>>();
        private Mock<RoleManager<ApplicationRole>> _roleManager = new Mock<RoleManager<ApplicationRole>>();
        public UserServiceTest()
        {
            //AutoMapper.Mapper.Initialize(cfg =>{ 
              // cfg.AddProfile<AutoMapperProfileCore>();
            //});
            //_sut = new UserService(_userRepoMock.Object, _userManagerMock.Object, _signInManager.Object);

            _sut = new UserService(MockUserManager().Object,
                                    null, // _roleManager.Object
                                    GetMockRoleManager().Object
           );
        }
        //[SetUp]
        //public void Init()
        //{
        //    AutoMapper.Mapper.Initialize(cfg => {
        //        cfg.AddProfile<AutoMapperProfileCore>();
        //    });
        //}

        //[TearDown]
        //public void Reset()
        //{
        //   AutoMapper.Mapper.Reset();
        //}
        private static Mock<SignInManager<ApplicationUser>> GetSignInManagerMock()
        {
            var signManagerMock = new Mock<IRoleStore<ApplicationUser>>();
            return (Mock<SignInManager<ApplicationUser>>)signManagerMock.Object;
        }
        private Mock<SignInManager<ApplicationUser>> GetMockSignInManager()
        {
            var mockUsrMgr = MockUserManager();
            return new Mock<SignInManager<ApplicationUser>>(mockUsrMgr.Object);
        }
        private static Mock<UserManager<IdentityUser>> MockUserManager()
        {
            var storeMock = new Mock<IUserStore<IdentityUser>>();
            return new Mock<UserManager<IdentityUser>>(
                storeMock.Object,null,null,null,null,null,null,null,null
         );
        }

        //private static Mock<RoleManager<IdentityRole>> MockRoleManager()
        //{
        //    var roleStore = new Mock<IUserStore<ApplicationUser>>();
        //    return new RoleManager<IdentityRole>(roleStore.Object);
        //}

        private static Mock<RoleManager<IdentityRole>> GetMockRoleManager()
        {
            var roleStore = new Mock<IRoleStore<IdentityRole>>();
            return new Mock<RoleManager<IdentityRole>>(
                roleStore.Object, null, null, null, null);
        }
        [Test]
        public async Task UserService_GetUsers_SHOULD_Return_Users_With_RolesAsync()
        {
            _userManagerMock.Setup(x => x.Users).Returns(GetUsers());
            
            var usersWithRoles = await _sut.GetUsersWithRoles();
            //Assert.IsNotNull(usersWithRoles.Result.FirstOrDefault().UserRoles);
            Assert.IsNotNull(usersWithRoles);
            _userManagerMock.Verify(x => x.GetUsersInRoleAsync("users"), Times.Once());
        }
        private IQueryable<IdentityUser> GetUsers()
        {
            IList<IdentityUser> users = new List<IdentityUser>();
            return users.AsQueryable();
        }
        private async Task<IQueryable<IdentityUser>> GetUsersAsync()
        {
            var result = await Task.Run(() => GetUsers());
                return result.AsQueryable();
        }
        [Test]
        public async Task UserService_CreateUser_SHOULD_Return_True_UserCreated()
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName="all@promo.fr",
                Email="all@promo.fr",
            };
            var result = await _sut?.CreateUser(user.UserName, "kjk788kkk");
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }
        [Test]
        public void UserService_CreateUser_SHOULD_Returns_False_ifUserNull()
        {
            Assert.ThrowsAsync<Exception>(async() =>await _sut.CreateUser(null, "kjk788kkk"));
        }
        //[Test]
        public void UserService_CreateUser_Returns_UserCreated()
        {
           Task<bool> result= _sut.CreateUser(new ApplicationUser { }.UserName, "");
            Assert.IsNotNull(result);
        }
        //[Test]
        public void UserService_CreateUser_Returns_Exception()
        {
            throw new  ArgumentNullException();
        }
    }
// C3 c2 = new C1();
// C1 c3 = new C3() as C1; //XXXXX QUI PEUT LE PLUS PEUT LE MOINS
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