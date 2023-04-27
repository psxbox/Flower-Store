using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using FlowerStore.Common;
using FlowerStore.Common.Exceptions;
using FlowerStore.Context;
using FlowerStore.Context.Entities;
using FlowerStore.Services.UserAccount.Models;
using Microsoft.EntityFrameworkCore;

namespace FlowerStore.Services.UserAccount
{
    public class UserAccountService : IUserAccountService
    {
        private readonly MainDbContext context;

        public UserAccountService(MainDbContext context)
        {
            this.context = context;
        }

        public async Task<User> CreateAsync(RegisterUserModel model)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == model.UserName);

            if (user != null)
                throw new ProcessException($"User account with name {model.UserName} already exist.");

            user = new User()
            {
                Status = UserStatus.Active,
                UserName = model.UserName,
                Email = model.Email,
                EmailConfirmed = true,
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                PasswordHash = model.Password?.GetMD5(),
            };

            user.UserRoles = new List<UserRole>()
            {
                new UserRole { Role = Role.User},
            };

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user!;
        }

        public async Task<User?> GetByIdAsync(string id)
        {
            var user = await context.Users.FindAsync(Guid.Parse(id));
            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await context.Users.ToListAsync();
        }

        public Task<IEnumerable<string>> GetRoleTypes()
        {
            return Task.FromResult(Enum.GetValues<Role>().Select(r => r.ToString()));
        }

        public async Task SetRolesAsync(string userId, IEnumerable<string> roles)
        {
            var user = await GetUser(userId);

            if (user.UserRoles == null)
                user.UserRoles = new List<UserRole>();
            else
                user.UserRoles.Clear();

            foreach (var role in roles)
            {
                user.UserRoles?.Add(new UserRole { Role = Enum.Parse<Role>(role) });
            }

            context.Users.Update(user);
            await context.SaveChangesAsync();
        }

        public async Task SetPasswordAsync(string userId, string password)
        {
            User user = await GetUser(userId);

            user.PasswordHash = password.GetMD5();
            context.Update(user);
            await context.SaveChangesAsync();
        }

        private async Task<User> GetUser(string userId)
        {
            return await GetByIdAsync(userId)
                            ?? throw new ProcessException(ProcessExceptionCode.NotFound, "User not found");
        }

        public async Task ChangePasswordAsync(string userId, string oldPassword, string newPassword)
        {
            var user = await GetUser(userId);
            ProcessException.ThrowIf(() => user.PasswordHash != oldPassword.GetMD5(), "Old password is not match");
            user.PasswordHash = newPassword.GetMD5();
            context.Update(user);
            await context.SaveChangesAsync();
        }

        public async Task SetEmailConfirmedAsync(string userId, bool emailConfirmed)
        {
            var user = await GetUser(userId);
            user.EmailConfirmed = emailConfirmed;
            context.Update(user);
            await context.SaveChangesAsync();
        }

        public async Task SetPhoneNumberConfirmedAsync(string userId, bool phoneNumberConfirmed)
        {
            var user = await GetUser(userId);
            user.PhoneNumberConfirmed = phoneNumberConfirmed;
            context.Update(user);
            await context.SaveChangesAsync();
        }

        public async Task SetUserStatusAsync(string userId, UserStatus status)
        {
            var user = await GetUser(userId);
            user.Status = status;
            context.Update(user);
            await context.SaveChangesAsync();
        }

        public async Task UpdateUser(string userId, UpdateUserModel model)
        {
            var user = await GetUser(userId);
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;
            context.Update(user);
            await context.SaveChangesAsync();
        }
    }
}