using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
#nullable disable
namespace allopromo.Api.Modeles
{
//    public partial class promosF7Context : DbContext
//    {
//        public promosF7Context()
//        {
//        }
//        public promosF7Context(DbContextOptions<promosF7Context> options)
//            : base(options)
//        {
//        }
//        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
//        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
//        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
//        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
//        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
//        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
//        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning        //To protect potentially sensitive information in your
//                //connection string, you should move it out of source code.
//                //You can avoid scaffolding the connection string by using the Name=
//                //syntax to read it from configuration - see 
//                //https://go.microsoft.com/fwlink/?linkid=2131148. 
//                //For more guidance on storing connection strings, 
//                //see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-51CUQQV;Database=promos-F7;+" +
//                    "Trusted_Connection=true;");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

//            modelBuilder.Entity<AspNetRole>(entity =>
//            {
//                entity.Property(e => e.Name).HasMaxLength(256);

//                entity.Property(e => e.NormalizedName).HasMaxLength(256);
//            });

//            modelBuilder.Entity<AspNetRoleClaim>(entity =>
//            {
//                entity.Property(e => e.RoleId)
//                    .IsRequired()
//                    .HasMaxLength(450);

//                entity.HasOne(d => d.Role)
//                    .WithMany(p => p.AspNetRoleClaims)
//                    .HasForeignKey(d => d.RoleId);
//            });

//            modelBuilder.Entity<AspNetUser>(entity =>
//            {
//                entity.Property(e => e.Email).HasMaxLength(256);

//                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

//                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

//                entity.Property(e => e.UserName).HasMaxLength(256);
//            });

//            modelBuilder.Entity<AspNetUserClaim>(entity =>
//            {
//                entity.Property(e => e.UserId)
//                    .IsRequired()
//                    .HasMaxLength(450);

//                entity.HasOne(d => d.User)
//                    .WithMany(p => p.AspNetUserClaims)
//                    .HasForeignKey(d => d.UserId);
//            });

//            modelBuilder.Entity<AspNetUserLogin>(entity =>
//            {
//                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

//                entity.Property(e => e.UserId)
//                    .IsRequired()
//                    .HasMaxLength(450);

//                entity.HasOne(d => d.User)
//                    .WithMany(p => p.AspNetUserLogins)
//                    .HasForeignKey(d => d.UserId);
//            });

//            modelBuilder.Entity<AspNetUserRole>(entity =>
//            {
//                entity.HasKey(e => new { e.UserId, e.RoleId });

//                entity.HasOne(d => d.Role)
//                    .WithMany(p => p.AspNetUserRoles)
//                    .HasForeignKey(d => d.RoleId);

//                entity.HasOne(d => d.User)
//                    .WithMany(p => p.AspNetUserRoles)
//                    .HasForeignKey(d => d.UserId);
//            });

//            modelBuilder.Entity<AspNetUserToken>(entity =>
//            {
//                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

//                entity.HasOne(d => d.User)
//                    .WithMany(p => p.AspNetUserTokens)
//                    .HasForeignKey(d => d.UserId);
//            });

//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//    }
}
