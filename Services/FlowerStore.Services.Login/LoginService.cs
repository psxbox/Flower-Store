using FlowerStore.Common;
using FlowerStore.Context;
using FlowerStore.Context.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerStore.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly MainDbContext context;

        public LoginService(MainDbContext context)
        {
            this.context = context;
        }

        public async Task<User?> LoginAsync(string userName, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == userName &&
                u.PasswordHash == password.GetMD5());
            if (user == null) return null;

            return user;
        }
    }
}
