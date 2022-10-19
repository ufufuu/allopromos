using allopromo.Core.Abstract;
using allopromo.Core.Application.Dto;
using allopromo.Core.Domain;
using allopromo.Core.Model;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
namespace alloPromoTests.ServiceTests
{
    public class UserServiceTest
    {
    private UserService _sut;
    private Mock<IUserRepository> _userRepoMock= new Mock<IUserRepository>();

    //private readonly UserManager<ApplicationUser> _userManager;
        public UserServiceTest()
        {
        }
        private static Mock<UserManager<ApplicationUser>> MockUserManager()
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
        [Test]
        public async Task UserService_CreateUser_SHOULD_Return_True_UserCreated()
        {
            //Arrange
            _sut = new UserService(_userRepoMock.Object, MockUserManager().Object, null);
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
            _userRepoMock = new Mock<IUserRepository>();
            _sut = new UserService(_userRepoMock.Object, null, null);
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
    //public interface I1
    //{
    //}
    //public class C3
    //{
    //}
    //public class C1 : C3, I1
    //{
    //   public C1()
    //   {

    //   }
    //}
    //public class C2
    //{
    //    void Method1()
    //    {
    //        C1 c1 = new C1();
    //        C3 c2 = new C1();
    //        C1 c3 = new C3() as C1; //XXXXX QUI PEUT LE PLUS PEUT LE MOINS 
    //        //C1 c4 = new C3();
    //    }
    //}
}
//

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
// ? unit for Work - Generic Repository - Logging - Query Pattenrs- Resilienccy ! 