using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using allopromo.Core.Abstract;
using allopromo.Core.Model;
using allopromo.Core.Domain;

namespace allopromo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("*")]
    public class RoleController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserService _userService;
        public RoleController(IUserService userService)
        {
            _userService = userService;
        }
        public RoleController(IAccountService accountService,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, 
            SignInManager<ApplicationUser> signInManager)
        {
            _accountService = accountService;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        [ActivatorUtilitiesConstructor]
        public RoleController(IUserService userService, UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }
        [HttpGet("{role}")]
        public IActionResult GetUsers(string role)
        {
            if(role!=null)
            {
                var users = _userService.GetUsersInRole(role);
                return Ok(users);
            }
            return NotFound();
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser(User user)
            //Task<ActionResult<User>> cU(u) , task<bool> cU(u)
        {
            //throw new AccessViolationException();
            if (user == null)
                return null;
            else
            {
                if(string.IsNullOrEmpty(user.userPassword))
                     throw new Exception("Password is invalid or Empty");
                // How to throw as an ActionResult Exception ?
                    var appUser = new ApplicationUser
                    {
                        UserName = user.userEmail,
                        Email = user.userEmail,
                        PhoneNumber = user.userPhoneNumber
                    };
                    var result = await _userService.CreateUser(appUser, user.userPassword);
                    if (result)
                        return Ok(appUser);
                return NotFound();
            }
        }
    }
}
