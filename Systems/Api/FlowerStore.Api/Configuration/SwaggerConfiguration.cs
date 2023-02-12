using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerStore.Services.Settings;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FlowerStore.Api.Configuration;

public static class SwaggerConfiguration
{
    private static readonly string AppTitle = "FlowerStore Api";

    /// <summary>
    /// Add Swagger
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddAppSwagger(this IServiceCollection services, SwaggerSettings? settings)
    {
        if (!(settings?.Enabled ?? false))
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

        services.AddSwaggerGen();
        return services;
    }

    /// <summary>
    /// Start the Swagger
    /// </summary>
    /// <param name="app"></param>
    /// <param name="swaggerSettings"></param>
    public static void UseAppSwagger(this WebApplication app, SwaggerSettings? swaggerSettings)
    {
        if (!(swaggerSettings?.Enabled ?? false))
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