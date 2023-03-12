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
        public bool EmailConfirmed { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }

        public static implicit operator UserAccountModel?(User? user)
        {
            if (user == null) return null;

            return new()
            {
                Id = user.Id,
                Name = user.UserName,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed
            };
        }
    }
}