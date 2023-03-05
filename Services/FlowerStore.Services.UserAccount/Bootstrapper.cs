using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace FlowerStore.Services.UserAccount
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddUserAccountService(this IServiceCollection services)
        {
            services.AddScoped<IUserAccountService, UserAccountService>();
            return services;
        }
    }
}