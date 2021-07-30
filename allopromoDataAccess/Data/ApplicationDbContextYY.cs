using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
namespace allopromoDataAccess.Model
{
    public class ApplicationDbContextVV:IdentityDbContext
    {
        public List<IdentityUser> identityUsers { get; set; }
        public List<IdentityRole> identyRoles { get; set; }
    }
}

/* Field Vs Attribute in C# ?
 * let vs Var in Js ?
 */
/*
 * Linq to SQL
 * Linq to ENtities ?
 * 
 * .NEt Logging - .nEt Caching  - Redis  - 
 */
