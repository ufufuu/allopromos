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
        private readonly SignInManager<RegisterModel> _signingManager;
        [HttpGet]
        //[BasicAuthenticationFilter]
        public IActionResult Get([FromBody] RegisterModel user)//HttpResponseMessage 
        {
            var logged = _signingManager.SignInAsync(user, isPersistent: false);

            //124548787ikjk
            //string userName = Threa.CurrentPrincipal.Identiy.Name;
            //if(AccountRepository.UserIsValid()
            //string userId = System.Web.HttpContext.Current.User.Identity.
            //GetUserId();
            //userName = Membership.GetUser("aliwiyao").UserName;

            //MembershipUser mu= Membership.GetUser("username");
            //string userId= mu.ProviderUserKey.ToString();
            //string currentUserId=Convert.ToString(Membership.GetUser().ProviderUserKey);
            /*
            using (var db = new allo.Model.MonEpicierDbEntitities())
            {
                userName=Convert.ToString(db.aspnet_Users.Where(
                    e=>e.UserName.Equals(userName)))
            int y = 4;
            var q=(from x in db.aspnet_Users
                    where x.UserName.Equals(userName)
                    select new CreateAccountModel{
                        userName = x.UserName,
                        Password= x.aspnet_Membership.Password,
            }).FirstOrDefault();

            */
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
