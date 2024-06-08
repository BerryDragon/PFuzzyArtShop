using Microsoft.AspNetCore.Identity;
using PFuzzyArtShop.Models.IdentityModels;

namespace PlantShop.Models
{
    public class ConfigureIdentity
    {
        public static async Task CreateAdminUserAsync(IServiceProvider provider)
        {
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = provider.GetRequiredService<UserManager<FuzzyShopUser>>();

            string username = "BigGuy";
            string password = "P@ssword1";
            string rolename = "Admin";

            if (await roleManager.FindByNameAsync(rolename) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(rolename));
            }
            if (await userManager.FindByNameAsync(username) == null)
            {
                FuzzyShopUser psuser = new FuzzyShopUser { UserName = username };
                var result = await userManager.CreateAsync(psuser, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(psuser, rolename);
                }
            }
        }
    }
}
