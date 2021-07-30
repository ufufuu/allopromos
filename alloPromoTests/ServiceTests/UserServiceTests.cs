using allopromoDataAccess.Abstract;
using allopromoDataAccess.Model;
using allopromoServiceLayer.Model;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace alloPromoTests.ServiceTests
{
    [TestFixture]
    public class UserServiceTests
    {
        private  UserService _userService;
        private Mock<IUserRepository> _userRepo= new Mock<IUserRepository>();
        private Mock<UserManager<ApplicationUser>> _userManager= new Mock<UserManager<ApplicationUser>>();
        private Mock<IUserStore<ApplicationUser>> _userStoreMock = new Mock<IUserStore<ApplicationUser>>();

        //public static Mock<UserManager<TUser>> MockUserManager<TUser>(List<TUser> ls) where TUser : class
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
        public void CreateUser_Returns_True()
        //public void UserService_CreateUser_InvalidUserName, ValidUsername, 
        {
           Task<bool> result= _userService.CreateUser(new ApplicationUser { }, "");
            Assert.IsNotNull(result);
        }
        [SetUp]
        public void Setup()
        {
            _userRepo = new Mock<IUserRepository>();
            _userRepo.Setup(x => x.CreateUser(new ApplicationUser(), "")); //.Returns(() => new ApplicationUser { }));
            _userManager = MockUserManager();
            //_userManager.Setup(x =>x.
            _userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            _userService = new UserService(_userRepo.Object, _userManager.Object);
        }
        [TearDown]
        public void TearDown()
        {
            _userService = null;
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
