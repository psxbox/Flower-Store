using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FlowerStore.Common.Exceptions;
using FlowerStore.Context.Entities;
using FlowerStore.Services.UserAccount.Models;
using Microsoft.AspNetCore.Identity;

namespace FlowerStore.Services.UserAccount
{
    public class UserAccountService : IUserAccountService
    {
        private readonly UserManager<User> userManager;
        public UserAccountService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<UserAccountModel> Create(RegisterAccountModel model)
        {
            var context = new ValidationContext(model);
            bool isValid = Validator.TryValidateObject(model, context, null);

            if (!isValid) throw new ValidationException("Model is invalid", null, model);

            var user = await userManager.FindByEmailAsync(model.Email!);

            if (user != null)
                throw new ProcessException($"User account with email {model.Email} already exist.");

            user = new User()
            {
                Status = UserStatus.Active,
                FullName = model.Name,
                UserName = model.Name,
                Email = model.Email,
                EmailConfirmed = true,
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
            };

            var result = await userManager.CreateAsync(user, model.Password!);

            if (!result.Succeeded)
                throw new ProcessException($"Creating user account is wrong. {
                    string.Join(", ", result.Errors.Select(e => e.Description))
                }");
            
            return user;
        }

        public Task<IEnumerable<UserAccountModel>> GetAll()
        {
            return Task.FromResult(userManager.Users.ToList().Select(u => (UserAccountModel)u));
        }
    }
}