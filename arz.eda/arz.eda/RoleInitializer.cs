using arz.eda.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace arz.eda
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<Account> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@gmail.com";
            string password = "Admin7!";
            var existingRoles = roleManager.Roles.Select(x => x.Name).ToList();
            var roles = new[] { "admin" , "user", "courier", "manager"};
            var creatingTasks = roles
                .Where(x => !existingRoles.Contains(x))
                .Select(x => new IdentityRole(x))
                .Select(x => roleManager.CreateAsync(x));
            await Task.WhenAll(creatingTasks);
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                Account admin = new() { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
