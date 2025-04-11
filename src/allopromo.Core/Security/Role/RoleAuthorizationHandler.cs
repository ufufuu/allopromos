using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Core.Security.Role
{
    public class RoleAuthorizationHandler : AuthorizationHandler<RolesAuthorizationRequirement>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        protected override Task HandleRequirementAsync(
          AuthorizationHandlerContext context,
          RolesAuthorizationRequirement requirement)
        {
            throw new NotImplementedException();
        }
    }
}