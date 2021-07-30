using allopromo.Model.DTO;
using allopromoDataAccess.Abstract;
using allopromoDataAccess.Model;
using allopromoServiceLayer.Abstract;
using allopromoServiceLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        //[Route("api/[controller]/create/{userName}/{userPassword}")]
        [AllowAnonymous]
        public async Task<bool> CreateUser(User user)
        {
            if (user.userPassword.Length == 0)
            {
                throw new Exception();
            }
            if (ModelState.IsValid)
            {
                var appUser = new ApplicationUser 
                { 
                    //appUserFirstName = user.userEmail,
                    UserName=user.userEmail,
                    Email=user.userEmail,
                    PhoneNumber=user.userPhoneNumber
                };
                //try
                //{
                    var result = await _userService.CreateUser(appUser, user.userPassword);
                    if (result)
                    {
                        return true;
                    }
                //}
                //catch
                //{
                  //  throw;
                //}
            }
            return false;
        }
        [HttpPut]
        [Route("api/[controller]/login")]
        //public IActionResult Login(string UserName, string Password)
        public IActionResult Login(User user)
        {
            if (user != null)
            {

            }
            return NotFound(user);
        }
        [HttpGet]
        public Task<IList<ApplicationUser>> GetUsersByRole(string role)
        {
            return _userService.GetUsersByRole(role);
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