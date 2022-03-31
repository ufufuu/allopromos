#pragma warning disable CS0234 // The type or namespace name 'Abstract' does not exist in the namespace 'allopromo.Data' (are you missing an assembly reference?)
#pragma warning restore CS0234 // The type or namespace name 'Abstract' does not exist in the namespace 'allopromo.Data' (are you missing an assembly reference?)
#pragma warning disable CS0234 // The type or namespace name 'Model' does not exist in the namespace 'allopromo.Data' (are you missing an assembly reference?)
#pragma warning restore CS0234 // The type or namespace name 'Model' does not exist in the namespace 'allopromo.Data' (are you missing an assembly reference?)
using allopromo.Core.Abstract;
using allopromo.Core.Domain;
using allopromo.Core.Model;
using Microsoft.AspNetCore.Identity;
using Moq;
#pragma warning disable CS0246 // The type or namespace name 'NUnit' could not be found (are you missing a using directive or an assembly reference?)
using NUnit.Framework;
#pragma warning restore CS0246 // The type or namespace name 'NUnit' could not be found (are you missing a using directive or an assembly reference?)
using System;
using System.Threading.Tasks;
namespace allopromo.Core.UnitTests
{
    //[TestFixture]
    public class AccountServiceTest
    {
        private  UserService _userService;
#pragma warning disable CS0246 // The type or namespace name 'IRepository' could not be found (are you missing a using directive or an assembly reference?)
        private Mock<IUserRepository> _userRepo= new Mock<IUserRepository>();
#pragma warning restore CS0246 // The type or namespace name 'IRepository' could not be found (are you missing a using directive or an assembly reference?)

        //private Mock<UserManager<ApplicationUser>> _userManager= new Mock<UserManager<ApplicationUser>>();
        //public static Mock<UserManager<TUser>> MockUserManager<TUser>(List<TUser> ls) where TUser : class
        public AccountServiceTest()
        {
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

#pragma warning disable CS0246 // The type or namespace name 'TestAttribute' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning disable CS0246 // The type or namespace name 'Test' could not be found (are you missing a using directive or an assembly reference?)
        [Test]
#pragma warning restore CS0246 // The type or namespace name 'Test' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning restore CS0246 // The type or namespace name 'TestAttribute' could not be found (are you missing a using directive or an assembly reference?)
        //[TestCase(null, "kdjfdkfj")]
        //[TestCase("user" , "kdjfdkfj")]
        public async Task UserService_CreateUser_Returns_UserNotCreated()
        //public async Task UserService_CreateUser_Returns_UserNotCreated(, "")
        {
            _userService = new UserService(_userRepo.Object, null, null);
            // ?  below null and null in constructor according to Tim Corey ins Mock youtube DB videos, Let's Try !
            var result = await _userService.CreateUser(new ApplicationUser { }, "kjk788kkk");

            Assert.IsTrue(result.Equals(false));
        }
#pragma warning disable CS0246 // The type or namespace name 'Test' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning disable CS0246 // The type or namespace name 'TestAttribute' could not be found (are you missing a using directive or an assembly reference?)
        [Test]
#pragma warning restore CS0246 // The type or namespace name 'TestAttribute' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning restore CS0246 // The type or namespace name 'Test' could not be found (are you missing a using directive or an assembly reference?)
        public async Task UserService_CreateUser_Returns_UserNotCreated_False()
        {
            _userRepo = new Mock<IUserRepository>();
            _userService = new UserService(_userRepo.Object, null, null);
            var result = await _userService.CreateUser(null, "kjk788kkk");
            //Assert.Throws<Exception>(async () => await _userService.CreateUser(null, "akaj4i"));
            //Assert.ThrowsAsync<Exception>(async () =>await _userService.CreateUser(null, "kjk788kkk"));
            //Assert.Throws<>("");
            //User cann/ne eut etre null
            Assert.IsTrue(result.Equals(false));
        }
        //[Test]
        public void UserService_CreateUser_Returns_UserCreated()
        {
           Task<bool> result= _userService.CreateUser(new ApplicationUser { }, "");
            Assert.IsNotNull(result);
        }
        //[Test]
        public async Task UserService_CreateUser_Returns_Exception()
        {
            throw new  ArgumentNullException();
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

