using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.Security
{
    public class RoleRequirement : IAuthorizationRequirement
    {
        public string Role { get; set; }

        public RoleRequirement(string role) => this.Role = role;
    }
}
