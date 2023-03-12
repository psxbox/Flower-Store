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
            var dbSettings = AppSettings.Settings.Load<DbSettings>("Database", configuration);
            if (dbSettings?.ConnectionString == null)
                throw new Exception("Database settings is not configured!");

            services.AddDbContext<MainDbContext>(DbContextOptionFactory.Configure(dbSettings.ConnectionString, dbSettings.Type));

            return services;
        }
    }
}