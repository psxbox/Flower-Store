using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerStore.Common.Security;
using FlowerStore.Services.Settings;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace FlowerStore.Api.Configuration;

/// <summary>
/// Swagger configuration class
/// </summary>
public static class SwaggerConfiguration
{
    private static readonly string AppTitle = "FlowerStore Api";

    /// <summary>
    /// Add Swagger
    /// </summary>
    /// <param name="identitySettings"></param>
    /// <param name="services"></param>
    /// <param name="swaggerSettings"></param>
    /// <returns></returns>
    public static IServiceCollection AddAppSwagger(this IServiceCollection services, IdentitySettings identitySettings, SwaggerSettings? swaggerSettings)
    {
        if (!(swaggerSettings?.Enabled ?? false))
        {
            return services;
        }

        // Configure SwaggerOptions to register all API versions
        services
            .AddOptions<SwaggerGenOptions>()
            .Configure<IApiVersionDescriptionProvider>((options, provider) =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(description.GroupName, new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Version = description.ApiVersion.ToString(),
                        Title = AppTitle
                    });
                }
            });


        services.AddSwaggerGen(options =>
        {
            var xmlDocFile = "api.xml";
            var xmlDocFilePath = Path.Combine(AppContext.BaseDirectory, xmlDocFile);
            options.IncludeXmlComments(xmlDocFilePath, true);

            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Name = "Bearer",
                Type = SecuritySchemeType.OAuth2,
                Scheme = "oauth2",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Flows = new OpenApiOAuthFlows
                {
                    Password = new OpenApiOAuthFlow
                    {
                        TokenUrl = new Uri($"{identitySettings.Url}/connect/token"),
                        Scopes = new Dictionary<string, string>
                        {
                            { AppScopes.FlowersRead, "FlowerRead" },
                            { AppScopes.FlowersWrite, "FlowerWrite" }
                        }
                    }
                }
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "oauth2"
                        }
                    },
                    new List<string>()
                }
            });

            options.UseOneOfForPolymorphism();
        });


        return services;
    }

    /// <summary>
    /// Start the Swagger
    /// </summary>
    /// <param name="app"></param>
    /// <param name="settings"></param>
    public static void UseAppSwagger(this WebApplication app, SwaggerSettings? settings)
    {
        if (!(settings?.Enabled ?? false))
        {
            return;
        }

        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant());
            }
        });
    }
}