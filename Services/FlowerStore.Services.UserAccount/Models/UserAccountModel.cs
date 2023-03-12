using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerStore.Context.Entities;

namespace FlowerStore.Services.UserAccount.Models
{
    public class UserAccountModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }

        public static implicit operator UserAccountModel(User user)
        {
            return new()
            {
                Id = user.Id,
                Name = user.UserName,
                Email = user.Email,
                FullName = user.FullName
            };
        }
    }
}