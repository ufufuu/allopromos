using System.Collections.Generic;
using System.Linq;
using allopromo.Core.Domain;
using allopromo.Core.Helpers.Convertors;
using Microsoft.AspNetCore.Identity;
namespace allopromo.Core.Model
{
    public class RoleService ///: IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleService()
        {
            //_rolesRepo = new RoleRepository(_dbContext = new AppDbContext());
        }
        public RoleService(RoleManager<IdentityRole> roleManager)
        {
            //_rolesRepo = new RoleRepository(_dbContext);
            _roleManager = roleManager;
        }
        //public Roles ConvertUserRole(User user, Roles role)
        public string ConvertUserRole(User user, Roles role)
        {
            user.UserRole = role.ToString();
            return user.UserRole;
        }
        public List<Role> GetRoles() => RoleConvertor.ConvertRoles((List<ApplicationRole>)_roleManager.Roles);
        public string GetUserRole(User user)
        {
            return user.UserRole;
        }
        public List<Role> GetRolesByNameOrEmaail(string userName)
        {
            //return _roleMa
            return null;
               //.Where(r => r.roleName == name).AsEnumerable().ToList();
        }
    }
}
