using System;
using System.Collections.Generic;
using System.Text;

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