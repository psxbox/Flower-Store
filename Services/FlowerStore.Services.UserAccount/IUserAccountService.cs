using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerStore.Services.UserAccount.Models;

namespace FlowerStore.Services.UserAccount
{
    public interface IUserAccountService
    {
        Task<UserAccountModel> Create(RegisterAccountModel model);
    }
}