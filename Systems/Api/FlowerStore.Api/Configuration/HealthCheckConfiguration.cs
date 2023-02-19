using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerStore.Api.Configuration
{
    public static class HealthCheckConfiguration
    {
        public static IServiceCollection AddAppHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddCheck<SelfHealthCheck>("FlowerStore.Api");
            return services;
        }

        public static void UseAppHealthChecks(this WebApplication app)
        {
            app.MapHealthChecks("/health");
        }
    }
}