using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerStore.Services.Login
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddAppLogin(this IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
            return services;
        }
    }
}
