
using FlowerStore.Web.Models.Auth;

namespace FlowerStore.Web.Services.Auth
{
    public interface IAuthService
    {
        Task<LoginResult> Login(string userName, string password);
        Task Logout();

    }
}
