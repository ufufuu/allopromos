using allopromo.Core.Abstract;
using allopromo.Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
//using allopromo.Core.Model.ApiResponse;

using allopromo.Core.Infrastructure;
using allopromo.Core.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using allopromo.Infrastructure.Data;
using Microsoft.Extensions.Logging;
using allopromo.Api.ViewModel.ViewModels;
using System.Security.Claims;
using System.Linq;
using allopromo.Api.DTOs;

namespace allopromo.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [Produces("application/json")]

    [ApiController]
    public class UserController : ControllerBase
    {
        #region Properties
        private readonly IUserService _userService;
        
        private readonly AutoMapper.IMapper _mapper;
        private UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IPermissionService _permissionService;

        private Serilog.ILogger logger { get; set; }
        #endregion

        #region Constructors
        public UserController(IUserService userService, 
            UserManager<IdentityUser> userManager, AutoMapper.IMapper mapper)
        {
            _userService = userService;
            _userManager = userManager;
            _mapper = mapper;
        }
        [ActivatorUtilitiesConstructor]
        public UserController(IUserService userService, UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager, ILogger<UserController> logger,
            AutoMapper.IMapper Mapper)
        {
            _userService = userService;
            _userManager = userManager;
            _roleManager = roleManager;
            
            _signInManager = signInManager;
            _mapper = Mapper;
        }
        #endregion

        #region User Api
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsersAsync();// UI layer Should Know Nothing About Domai Object !
            var Users = 
                _mapper.Map<System.Collections.Generic.List<UserDto>>
                (_userManager.Users);
            return Ok(Users);
        }
        private async Task<ApplicationUser> GetConnectedUser()
        {
            ApplicationUser user = null;
            //var user = await _userManager.FindByIdAsync(User.Identity.Name);
            //return user;
            return await Task.FromResult(user);
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(RegisterViewModel registerViewModel)
        {
            if ((registerViewModel == null) || 
                (string.IsNullOrEmpty(registerViewModel.UserEmail) ||
                    string.IsNullOrEmpty(registerViewModel.UserPassword)))
            {
                return BadRequest(ModelState);

                /*
                System.Net.Http.HttpResponseMessage httpResponseMessage = 
                    new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                throw new Exception();
                */
            }
            else
            {
                if (ModelState.IsValid)
                {
                    IdentityUser appUser = null;
                        appUser = _mapper.Map<IdentityUser>(registerViewModel);
                    var result = await _userManager.CreateAsync(appUser, registerViewModel.UserPassword);
                    await _userManager.AddToRoleAsync(appUser, registerViewModel.UserRole);

                    int g = 7;
                    if (result.Succeeded)
                    {
                        var currentUser =
                            await _userManager.FindByNameAsync(registerViewModel.UserName);
                        var roleResult =
                            await _userManager.AddToRoleAsync(currentUser, "Merchants");
                        return Ok(registerViewModel);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                return BadRequest();
            }
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public async Task<IActionResult> Login( LoginViewModel loginViewModel)
        {
            if (loginViewModel != null)
            {
                try
                {
                    var user = await _userManager.FindByEmailAsync(loginViewModel.UserName);

                    if (user!= null)
                    {
                        //var loginValid21 = _userService.ValidateUser(loginViewModel.UserName, loginViewModel.UserPassword);

                        Task <bool> loginValid = _signInManager.UserManager.CheckPasswordAsync(user,
                        loginViewModel.UserPassword);

                        if (loginValid.Result)
                        {
                            IdentityUser user32 = new IdentityUser
                            {
                                UserName = loginViewModel.UserName,
                                Email = loginViewModel.UserName,
                            };
                            await _signInManager.SignInAsync(new ApplicationUser { UserName = loginViewModel.UserName }, true);
                            return Ok(new Model.ApiResponse
                            {
                                userResponse = user,
                                jwtToken = _userService.GenerateJwtToken(user),
                                userRole = "administrator",
                            });
                        }
                        else
                        //{
                            return NotFound (new { status = " Failed ", message = " User name or Pwd UUY incorrect " });
                        //}
                        
                        /*
                        using(var emailNotifyService= new EmailNotificationService())
                        {
                            _accountService.userAuthenticated += emailNotifyService.SendNotification;
                            _accountService.OnUserAuthenticate(loginModel.userName);
                        }*/
                    }
                    else
                    //{
                        return Unauthorized();
                    //}
                }
                catch (Exception ex)
                {
                    //_logger.LogInformation("User Not Found");

                    throw ex;
                }
            }
            else
                throw new Exception();
        }
        #endregion

        #region Account Api
        [HttpDelete]
        [HttpGet]
        [Route("/account")]
        public object GetAccount()
        {
            return null;
        }

        #endregion

        #region Role Api
        [HttpGet("{roleName}")]
        public async Task<IActionResult> GetUsersByRole(string roleName)
        {
            if (roleName != null)
            {
                var roleUsers = await _userService.GetUsersByRole(roleName);
                return Ok(roleUsers);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("roles")]
        public async Task<IActionResult> GetRoles()
        {
            return null;
        }
        #endregion
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


//If I am Admin Role, Who Admin , then show the rOther and let's Start Chatting ! 


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
*/