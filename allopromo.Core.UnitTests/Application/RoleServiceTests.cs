#pragma warning disable CS0234 // The type or namespace name 'Domain' does not exist in the namespace 'allopromo' (are you missing an assembly reference?)
#pragma warning restore CS0234 // The type or namespace name 'Domain' does not exist in the namespace 'allopromo' (are you missing an assembly reference?)
using Moq;
#pragma warning disable CS0246 // The type or namespace name 'NUnit' could not be found (are you missing a using directive or an assembly reference?)
using NUnit.Framework;
#pragma warning restore CS0246 // The type or namespace name 'NUnit' could not be found (are you missing a using directive or an assembly reference?)
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS0234 // The type or namespace name 'Abstract' does not exist in the namespace 'allopromo.Data' (are you missing an assembly reference?)
#pragma warning restore CS0234 // The type or namespace name 'Abstract' does not exist in the namespace 'allopromo.Data' (are you missing an assembly reference?)
using Microsoft.VisualStudio.TestTools.UnitTesting;
using alloprom.Core.Interface;
using allopromo.Core.Model;
using Assert = NUnit.Framework.Assert;

namespace alloPromoTests.Services
{
    [TestClass]
    public class RoleServiceTests
    {
#pragma warning disable CS0246 // The type or namespace name 'IModelRepository' could not be found (are you missing a using directive or an assembly reference?)
        private Mock<IRoleRepository> _roleRepoMock { get; set; }
#pragma warning restore CS0246 // The type or namespace name 'IModelRepository' could not be found (are you missing a using directive or an assembly reference?)

#pragma warning disable CS0246 // The type or namespace name 'RoleService' could not be found (are you missing a using directive or an assembly reference?)
        private RoleService _roleService { get; set; }
#pragma warning restore CS0246 // The type or namespace name 'RoleService' could not be found (are you missing a using directive or an assembly reference?)
        //[Test]
        public void RoleService_GetRoles_ReturnRoles()
        {
            // ? Moq Setup vs SetupGet 
            var roless = GetQueryAbleMockDbSet(
                new Role { roleId = "1", roleName = "Marchand" },
                new Role { roleId = "2", roleName = "support" },
                new Role { roleId = "3", roleName = "Client" }
                );

            //var roles = _dbContextMock.SetupGet(l=>l.Roles)               
            //  .Returns(roless);
            //is below a lambda expression () => GetRoles() ?

            _roleRepoMock = new Mock<IRoleRepository>();
            //var expectedRoles = _roleRepoMock.Setup(m => m.GetRoles())
                //.Returns(roless.ToList());
            var _roleService = new RoleService((Microsoft.AspNetCore.Identity.RoleManager<Microsoft.AspNetCore.Identity.IdentityRole>)_roleRepoMock.Object);
            //Act
            var actualRoles = _roleService.GetRoles() as List<Role>;
            Assert.AreEqual(actualRoles.Count, 3);
        }
#pragma warning disable CS0246 // The type or namespace name 'Test' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning disable CS0246 // The type or namespace name 'TestAttribute' could not be found (are you missing a using directive or an assembly reference?)
        [Test]
#pragma warning restore CS0246 // The type or namespace name 'TestAttribute' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning restore CS0246 // The type or namespace name 'Test' could not be found (are you missing a using directive or an assembly reference?)
        public void RoleService_GetUserRole_ReturnRole()
        {
            _roleService = new RoleService();
            var user = new User
            {
                userEmail = "kevindjanta@free.fr",
                userName = "Kevin Djnata",
                userPassword = "hh@38",
                userPhoneNumber = "we",
                //userRole = 0
            };
            var role = _roleService.GetUserRole(user);
            //Assert.AreEqual(0, (int)user.userRole);
        }
#pragma warning disable CS0246 // The type or namespace name 'Test' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning disable CS0246 // The type or namespace name 'TestAttribute' could not be found (are you missing a using directive or an assembly reference?)
        [Test]
#pragma warning restore CS0246 // The type or namespace name 'TestAttribute' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning restore CS0246 // The type or namespace name 'Test' could not be found (are you missing a using directive or an assembly reference?)
        public void RoleService_ConvertUserRole_Return_NewRole()
        {
            _roleService = new RoleService();
            var user = new User
            {
                userEmail = "kevindjanta@free.fr",
                userName = "Kevin Djnata",
                userPassword = "hh@38",
                userPhoneNumber = "we",
               // userRole = 0
            };
            var role = _roleService.ConvertUserRole(user, (Roles)1);
            //Assert.AreEqual(1, (int)user.userRole);
        }
#pragma warning disable CS0246 // The type or namespace name 'Role' could not be found (are you missing a using directive or an assembly reference?)
        private List<Role> GetRoles()
#pragma warning restore CS0246 // The type or namespace name 'Role' could not be found (are you missing a using directive or an assembly reference?)
        {
            List<Role> roles = new List<Role>();
            roles.Add(new Role { roleId = "1", roleName = "Merchant" });
            roles.Add(new Role { roleId = "2", roleName = "Support" });
            roles.Add(new Role { roleId = "3", roleName = "Client" });
            return roles;
        }
        private DbSet<T> GetQueryAbleMockDbSet<T>(params T[] sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();
            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            return dbSet.Object;
        }
#pragma warning disable CS0246 // The type or namespace name 'Role' could not be found (are you missing a using directive or an assembly reference?)
        private void ConvertTo(DbSet<Role> roles)
#pragma warning restore CS0246 // The type or namespace name 'Role' could not be found (are you missing a using directive or an assembly reference?)
        {
            //return DbSet<Role>
        }
        public void RoleService_GetRolesByIdOr_ReturnRole()
        {
        }
    }
}


// Linting anf Formatting [ ctrl K + ctrl D]  : SonarLint & StyleCop !
