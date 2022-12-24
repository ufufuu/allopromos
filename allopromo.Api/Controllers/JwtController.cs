using allopromo.Model.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
namespace allopromo.Controllers
{
    public class JwtController:ControllerBase
    {
        private SignInManager<RegisterViewModel> _signingManager { get; set; }

        [HttpGet]

        //[BasicAuthenticationFilter]
        public IActionResult Get([FromBody] RegisterViewModel user)
        {
            var logged = _signingManager.SignInAsync(user, isPersistent: false);
            //string userName = Threa.CurrentPrincipal.Identiy.Name;
            //string userId = System.Web.HttpContext.Current.User.Identity.
            //userName = Membership.GetUser("aliwiyao").UserName;

            //MembershipUser mu= Membership.GetUser("username");
            //string userId= mu.ProviderUserKey.ToString();
            //string currentUserId=Convert.ToString(Membership.GetUser().ProviderUserKey);
            
            if (logged != null)
                return Ok(user);
            return NotFound();
        }
        [HttpPost]
        [Authorize]
        public Object Post()
        {
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                var name = claims.Where(p => p.Type == "name")
                    .FirstOrDefault()?.Value;
                return new
                {
                    data = name
                };
            }
            return null;
        }
    }
}
