using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.Model.Model
{
    public interface IPermissionService
    {
        Task<bool> Authorize(string permissionRecordSystemName, ApplicationUser user);

        Task<bool> Authorize(string permissionRecordSystemName);

        Task<bool> Authorize(string permissionRecordSystemName, ApplicationRole role);
    }

    public class PermissionService: IPermissionService
    {
        private ICacheBase _cacheBase { get; set; }
        public async Task<bool> Authorize(string permissionRecordSystemName, ApplicationUser user)
        {
            if (string.IsNullOrEmpty(permissionRecordSystemName) || user == null)
                return false;
            foreach (ApplicationRole userRole in (IEnumerable<ApplicationRole>)user.UserRoles)
            {
                if (await this.Authorize(permissionRecordSystemName, userRole))
                    return true;
            }
            return false;
        }

        public virtual async Task<bool> Authorize(
          string permissionRecordSystemName,
          ApplicationRole role)
        {
            return !string.IsNullOrEmpty(permissionRecordSystemName);
        }

        public virtual async Task<bool> Authorize(string permissionRecordSystemName)
        {
            return !string.IsNullOrEmpty(permissionRecordSystemName);
        }
    }
}

}
