
using allopromo.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
namespace allopromo.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AdminController : Controller   //Base
    {
        private UserManager<ApplicationUser> _userManager { get; set; }
        RoleManager<IdentityRole> _roleManager { get; set; }
        private IHttpContextAccessor _httpContextAccessor { get; set; }
        public Infrastructure.Data.ApplicationDbContext _dbContext { get; set; }

        public Microsoft.AspNetCore.SignalR.
            IHubContext<Api.Infrastructure.Hubs.ChatHub> _notificationHub { get; set; }
        public Microsoft.AspNetCore.SignalR.
            IHubContext<Api.Infrastructure.Hubs.MessageHub,Api.Infrastructure.Hubs.IMessageHubClient>
                _messageHub { get; set; }
        public AdminController(UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            IHttpContextAccessor httpContextAccessor,
            Microsoft.AspNetCore.SignalR.
            IHubContext<Api.Infrastructure.Hubs.ChatHub> notificationHub
            )
        {
            _notificationHub = notificationHub;
            _userManager = userManager;
            _roleManager = roleManager;
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
        [HttpGet]
        [Route("roles")]
        public async Task<IActionResult> GetRoles()
        {
            //var roles = AutoMapper.
            return Ok( await _roleManager.Roles.ToListAsync());
        }
        //[HttpPost]
        //public async Task<>
        //[HttpPost]
        //public async Task<IActionResult> Index()
        //{
        //    // await _messageHub.Clients.All.SendOffersToUser(sendToUser", model.Id, model.Content);
        //    // await _notificationHub.Clients.All.SendCoreAsync("");

        //    return null;
        //}


        //[HttpGet]
        //public async Task<IActionResult> Login()
        //{
        //    return View();
        //}
    }
}
