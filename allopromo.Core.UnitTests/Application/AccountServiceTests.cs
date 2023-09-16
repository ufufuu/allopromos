using allopromo.Core.Model;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using allopromo.Core.Helpers;
using allopromo.Core.Abstract;
using allopromo.Core.Domain;

namespace allopromo.Core.UnitTests
{
    [TestFixture]
    public class AccountServiceTests
    {
        private  AccountService _accountService;
        //private Mock<IRepository> _userRepo= new Mock<IRepository>();
        public AccountServiceTests()
        {
        }
         
        [TestCase]
        public void AccountService_Raises_EventEmailSend_When_UserAuthenticates()
        {
            //var mockAccountService = new Mock<IAccountService>();
            //mockAccountService.Setup(p => p.Authenticate(It.IsAny<ApplicationUser>()));
                //.Raises(e=>e.userAuthenticated+=null,
        }
        [Test]

        //[TestCase(null, "kdjfdkfj")]
        //[TestCase("user" , "kdjfdkfj")]
        public void AccountService_CreateUser_Returns_UserNotCreated()
        {
            var mockAppSettings = new Mock<IOptions<AppSettings>>();
            //_accountService = new AccountService(_userRepo.Object, null, null);
            _accountService = new AccountService(mockAppSettings.Object);
            // ?  below null and null in constructor according to Tim Corey ins Mock youtube DB videos, Let's Try !
            //var result = await _accountService.CreatesAccount(new ApplicationUser { }, "kjk788kkk");

            //Assert.IsTrue(result.Equals(false));
        }
        [Test]
        public void AccountService_CreateUserAndAccount_Returns_UserNotCreated_False()
        {
            var mockAppSettings = new Mock<IOptions<AppSettings>>();
            //_userRepo = new Mock<IRepository>();

            //_accountService = new AccountService(_userRepo.Object, null, null);

            _accountService = new AccountService(mockAppSettings.Object);
            //var result = await _accountService.CreatesAccount(null, "kjk788kkk");

            //Assert.Throws<Exception>(async () => await _userService.CreateUser(null, "akaj4i"));
            //Assert.ThrowsAsync<Exception>(async () =>await _userService.CreateUser(null, "kjk788kkk"));
            //Assert.Throws<>("");
            //User cann/ne eut etre null

            //Assert.IsTrue(result.Equals(false));
        }
        //[Test]
        public void AccountService_CreateUserAndAccount_Returns_UserCreated()
        {
           //Task<bool> result= _accountService.CreatesAccount(new ApplicationUser { }, "");

            //Assert.IsNotNull(result);
        }
        //[Test]
        public void  AccountService_CreateUserAndAccount_Returns_Exception()
        {
            throw new  ArgumentNullException();
        }
    }
    public interface Il1
    {
    }
    public class Cl3
    {
    }
    public class Cll1 : C3, I1
    {
       public Cll1()
       {

       }
    }
    public class Cv2
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
