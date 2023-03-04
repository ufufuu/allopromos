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
        #region Properties
        private UserService _sut;
        private Mock<UserManager<IdentityUser>> _userManagerMock = new Mock<UserManager<IdentityUser>>();
        private Mock<SignInManager<ApplicationUser>> _signInManager = new Mock<SignInManager<ApplicationUser>>();
        private Mock<RoleManager<IdentityRole>> _roleManagerMock = new Mock<RoleManager<IdentityRole>>();
        #endregion

        #region Constructeurs
        public UserServiceTest()
        {
            _sut = new UserService(MockUserManager().Object,
                                    null, // _roleManager.Object
                                    GetMockRoleManager().Object
           );
        }
        #endregion

        #region Read
        [Test]
        public async Task UserService_GetUsersAsync_SHOULD_Return_Users_With_RolesAsync()
        {
            _userManagerMock.Setup(x => x.Users).Returns(GetUsers());
            var usersWithRoles = await _sut.GetUsersAsync();
            Assert.IsNotNull(usersWithRoles);
            Assert.IsNotNull(usersWithRoles);
            _userManagerMock.Verify(x => x.GetUsersInRoleAsync("Users"), Times.Once());
        }
        [Test]
        public void UserService_GetRoles_SHOULD_Return_Roles()
        {
            var roles = _sut.GetAllRoles();
            Assert.IsNotNull(roles);
        }
        #endregion

        #region Create
        [Test]
        public async Task UserService_CreateUser_SHOULD_Return_True_UserCreated()
        {
            IdentityUser user = new IdentityUser
            {
                UserName="all@promo.fr",
                Email="all@promo.fr",
            };
            var result = await _sut?.CreateUser("support@allopromo.ca", "atlanticCons@78");
            IdentityRole role = new IdentityRole
            {
                Name = "Merchants",
                Id = Guid.NewGuid().ToString(),
            };
            var appUser = _userManagerMock.Setup(x => x.CreateAsync(user))
                .Returns(Task.FromResult(new IdentityResult()));
            var appRole = _roleManagerMock.Setup(x => x.CreateAsync(role))
                .Returns(Task.FromResult(new IdentityResult()));
            Assert.IsNotNull(result);            
            Assert.IsTrue(result);

            //_userManagerMock.Verify(x => x.AddToRoleAsync(user, "Merchants"), Times.Once());
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

        #endregion

        #region Private Methods
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
                storeMock.Object, null, null, null, null, null, null, null, null
         );
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

        private static Mock<RoleManager<IdentityRole>> GetMockRoleManager()
        {
            var roleStore = new Mock<IRoleStore<IdentityRole>>();
            return new Mock<RoleManager<IdentityRole>>(
                roleStore.Object, null, null, null, null);
        }
        //private static Mock<RoleManager<IdentityRole>> MockRoleManager()
        //{
        //    var roleStore = new Mock<IUserStore<IdentityUser>>();
        //    return new RoleManager<IdentityRole>(roleStore.Object);
        //}
        #endregion

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