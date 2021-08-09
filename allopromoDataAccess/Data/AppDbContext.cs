using allopromoDataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
namespace allopromoDataAccess.Data
{
    public class AppDbContext : DbContext
    {
        //public List<IdentityUser> identityUsers { get; set; }
        //public List<IdentityRole> identyRoles { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        //public virtual DbSet<Store> Stores { get; set; }
    }
}
