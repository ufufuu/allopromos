
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
    public class AdminController : ControllerBase
    {
        private UserManager<IdentityUser> _userManager { get; set; }
        private IHttpContextAccessor _httpContextAccessor { get; set; }
        public AdminController(UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        [Authorize]
        public string GetName([FromQuery] string name)
        {
            var userName = HttpContext.User.Identity.Name;
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                var nameu = claims.Where(p => p.Type == "name")
                    .FirstOrDefault()?.Value;
            }
            var contextUser = _httpContextAccessor.HttpContext?.User;
            var userCourant = HttpContext.Session.IsAvailable;
            var user = HttpContext.User;
            var g = HttpContext;
            System.Security.Claims.ClaimsPrincipal currentUtils = this.User;
            ClaimsPrincipal currentUser = this.User;

            bool isAdmin = currentUser.IsInRole("Admin");
            var id = _userManager.GetUserId(User);
            var helloUser = _userManager.GetUserAsync(HttpContext.User).Result;
            ClaimsPrincipal currUser = this.User;

            var t = User.HasClaim("someClaim", "someValue");
            var nameIdentifier = User
                .Claims
                .FirstOrDefault(c => c.Type == System.Security.Claims
                .ClaimTypes
                .NameIdentifier)?.Value;
            var curUser = nameIdentifier.ToString();
            return User.Identity.Name.ToString();
        }
        
    }
}
