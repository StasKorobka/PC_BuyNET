using Microsoft.AspNetCore.Identity;
using PC_BuyNET.Areas.Identity.Data;

namespace PC_BuyNET.Data
{
    public static class DbInitializer 
    {
        public static async Task SeedAdminUserAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            //Create Admin role if it doesn't exist
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            //Create admin user
            var adminEmail = "admin@pcbuynet.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new User
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };


                var result = await userManager.CreateAsync(adminUser, "Admin123!"); // secure password!

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }

    }
}