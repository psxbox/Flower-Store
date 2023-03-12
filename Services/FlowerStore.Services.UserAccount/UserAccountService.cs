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

        public async Task<UserAccountModel> Create(RegisterAccountModel model)
        {
            var validationContext = new ValidationContext(model);
            bool isValid = Validator.TryValidateObject(model, validationContext, null);

            if (!isValid) throw new ValidationException("Model is invalid", null, model);

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

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user!;
        }

        public async Task<UserAccountModel?> Get(string id)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id.ToString() == id);
            return user;
        }

        public Task<IEnumerable<UserAccountModel>> GetAll()
        {
            return Task.FromResult(context.Users.ToList().Select(u => (UserAccountModel)u!));
        }

    }
}