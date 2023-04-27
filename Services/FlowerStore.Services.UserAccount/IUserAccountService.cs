using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerStore.Context.Entities;
using FlowerStore.Services.UserAccount.Models;

namespace FlowerStore.Services.UserAccount
{
    public interface IUserAccountService
    {
        Task<User> CreateAsync(RegisterUserModel model);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(string id);
        Task<IEnumerable<string>> GetRoleTypes();
        Task SetRolesAsync(string userId, IEnumerable<string> roles);
        Task SetPasswordAsync(string userId, string password);
        Task ChangePasswordAsync(string userId, string oldPassword, string newPassword);
        Task SetEmailConfirmedAsync(string userId, bool emailConfirmed);
        Task SetPhoneNumberConfirmedAsync(string userId, bool phoneNumberConfirmed);
        Task SetUserStatusAsync(string userId, UserStatus status);
        Task UpdateUser(string userId, UpdateUserModel model);
    }
}