using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
namespace allopromoDataAccess.Data
{
    /* Field Vs Attribute in C# ?
 * let vs Var in Js ?
 */
    /*
     * Linq to SQL
     * Linq to ENtities ?
     * 
     * 
     * .NEt Logging - .nEt Caching  - Redis  - 
     */
    public class AppDbContext: DbContext
    {
        //public List<IdentityUser> identityUsers { get; set; }
        //public List<IdentityRole> identyRoles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    //public virtual DbSet<Store> Stores { get; set; }
    }
}


