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
            builder.HasData(
                new IdentityRole
                {
                    Name = "Administrators",
                    NormalizedName = "ADMINISTRATORS"
                },
                new IdentityRole
                {
                    Name = "Merchants",
                    NormalizedName = "MERCHANTS"
                },
                new IdentityRole
                {
                    Name = "Users",
                    NormalizedName = "USERS"
                });
        }
    }
}
