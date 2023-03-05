using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerStore.Context.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlowerStore.Context
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services, IConfiguration? configuration = null)
        {
            var settings = AppSettings.Settings.Load<DbSettings>("Database", configuration);
            services.AddSingleton(settings);

            var dbInitOptionsDelegate = DbContextOptionsFactory.Configure(
                settings.ConnectionString ?? "", settings.Type);

            services.AddDbContextFactory<MainDbContext>(dbInitOptionsDelegate);

            return services;
        }
    }
}