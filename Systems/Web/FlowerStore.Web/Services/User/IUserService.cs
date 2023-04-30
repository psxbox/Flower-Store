using FlowerStore.Web.Models.Auth;
using FlowerStore.Web.Models.User;
using System.Collections;

namespace FlowerStore.Web.Services.User
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>?> GetAllAsync();
        Task<UserModel?> GetByIdAsync(Guid id);
        Task<IEnumerable<string>?> GetRoleTypesAsync();
        Task SetRolesAsync(Guid userId, string roles);
        Task SetPasswordAsync(Guid userId, PasswordRequest passwordRequest);
        Task ChangePasswordAsync(ChangePasswordRequest changePasswordRequest);
        Task UpdateUserAsync(Guid userId, UserModel user);
        Task<bool> RegisterAsync(RegisterUserModel model);
    }
}
