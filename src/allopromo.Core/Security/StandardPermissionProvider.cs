using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.Security
{
    /// <summary>
    /// Standard Permission Provider
    /// </summary>
    public class StandardPermissionProvider : IPermissionProvider
    {

        //Admin Area Permissions

        //Public Acess Permissions
        public IEnumerable<string> GetPermissions()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<string> GetDefaultPermissions()
        {
            throw new NotImplementedException();
        }
    }
}
