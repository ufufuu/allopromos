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
        private readonly IMembershipService _accountService;

        //private readonly UserManager<ApplicationUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IUserService _userService;

        //public RoleController(IUserService userService)
        //{
        //    _userService = userService;
        //}

        public RoleController(IMembershipService accountService,
             RoleManager<IdentityRole> roleManager 
            //SignInManager<ApplicationUser> signInManager
            )
        {
            _roleManager = roleManager;

            //_userManager = userManager;
            _accountService = accountService;
            
            //_signInManager = signInManager;
        }

        [ActivatorUtilitiesConstructor]

        //public RoleController(IUserService userService,UserManager<ApplicationUser> userManager)
        //{
        //    _userService = userService;
        //    //_userManager = userManager;
        //}

        [HttpPost]
        [Route("{roleName}")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            //if (roleName != null)
            //{
                var role = new IdentityRole(roleName);
                var Role = await _roleManager.CreateAsync(role);
                return Ok(Role);
            //}
            //else 
              //  return NoContent();
        }
        [HttpGet("{role}")]
        public IActionResult GetUsers(string roleName)
        {
            if(roleName!=null)
            {
                var users = _userService.GetUsersInRole(roleName);
                return Ok(users);
            }
            return NotFound();
        }
        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IActionResult> CreateUser(Core.Application.Dto.UserDto user)

        //{
        //    if (user == null)
        //        return null;
        //    else
        //    {
        //        if(string.IsNullOrEmpty(user.userName))
        //             throw new Exception("Password is invalid or Empty");
        //        // How to throw as an ActionResult Exception ?
        //            var appUser = new ApplicationUser
        //            {
        //                UserName = user.userName,
        //                Email = user.userName,
        //                PhoneNumber = user.userName
        //            };
        //            var result = await _userService.CreateUser(appUser.UserName, user.userPassword);
        //            if (result)
        //                return Ok(appUser);
        //        return NotFound();
        //    }
        //}
    }
}
