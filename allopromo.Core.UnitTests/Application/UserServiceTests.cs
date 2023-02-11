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
        private Mock<SignInManager<ApplicationUser>> _signInManager = new Mock<SignInManager<ApplicationUser>>();
        public UserServiceTest()
        {
            //AutoMapper.Mapper.Initialize(cfg =>{ 
              // cfg.AddProfile<AutoMapperProfileCore>();
            //});

            //_sut = new UserService(_userRepoMock.Object, _userManagerMock.Object, _signInManager.Object);
            _sut = new UserService(_userRepoMock.Object,
                MockUserManager().Object, null
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
        private static Mock<UserManager<ApplicationUser>> MockUserManager()
        {
            var storeMock = new Mock<IUserStore<ApplicationUser>>();
            return new Mock<UserManager<ApplicationUser>>(
                storeMock.Object,null,null,null,null,null,null,null,null
         );
        }
        [Test]
        public async Task UserService_GetUsers_SHOULD_Return_Users_With_RolesAsync()
        {
            _userManagerMock.Setup(x => x.Users).Returns(GetUsers());
            _userRepoMock.Setup(x => x.GetAllAsync()).Returns(GetUsersAsync());
            var usersWithRoles = await _sut.GetUsersWithRoles();
            //Assert.IsNotNull(usersWithRoles.Result.FirstOrDefault().UserRoles);
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
        public async Task UserService_CreateUser_SHOULD_Returns_False_ifUserNull()
        {
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