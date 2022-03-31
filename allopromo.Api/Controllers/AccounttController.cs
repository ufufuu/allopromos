using allopromo.Data.Model;
using allopromo.Domain.Abstract;
using allopromo.Domain.Model;
using allopromo.Domain.Model.ApiResponse;
using allopromo.ViewModel;
using allopromo.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegisterModel = allopromo.ViewModel.RegisterModel;
namespace allopromo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccounttController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccounttController(IAccountService accountService, 
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _accountService = accountService;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginModel loginModel)
        {
            return null;  
        }
        [HttpPost]
        [Route("create")]
        public void Post([FromBody] RegisterModel registerModel)
        {
            //var createdAccount = _accountManager.CreateAccount(accountModel.userName);
            if (registerModel == null)
            {

            }
        }
        [HttpGet]
        [AllowAnonymous]
        public void Get([FromBody] LoginModel login)
        {

        }
        [HttpPut]
        public void Put(string userName, string token)
        {
            //var token = JwtManager.ValidateToken(token);
            if (userName.Equals(token))
            {

            }
        }
        [HttpDelete]
        public void Delete(string userName, string Pwd)
        {

        }
    }
}
