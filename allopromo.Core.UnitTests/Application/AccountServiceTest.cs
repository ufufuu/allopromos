using allopromo.Core.Abstract;
using allopromo.Core.Domain;
using allopromo.Core.Model;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
namespace allopromo.Core.UnitTests
{
    //[TestFixture]
    public class AccountServiceTest
    {
        private Mock<IUserRepository> userRepo = new Mock<IUserRepository>();
        private Mock<IRepository<ApplicationUser>> _userRepo= new Mock<IRepository<ApplicationUser>>();
        private UserService _SUT;

        private Mock<UserManager<ApplicationUser>> _userManager= new Mock<UserManager<ApplicationUser>>();
        public AccountServiceTest()
        {
            //_SUT = new UserService(); // (userRepo.Object, _userManager.Object, );
        }
        /*
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
        }*/

        //[Test]
        //[TestCase(null, "kdjfdkfjCategorieService
        //[TestCase("user" , "kdjfdkfjCategorieService
        public async Task UserService_CreateUser_Returns_UserNotCreated()
        //public async Task UserService_CreateUser_Returns_UserNotCreated(, "")
        {
            
            // ?  below null and null in constructor according to Tim Corey ins Mock youtube DB videos, Let's Try !
            var result = await _SUT.CreateUser(new ApplicationUser().UserName, "kjk788kkk");

            Assert.IsTrue(result.Equals(false));
        }
        //[Test]
        public async Task UserService_CreateUser_Returns_UserNotCreated_False()
        {
            _userRepo = new Mock<IRepository<ApplicationUser>>();
            
            var result = await _SUT.CreateUser(null, "kjk788kkk");

            //Assert.Throws<Exception>(async () => await _SUT.CreateUser(null, "akaj4i"));
            //Assert.ThrowsAsync<Exception>(async () =>await _SUT.CreateUser(null, "kjk788kkk"));
            //Assert.Throws<>("");
            //User cann/ne eut etre null
            Assert.IsTrue(result.Equals(false));
        }
        //[Test]
        public void UserService_CreateUser_Returns_UserCreated()
        {
           Task<bool> result= _SUT.CreateUser(new ApplicationUser { }.UserName, "");
            Assert.IsNotNull(result);
        }
        //[Test]
        public void UserService_CreateUser_Returns_Exception()
        {
            
        }
    }
    public interface I1
    {
    }
    public class C3
    {
    }
    public class C1 : C3, I1
    {
       public C1()
       {

       }
    }
    public class C2
    {
        void Method1()
        {
            C1 c1 = new C1();
            C3 c2 = new C1();
            C1 c3 = new C3() as C1; //XXXXX QUI PEUT LE PLUS PEUT LE MOINS 
            //C1 c4 = new C3();
        }
    }
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

