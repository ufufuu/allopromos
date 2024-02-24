using allopromo.Core.Abstract;
using allopromo.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Core.Model
{
    public enum ApplicationRoles
    {
        Admin = 1,
        User = 2
    }
    public class RoleService //: IRoleService
    {
        public IRepository<ApplicationRole> _roleRepository { get; set; }
        public RoleService(IRepository<ApplicationRole> roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public RoleService()
        {}

        //public async Task<IQueryable<ApplicationRole>> GetRoles()
    }
    public interface IRoleService
    {
        Task<IQueryable<ApplicationRole>> GetRoles();
    }
}
