using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace FlowerStore.Services.Flowers;

public static class Bootstrapper
{
    public static IServiceCollection AddFlowerService(this IServiceCollection services)
    {
        services.AddScoped<IFlowerService, FlowerService>();

        return services;
    }
}