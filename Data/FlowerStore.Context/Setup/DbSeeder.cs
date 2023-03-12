using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FlowerStore.Context.Entities;
using Microsoft.Extensions.Logging;

namespace FlowerStore.Context;

public static class DbSeeder
{
    private static readonly string masterUserName = "admin";
    private static readonly string masterPassword = "@dmin123$";
    private static readonly string masterEmail = "admin@flowerstore.com";
    // private static UserManager<User>? userManager;
    private static ILogger? logger;

    public static async void Execute(IServiceProvider serviceProvider, bool addDemo, bool addAdmin = true)
    {
        using var scope = serviceProvider.CreateScope();

        logger = scope.ServiceProvider.GetService<ILogger>();

        if (addAdmin)
            await CreateAdmin(scope);

    }

    private static async Task CreateAdmin(IServiceScope? scope)
    {
        var userManager = scope?.ServiceProvider.GetService<UserManager<User>>();
        var roleManager = scope?.ServiceProvider.GetService<RoleManager<UserRole>>();

        if (userManager == null || roleManager == null) return;

        var role = await roleManager.FindByNameAsync("Admin");

        if (role == null)
        {
            role = new UserRole 
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
            };
            await roleManager.CreateAsync(role);
        }

        var user = await userManager.FindByNameAsync(masterUserName);
        if (user != null) return;

        user = new User
        {
            Id = Guid.NewGuid(),
            UserName = masterUserName,
            Email = masterEmail,
            EmailConfirmed = true,
        };


        var result = userManager.CreateAsync(user, masterPassword).GetAwaiter().GetResult();
        if (result?.Succeeded == true)
        {
            logger?.LogInformation("User {user} created", user.UserName);
        }
        else
        {
            logger?.LogError("Error creating user {user}", user.UserName);
        }

        result = await userManager.AddToRoleAsync(user, "Admin");
        if (result?.Succeeded == true)
        {
            logger?.LogInformation("Success adding to role");
        }
        else
        {
            logger?.LogError("Error adding to role");
        }
    }
}