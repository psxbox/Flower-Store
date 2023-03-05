using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerStore.Context;
using FlowerStore.Context.Entities;
using FlowerStore.Services.Settings;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Logging;

namespace FlowerStore.Api.Configuration;

/// <summary>
/// Authentication and Authorization config
/// </summary>
public static class AuthConfiguration
{
    public static IServiceCollection AddAppAuth(this IServiceCollection services, IdentitySettings settings)
    {
        IdentityModelEventSource.ShowPII = true;

        services.AddIdentity<User, UserRole>(opt =>
        {
            opt.Password.RequiredLength = 4;
            opt.Password.RequireDigit = false;
            opt.Password.RequireLowercase = false;
            opt.Password.RequireUppercase = false;
            opt.Password.RequireNonAlphanumeric = false;
        })
            .AddEntityFrameworkStores<MainDbContext>()
            .AddUserManager<UserManager<User>>()
            .AddDefaultTokenProviders();

        services.AddAuthentication(opt => {
            opt.DefaultScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
            opt.DefaultAuthenticateScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(IdentityServerAuthenticationDefaults.AuthenticationScheme, opt => {
                opt.RequireHttpsMetadata = settings.Url?.StartsWith("https://") ?? false;
                opt.Authority = settings.Url;
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = false,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
                opt.Audience = "api";
            });
        
        services.AddAuthorization();

        return services;
    }

    public static IApplicationBuilder UseAppAuth(this IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }
}