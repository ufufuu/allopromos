using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using allopromo.SuperAdmin.Model;

namespace allopromo.SuperAdmin.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<allopromo.SuperAdmin.Model.StoreCategory> StoreCategory { get; set; }
    }
}
