using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerStore.Identity.Configuration;

public static class HealthCheckConfiguration
{
    public static IServiceCollection AddAppHealthCheck(this IServiceCollection services)
    {
        services.AddHealthChecks();
        return services;
    }

    public static void UseAppHealthChecks(this WebApplication app)
    {
        app.MapHealthChecks("/health");
    }
}