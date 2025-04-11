using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Infrastructure.Data.Role
{
    public static class RoleSeeder
    {
        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Merchant"))
                roleManager.CreateAsync(new IdentityRole("Merchants"));
            if (await roleManager.RoleExistsAsync("Client"))
                return;
            roleManager.CreateAsync(new IdentityRole("Client"));
        }
    }
}
