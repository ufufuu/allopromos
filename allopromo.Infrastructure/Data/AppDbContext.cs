using allopromo.Core.Domain;
using allopromo.Core.Entities;
using allopromo.Core.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
namespace allopromo.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>

    /*ApplicationRole, string, IdentityUserClaim<string> ,
    ApplicationUserRole, IdentityUserLogin<string>,
    IdentityRoleClaim<string>,IdentityUserToken<string>>//, IAppDbCoWntext*/

    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<tStore> Stores { get; set; }
        public DbSet<tStoreCategory> StoreCategories { get; set; }
        public DbSet<tCity> Cities { get; set; }
        public DbSet<tCountry> Countries { get; set; }
        public DbSet<tRegion> Regions { get; set; }
        public DbSet<tProduct> Products { get; set; }
        public DbSet<tProductCategory> ProductCategories { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public AppDbContext()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<ApplicationUser>()
            //    //.HasDiscriminator<int>("Type")
            //    .HasValue<ApplicationUser>(1);

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
            //modelBuilder.Entity<IdentityUserRole<Guid>>().HasKey(p =>
            //new { p.UserId, p.RoleId });
            //modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            /*
            modelBuilder.Entity<tStore>().HasNoKey();
            modelBuilder.Entity<tStore>().ToTable("Store");

            modelBuilder.Entity<tStore>(store =>
            {
                store.HasKey(s => new { s.storeId });
            });
            base.OnModelCreating(modelBuilder);*/
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultDevConnection");
                optionsBuilder.UseSqlServer(connectionString);
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