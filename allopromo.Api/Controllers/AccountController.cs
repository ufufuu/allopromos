
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
namespace allopromo.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<IdentityUser> _userManager { get; set; }
        private IHttpContextAccessor _httpContextAccessor { get; set; }
        public AccountController(UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
            //, IAccountService accountService)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]

        //[Authorize]//(AuthenticationSchemes = 
          //Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)] //, Policy = "TENANT")]
        //[HttpGet("issue-type-selection"), Produces("application/json")]
        public string GetName([FromQuery] string name)
        {
            var userName = HttpContext.User.Identity.Name;

            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                var nameu = claims.Where(p => p.Type == "name")
                    .FirstOrDefault()?.Value;
                //return new
                //{
                //    data = nameu
                //};
            }

            var contextUser = _httpContextAccessor.HttpContext?.User; 
            //var curentUser = userManager.GetUserAsync(HttpContext.User);

            var userCourant = HttpContext.Session.IsAvailable;
            var user = HttpContext.User;
            var g = HttpContext;

            System.Security.Claims.ClaimsPrincipal currentUtils = this.User;
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            //var claimss = currentUser.Claims.FirstOrDefault();
            //ApplicationUser user = await _userManager.FindByNameAsync(currentUserName);

            bool isAdmin = currentUser.IsInRole("Admin");
            var id = _userManager.GetUserId(User);

            var helloUser = _userManager.GetUserAsync(HttpContext.User).Result;

            ClaimsPrincipal currUser = this.User;

            var h = 56;
            var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            IdentityUser utlisateur = _userManager.FindByNameAsync(currentUserName).Result;
            
            
            var t = User.HasClaim("someClaim", "someValue");

            /*var nameIdentifier = User
                .Claims
                .FirstOrDefault(c => c.Type == System.Security.Claims
                .ClaimTypes
                .NameIdentifier)?.Value;*/
            //var curUser = nameIdentifier.ToString();

            return User.Identity.Name.ToString();
        }

        //public void Post([FromBody] RegisterModel registerModel)
        //{
        //}
        //[AllowAnonymous]
        //public void Get([FromBody] LoginModel login)
        //{
        //}
        //[HttpPut]
        //public void Put(string userName, string token)
        //{
        //    //var token = JwtManager.ValidateToken(token);
        //    if (userName.Equals(token))
        //    {
        //    }
        //}
       // public void Post([FromBody] RegisterModel registerModel)
    //    {
    //        //var createdAccount = _accountManager.CreateAccount(accountModel.userName);
    //    }
    //    [AllowAnonymous]
    //    public void Get([FromBody] LoginModel login)
    //    {

        //    }
        //    [HttpPut]
        //    public void Put(string userName, string token)
        //    {
        //        //var token = JwtManager.ValidateToken(token);
        //        if (userName.Equals(token))
        //        {

        //        }
        //    }
    }
}
