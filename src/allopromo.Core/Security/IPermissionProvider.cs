using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.Security
{
    /// <summary>
    /// IPermissionProvider
    /// </summary>
    public interface IPermissionProvider
    {
        /// <summary>
        /// GetPermissions()
        /// </summary>
        public IEnumerable<string> GetPermissions();
        /// <summary>
        /// Get Default Permission()
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetDefaultPermissions();
    }
}
