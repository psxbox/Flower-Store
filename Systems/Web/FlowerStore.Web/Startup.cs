using FlowerStore.Web.Services.Flower;

namespace FlowerStore.Web
{
    public static class Startup
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IFlowerService, FlowerService>();
        }
    }
}
