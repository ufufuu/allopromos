using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Infrastructure.Helpers
{
  public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            EntityTypeBuilder<IdentityRole> entityTypeBuilder = builder;
            IdentityRole[] identityRoleArray = new IdentityRole[3];
            IdentityRole identityRole1 = new IdentityRole();
            identityRole1.Name = "Administrators";
            identityRole1.NormalizedName = "ADMINISTRATORS";
            identityRoleArray[0] = identityRole1;
            IdentityRole identityRole2 = new IdentityRole();
            identityRole2.Name = "Merchants";
            identityRole2.NormalizedName = "MERCHANTS";
            identityRoleArray[1] = identityRole2;
            IdentityRole identityRole3 = new IdentityRole();
            identityRole3.Name = "Users";
            identityRole3.NormalizedName = "USERS";
            identityRoleArray[2] = identityRole3;
            entityTypeBuilder.HasData(identityRoleArray);
        }
    }
}
