using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
//using static Google.Apis.Auth.OAuth2.ComputeCredential;
namespace allopromo.Infrastructure.Filters
{
    public class IdentityAuthenticationFilter : BasicAuthenticationFilter
    {
        protected override async Task<IPrincipal> AuthenticateAsync(string userName, string password, CancellationToken cancellationToken)
        {
            UserManager<IdentityUser> userManager = CreateUserManager();
            cancellationToken.ThrowIfCancellationRequested();
            IdentityUser user = await userManager.FindByEmailAsync(userName);
            if (user == null)
            {
                return null;
                ClaimsIdentity identity = await userManager.ClaimsIdentityFactory.CreateAsync(userManager, user, "Basic");
                return new ClaimsPrincipal(identity);
            }
            private static UserManager<IdentityUser> CreateUserManager()
            {
                return new UserManager<IdentityUser>(new UserStore<IdentityUser>(new UsersDbContext()));
                //return new UserManager<IdentityUser>(null);
            }
        }
    }
    public class UsersDbContext : IdentityDbContext<IdentityUser>
    {
        static UsersDbContext()
        {
            Database.SetInitializer(new Initializer());
        }
        private class SetInitializer: CreateDatabaseIfNotExists<UsersDbContext>
        {
            protected override void Seed(UsersDbContext context)
            {
            }
        }
    }
}