using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.Security.Role
{
    public class RolesAuthorizationRequirement : IAuthorizationRequirement
    {
        public string _allowedPermission { get; set; }

        public RolesAuthorizationRequirement(string allowedPermission)
        {
            this._allowedPermission = allowedPermission;
        }
    }
}
