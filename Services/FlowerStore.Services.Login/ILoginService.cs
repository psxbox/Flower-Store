using FlowerStore.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerStore.Services.Login
{
    public interface ILoginService
    {
        public Task<User?> LoginAsync(string userName, string password);
    }
}
