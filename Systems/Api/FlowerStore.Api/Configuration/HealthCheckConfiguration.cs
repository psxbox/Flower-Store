using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerStore.Api.Configuration
{
    /// <summary>
    /// HealthCheck configuration
    /// </summary>
    public static class HealthCheckConfiguration
    {
        /// <summary>
        /// Add app HealthCheck
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddAppHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddCheck<SelfHealthCheck>("FlowerStore.Api");
            return services;
        }

        /// <summary>
        /// Use app HealthCheck
        /// </summary>
        /// <param name="app"></param>
        public static void UseAppHealthChecks(this WebApplication app)
        {
            app.MapHealthChecks("/health");
        }

    }
}