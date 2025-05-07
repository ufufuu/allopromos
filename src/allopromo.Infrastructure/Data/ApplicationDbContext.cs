
using allopromo.Core.Domain;
using allopromo.Core.Entities;
using allopromo.Infrastructure.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

#nullable disable
namespace allopromo.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Department> Departments { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<StoreCategory> StoreCategories { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base((DbContextOptions)options)
        {
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (IMutableProperty mutableProperty in modelBuilder.Model.GetEntityTypes().Select<IMutableEntityType, IMutableKey>((Func<IMutableEntityType, IMutableKey>)(x => x.FindPrimaryKey())).SelectMany<IMutableKey, IMutableProperty>((Func<IMutableKey, IEnumerable<IMutableProperty>>)(x => (IEnumerable<IMutableProperty>)x.Properties)))
                mutableProperty.ValueGenerated = ValueGenerated.OnAdd;
            modelBuilder.Model.GetEntityTypes();
            modelBuilder.Entity<Department>().ToTable<Department>("Departments");
            modelBuilder.Entity<StoreCategory>().ToTable<StoreCategory>("StoreCategories");
            modelBuilder.Entity<StoreCategory>((Action<EntityTypeBuilder<StoreCategory>>)(storesCategory =>
            {
                storesCategory.HasKey((Expression<Func<StoreCategory, object>>)(c => new
                {
                    storeCategoryId = c.storeCategoryId
                }));
                storesCategory.HasMany<Store>((Expression<Func<StoreCategory, IEnumerable<Store>>>)(s => s.Stores)).WithOne((Expression<Func<Store, StoreCategory>>)(s => s.Category));
            }));
            modelBuilder.Entity<ProductCategory>((Action<EntityTypeBuilder<ProductCategory>>)(products => products.HasKey((Expression<Func<ProductCategory, object>>)(p => new
            {
                productCategoryId = p.productCategoryId
            }))));
            modelBuilder.Entity<ApplicationUser>().HasDiscriminator<int>("Type").HasValue<ApplicationUser>(1);
            modelBuilder.Entity<Store>((Action<EntityTypeBuilder<Store>>)(store => store.HasKey((Expression<Func<Store, object>>)(s => new
            {
                storeId = s.storeId
            }))));
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration<IdentityRole>((IEntityTypeConfiguration<IdentityRole>)new RoleConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
        }
    }
}

/* DefaultDevConnection
}
/*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
          if (!optionsBuilder.IsConfigured)
          {
              IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();
              var connectionString = configuration.GetConnectionString("DefaultConnection");
              optionsBuilder.UseSqlServer(connectionString); //or any other DB provider*/
/*}
}*/

//public DbSet<ApplicationUser> Users { get; set; }
//public virtual DbSet<ApplicationUserRole> UserRoles { get; set; }
// public virtual DbSet<ApplicationRole> Roles { get; set; }
//public AppDbContext()
//{
//}
//public AppDbContext(DbContextOptions options) : base(options)
//{
//}
//l'un en haut ou l'autre en Bas

//public interface IAppDbContext
//{
//}
//public class AppDbContextFactory
//{
//    private readonly AppDbContext _dbContext;

//    public AppDbContextFactory()
//    {
//        //_dbContext = new AppDbContext();
//    }
//}