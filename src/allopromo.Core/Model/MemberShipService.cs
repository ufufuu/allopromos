using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.Model
{
    public class MembershipService : IMembershipService
    {
        private readonly AppSettings _appSettings;
        private HttpContextAccessor _httpContextAccessor;

        public event MembershipService.UserAuthenticatedEventHandler userAuthenticated;

        private static UserManager<ApplicationUser> _userManager { get; set; }

        public MembershipService()
        {
        }

        public MembershipService(IOptions<AppSettings> appSettings)
        {
            this._appSettings = appSettings.Value;
        }

        public void OnUserAuthenticate(string userName) => this.OnUserAuthenticated();

        protected virtual void OnUserAuthenticated()
        {
            if (this.userAuthenticated == null)
                return;
            this.userAuthenticated((object)this, EventArgs.Empty);
        }

        public async Task CreatesAccount(ApplicationUser user, string userpwd)
        {
            await new Task((Action)null);
        }

        public void Dispose() => throw new NotImplementedException();

        public void Auth(string user) => throw new NotImplementedException();

        void IMembershipService.OnUserAuthenticated() => throw new NotImplementedException();

        public string GetCurrentName()
        {
            ClaimsPrincipal user = this._httpContextAccessor.HttpContext?.User;
            string str = user.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
            user.IsInRole("Admin");
            ApplicationUser result = MembershipService._userManager.FindByNameAsync(user.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value).Result;
            return user.Identity.Name.ToString();
        }

        public delegate void UserAuthenticatedEventHandler(object source, EventArgs e);
    }
}

