using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace FlowerStore.Api.Configuration
{
    public class SelfHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var assembly = Assembly.Load("FlowerStore.Api");
            var version = assembly.GetName().Version;
            return Task.FromResult(HealthCheckResult.Healthy(description: $"Application build version {version}"));
        }
    }
}