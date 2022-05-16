using allopromo.Core.Abstract;
using allopromo.Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using allopromo.Core.Helpers.Convertors;
using allopromo.Model.ViewModel;
using allopromo.Core.Model.ApiResponse;
using allopromo.Core.Infrastructure;
using allopromo.Core.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using allopromo.Infrastructure.Data;

namespace allopromo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public UserController(AccountService accountService,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _accountService = accountService;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        [ActivatorUtilitiesConstructor]
        public UserController(IUserService userService, UserManager<ApplicationUser> userManager, IAccountService accountService,
            RoleManager<IdentityRole> roleManager)
        {
            _userService = userService;
            _userManager = userManager;
            _roleManager = roleManager;
            _accountService = accountService;
        }
        [HttpGet("{role}")]
        public IActionResult GetUsers(string role)
        {
            if (role != null)
            {
                var roleUsers = _userService.GetUsersInRole(role);
                return Ok(roleUsers);
            }
            return NotFound();
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            var roleUsers = _userService.GetUsers();
            return Ok(roleUsers);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser(ApplicationUser user)
        {
            if (user == null)
                return null;
            else
            {
                if (string.IsNullOrEmpty(user.PasswordHash))
                    throw new Exception("Password is invalid or Empty");
                //if (ModelState.IsValid)
                //{
                var appUser = new ApplicationUser
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber
                };

                var result = await _userService.CreateUser(appUser, user.PasswordHash);
                if (result)
                {
                    _accountService.OnUserAuthenticate(user.Email);
                    return Ok(appUser);
                }
                else
                {
                    return NotFound();
                }
            }
            //throw new Exception("User is Created");
            /*
            {
                return BadRequest(); //or throw new HttException (400, "ldkd") ?
                throw new AccessViolationException();
            }
            else
            {
               throw; // for Developer
                    //_logger.LogError($"Something went wrong: {ex}");
                    //return StatusCode(500, "Internal Server Error");
            }
        }
        */
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginModel loginModel) // mot de passe : @errAbaophone43
        {
            //_accountService.Authenticate(loginModel);
            //_signInManager.PasswordSignInAsync

            if (loginModel != null)
            {
                ApplicationUser account = null;
                try
                {
                    account = _userManager?.FindByEmailAsync(loginModel.UserName).Result;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                //&& (_signInManager.UserManager.CheckPasswordAsync
                //(account, loginModel.userPassword).Result))

                if (account != null)
                {
                    var loginValid2 = _signInManager?.PasswordSignInAsync(
                        loginModel.UserName.ToString(), loginModel.PasswordHash.ToString(), true, true);

                    var loginValid = _userService.ValidateUser(loginModel.UserName, loginModel.PasswordHash);
                    if (loginValid)
                    {
                        var role = _userService.GetUserRole(account).UserRoles;
                        //if (role == null)
                        //role = "hg";
                        ApplicationUser user = new ApplicationUser
                        {
                            UserName = loginModel.UserName,
                            Email = loginModel.UserName,
                            UserRoles = role
                        };
                        var userDto = UserConvertor.ConvertUser(account);
                        return Ok(new ApiResponseModel
                        {
                            userResponse = user,
                            jwtToken = _accountService.generateJwtToken(user),
                        });
                    }
                    else
                    {
                        return NotFound(new { message = "User name or Pwd UUY incorrect" });
                    }

                    //_signInManager.SignInAsync(new ApplicationUser{UserName = loginModel.userName }, true);
                    /*
                    using(var emailNotifyService= new EmailNotificationService())
                    {
                        _accountService.userAuthenticated += emailNotifyService.SendNotification;
                        _accountService.OnUserAuthenticate(loginModel.userName);
                    }*/
                }
                else
                {
                    return Unauthorized();
                }
            }
            return Unauthorized();
        }
        [HttpDelete]
        [Route("login")]
        public IActionResult Login2(LoginModel userLogin)
        {
            var user = _userService.GetUserIfExist(userLogin.UserName);
            if (user != null)
            {
                var result = user;
                int y = 5;
                if (_userService.LoginUser((ApplicationUser)user))
                {
                    var userDto = UserConvertor.ConvertUser(user);
                    return Ok(userDto);
                }
                else
                {
                    return BadRequest();
                }
            }
            return NotFound();
        }
        private async Task<ApplicationUser> GetConnectedUser()
        {
            var user = await _userManager.FindByIdAsync(User.Identity.Name);
            return user;
        }
    }
}
//nrt .api
//.data, .models, .service, .web
//service:
//- function to suport cxrud operaton +business rules(validation implemented by data annotation 
//and get check of model binding of asp.net frmw 
//payment gateways
//google maps
// Helper Class ?
//
public interface IEntityService <T> where T : class
{
    void SaveEntity();
}
//1 . Setup 3 Environnements
//Dev - Staging - Productions 
// Odoo -> Marketplace |
//
//https://www.pragimtech.com/blog/blazor/rest-api-model-validation/
//below
/*
try
{
    if (employee == null)
    {
        return BadRequest();
    }

    // Add custom model validation error
    var emp = employeeRepository.GetEmployeeByEmail(employee.Email);

    if (emp != null)
    {
        ModelState.AddModelError("email", "Employee email already in use");
        return BadRequest(ModelState);
    }

    var createdEmployee = await employeeRepository.AddEmployee(employee);

    return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.EmployeeId },
        createdEmployee);
}
catch (Exception)
{
    return StatusCode(StatusCodes.Status500InternalServerError,
        "Error retrieving data from the database");
}
*/
//https://code-maze.com/global-error-handling-aspnetcore/
//https://34.65.74.140/net-core-web-development-part3/

//Redirecting to Another Page
/*app.Use(async (context, next) =>
    {
        await next();
        if (context.Response.StatusCode == 404)
        {
            context.Request.Path = "/Home";
            await next();
        }
    });
*/
////https://www.infoworld.com/article/3545304/how-to-handle-404-errors-in-aspnet-core-mvc.html
///
/// Waht Could Domain Classes versus Domain Classes ??
/// 
///  Should I declare all Mthods present in Interface in the class implementing them to get Access to them ?
///  What about their properties ?
///  
///public interface IAuthorizationhandler<T>{
///}
/////
/* Collection store different Data type thus unbosxing and casting to retrieve them --> performance issue
 *Generic Collectiona are type safe , storing SAME Data type ->*/
//Generic Collections(type Safety ): List - Queue - Stack - SortedList<K, V> - Dictionnary<K, V> HashSet - 
// Generic Collection Enforce Type Safety !
//Why Use the Non Generic Collections then ?
// : ArrayList - Queue - Stack - Hashtable  
//Concurrent Collection ?

///Casting : as : on reference-types - with C#2.0 data-types are nullable
/// 2 types for casting: impliicit inferior data type to Superior, eg int to float  and Explication (
/// //Model Validation -> Data Annotations in MVC
/// //? What Are Common Exceptions ?
/// 
// 1 - call of the ConvertUser() into account login and return ! thus Getting role of loogged user
//2 - refactor token Creatigin into Account AService then only refer Service to Controller thus BL
//3 persist Token keys into asp.net Tokens which is ?
//3 - if possible migrate converot() into UserService ! same as RoleCOnvertor into RolService

// Pub /Sub design Pattern  aka IObservable::: I PUBLIS , I DON't CARE, I DEFINE THE DELEGATE !
// //Utoubeur des Accents Africains !!!
//WHen Returning Task<T> and fetching its Result, make that method async 
//! koz Task<T> blocks the thread !

////Utoubeur des Accents Africains !!!