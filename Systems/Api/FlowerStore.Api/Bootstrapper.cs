using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerStore.Services.Flowers;

namespace FlowerStore.Api
{
    /// <summary>
    /// Web API bootstrapper
    /// </summary>
    public static class Bootstrapper
    {
        /// <summary>
        /// Register app services
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services
                .AddFlowerService()
                ;
            
            return services;
        }
    }
}