using Bookshelf.Models;
using Microsoft.AspNetCore.Identity;

namespace Bookshelf.Data;

public static class DbInitializer
{
  public static async Task InitializeAsync(IServiceProvider serviceProvider)
  {
    RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();

    string[] roles =
    [
      "Admin",
      "User"
    ];

    foreach (string role in roles)
    {
      if (!await roleManager.RoleExistsAsync(role))
      {
        await roleManager.CreateAsync(new IdentityRole(role));
      }
    }

    const string username = "admin";
    const string email = "admin@bookshelf.local";
    const string password = "Admin123!";

    User? admin = await userManager.FindByNameAsync(username);

    if (admin is null)
    {
      admin = new User
      {
        UserName = username,
        Email = email
      };

      IdentityResult result = await userManager.CreateAsync(admin, password);

      if (result.Succeeded)
      {
        await userManager.AddToRoleAsync(admin, "Admin");
      }
    }
  }
}