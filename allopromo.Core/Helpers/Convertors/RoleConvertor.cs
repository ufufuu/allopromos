using allopromo.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using allopromo.Core.Domain;

namespace allopromo.Core.Helpers.Convertors
{
    // when Do We need static Classes ? along with their Methods ?
    
    public static class RoleConvertor
    {
        public static Role ConvertRole(ApplicationRole role)
        {
            var roleObj = new Role();
            roleObj = (object)role as Role;
            return roleObj; ;
        }
        public static List<Role> ConvertRoles(List<ApplicationRole> roles)
        {
            var listObj = new List<Role>();
            listObj = (object)roles as List<Role>;
            return listObj;
        }
    }
}
