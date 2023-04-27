using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowersStore.Services;
using FlowerStore.Services.Flowers;
using FlowerStore.Services.Login;
using FlowerStore.Services.UserAccount;

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
                .AddScoped<ICategoryService, CategoryService>()
                .AddScoped<IFlowerService, FlowerService>()
                .AddScoped<ILoginService, LoginService>()
                .AddScoped<IUserAccountService, UserAccountService>()
            ;
            return services;
        }
    }
}