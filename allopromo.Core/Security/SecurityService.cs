using allopromo.Core.Abstract;
using allopromo.Core.Caching;
using allopromo.Core.Domain;
//using allopromo.Core.Abstract.Interfaces;
using allopromo.Core.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Core.Model
{

    public interface ISecurityService
    {
    }
    public class SecurityService:ISecurityService
    {
        #region Fields
        private ICacheBase _cacheBase { get; set; }
        #endregion

        #region Ctor

        #endregion

        #region Methods
        public async Task<bool> Authorise(string permissionRecordSystemName, ApplicationUser user)
        {
            if (string.IsNullOrEmpty(permissionRecordSystemName))
                return false;
            if (user ==null)
                return false;

            var roles = user.UserRoles; //.Where(role); // =role.Active)
            foreach(var userRole in roles)
            {
                if (await Authorize(permissionRecordSystemName, userRole))
                    return true;
            }
            return false;
        }
        public async Task<bool> Authorize(string permissionRecordSystemName, ApplicationRole role)
        {
            if (string.IsNullOrEmpty(permissionRecordSystemName))
                return false;
            return true;
        }
        #endregion
        //private async Task<bool> Authorise()
        //{
        //    return true;
        //}
    }
}

