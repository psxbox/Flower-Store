using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FlowerStore.Context.Entities;
using Microsoft.Extensions.Logging;
using FlowerStore.Common;

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
        var context = scope?.ServiceProvider.GetRequiredService<MainDbContext>();

        if (context == null) return;

        var role = await context.UserRoles.FirstOrDefaultAsync(r => r.Role == Role.SystemAdmin);

        if (role == null)
        {
            role = new UserRole
            {
                Role = Role.SystemAdmin
            };
            await context.UserRoles.AddAsync(role);
            await context.SaveChangesAsync();
        }

        var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == masterUserName);
        if (user != null) return;

        user = new User
        {
            Id = Guid.NewGuid(),
            UserName = masterUserName,
            Email = masterEmail,
            EmailConfirmed = true,
            PasswordHash = masterPassword.GetMD5(),
            UserRoles = new List<UserRole> { role }
        };


        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        logger?.LogInformation("User {user} created", user.UserName);
        
    }
}