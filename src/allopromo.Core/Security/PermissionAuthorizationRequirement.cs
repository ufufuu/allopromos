using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.Security
{
    public class PermissionAuthorizationRequirement : IAuthorizationRequirement
    {
        public string _allowedPermission { get; set; }

        public PermissionAuthorizationRequirement(string allowedPermission)
        {
            this._allowedPermission = allowedPermission;
        }
    }
}
