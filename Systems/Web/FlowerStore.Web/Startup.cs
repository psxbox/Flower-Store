using FlowerStore.Web.Services.Category;
using FlowerStore.Web.Services.Flower;
using FlowerStore.Web.Services.User;

namespace FlowerStore.Web
{
    public static class Startup
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services
                .AddScoped<IFlowerService, FlowerService>()
                .AddScoped<ICategoryService, CategoryService>()
                .AddScoped<IUserService, UserService>();

        }
    }
}
