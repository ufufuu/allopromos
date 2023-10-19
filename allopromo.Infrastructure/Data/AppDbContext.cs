using allopromo.Core.Domain;
using allopromo.Core.Entities;
using allopromo.Core.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

namespace allopromo.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser> //, IAppDbContext VS <ApplicationUser>?

    /*ApplicationRole, string, IdentityUserClaim<string> ,
    ApplicationUserRole, IdentityUserLogin<string>,
    IdentityRoleClaim<string>,IdentityUserToken<string>>//, IAppDbCoWntext*/
    {
        /*
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> Roles { get; set; }
        public DbSet<ApplicationUserRole> UserRoles { get; set; }*/

        public DbSet<tDepartment> Departments { get; set; }

        public DbSet<tRegion> Regions { get; set; }
        public DbSet<tCountry> Countries { get; set; }
        public DbSet<tCity> Cities { get; set; }
        public DbSet<tStoreCategory> StoreCategories { get; set; }
        public DbSet<tStore> Stores { get; set; }
        public DbSet<tProductCategory> ProductCategories { get; set; }
        public DbSet<tProduct> Products { get; set; }
        public DbSet<tOrder> Orders { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public AppDbContext()
        { }
        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var keysProperties = modelBuilder.Model.GetEntityTypes()
                .Select(x => x.FindPrimaryKey()).SelectMany(x => x.Properties);
            foreach (var property in keysProperties)
            {
                property.ValueGenerated = ValueGenerated.OnAdd;
            }
            var entities = modelBuilder.Model.GetEntityTypes();

            System.Type[] identityObs = { 
                typeof(allopromo.Core.Entities.Identity.AspNetUser),
                
            };
            foreach(var entity in entities)
            {
                System.Type typeEntity = entities.GetType();
                bool exist = System.Array.Exists(identityObs, x => x == entity);
                if (exist)

                // typeof(allopromo.Infrastructure.Modeles.AspNetUser))

                {
                    entity.AddProperty("createdDate", typeof(System.DateTime));
                    entity.AddProperty("updatedDate", typeof(System.DateTime));
                }
            }
            #region Mapping To Tables
            modelBuilder.Entity<tDepartment>()
                .ToTable("Departments");
            modelBuilder.Entity<tStoreCategory>()
                .ToTable("StoreCategories");
            #endregion

            //modelBuilder.Entity<ApplicationUser>(entity =>
            //{
            //    //entity
            //    //    .HasMany(x => x.UserRoles)
            //    //    .WithMany(ur => ur.UserId)
            //    //    .HasForeignKey(x => x.UserId);
            //})

            modelBuilder.Entity<tStoreCategory>(storesCategory=>
            {
                storesCategory.HasKey(c => new { c.storeCategoryId });
                storesCategory.HasMany(s => s.Stores)
                .WithOne(s => s.Category);
            });
            //modelBuilder.Entity<tDepartment>(department =>
            //{
            //    department.HasKey(c => new { c.departmentId });
            //    department.HasMany(c => c.Categories)
            //    .WithOne(s => s.Department);
            //});
            modelBuilder.Entity<tProductCategory>(products =>
            {
                products.HasKey(p => new { p.productCategoryId });
                //products.HasMany(p => p.categoryProducts)
                //.WithOne(p => p.ProductCategory);

            });
            modelBuilder.Entity<IdentityUser>()
                .HasDiscriminator<int>("Type")
                .HasValue<IdentityUser>(1);
            modelBuilder.Entity<ApplicationUser>()
                .HasDiscriminator<int>("Type")
                .HasValue<ApplicationUser>(2);
            //modelBuilder.Entity<ApplicationUserRole>(userRole =>
            //{
            //    userRole.HasKey(ur => new { ur.UserId, ur.RoleId });
            //    userRole.HasOne(ur => ur.Role)
            //        .WithMany(r => r.UserRoles)
            //        .HasForeignKey(ur => ur.RoleId)
            //        .IsRequired();
            //    userRole.HasOne(ur => ur.User)
            //        .WithMany(r => r.UserRoles)
            //        .HasForeignKey(ur => ur.UserId)
            //        .IsRequired();
            //});
            //modelBuilder.Entity<ApplicationUserRole>(entity =>
            //{
            //    entity
            //        .HasOne(x => x.Role)
            //        .WithMany(x => x.UserRoles)
            //        .HasForeignKey(x => x.RoleId);
            //    entity
            //        .HasOne(x => x.User)
            //        .WithMany(x => x.UserRoles)
            //        .HasForeignKey(x => x.UserId);
            //});
            //modelBuilder.Entity<IdentityUserRole<Guid>>().HasKey(p =>
            //new { p.UserId, p.RoleId });
            //modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey(); */

            //modelBuilder.Entity<tStore>().HasNoKey();
            //modelBuilder.Entity<tStore>().ToTable("Store");

            modelBuilder.Entity<tStore>(store =>
            {
                store.HasKey(s => new { s.storeId });
            });
            base.OnModelCreating(modelBuilder);
        }
        #endregion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultDevConnection");
                optionsBuilder.UseLazyLoadingProxies()
                              .UseSqlServer(connectionString);
            }
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
                 .AddJsonFile("appsettings.Development.json")
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