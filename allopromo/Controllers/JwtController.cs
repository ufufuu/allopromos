using allopromoDataAccess.Model;
using allopromoDataAccess.Model.ViewModel;
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
        private readonly SignInManager<ApplicationUser> _signingManager;
        public JwtController()
        {

        }
        public void Get([FromBody] CreateAccountModel userName)//HttpResponseMessage 
        {
            //var logged = _signingManager.SignInAsync(userName, isPersistent: false);
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
                userName=Convert.ToString(db.aspnet_Users.Where())
            }
            */
            //if(_signingManager.SignInAsync(userName, isPersistent:false).Result))
            //return  ok()
            //return NotFound();
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
