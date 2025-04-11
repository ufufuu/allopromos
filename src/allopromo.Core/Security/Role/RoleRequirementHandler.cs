using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.Security.Role
{
    public class RoleRequirementHandler : AuthorizationHandler<RoleRequirement>, allopromo.Core.Security.IAuthorizationHandler
    {
        protected override Task HandleRequirementAsync(
          AuthorizationHandlerContext context,
          RoleRequirement roleRequirement)
        {
            if (context.User.IsInRole(roleRequirement.Role))
                context.Succeed((IAuthorizationRequirement)roleRequirement);
            return Task.CompletedTask;
        }
    }
}
