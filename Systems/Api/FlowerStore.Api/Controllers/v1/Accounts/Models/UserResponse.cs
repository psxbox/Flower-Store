using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerStore.Context.Entities;
using FlowerStore.Services.UserAccount.Models;

namespace FlowerStore.Api.Controllers.v1.Accounts.Models
{
    /// <summary>
    /// UserAccountResponse
    /// </summary>
    public class UserResponse
    {
        /// <summary>
        /// User Id
        /// </summary>
        /// <value></value>
        public Guid Id { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        /// <value></value>
        public string? Name { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        /// <value></value>
        public string? Email { get; set; }

        /// <summary>
        /// Email is confirmed
        /// </summary>
        public bool EmailConfirmed { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        /// <value></value>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Phone number confirmation
        /// </summary>
        public bool PhoneNumberConfirmed { get; set; }
        
        /// <summary>
        /// User status
        /// </summary>
        public UserStatus UserStatus { get; set; }

        /// <summary>
        /// User roles
        /// </summary>
        public IEnumerable<string>? UserRoles { get; set; }

        /// <summary>
        /// Converts <c>UserAccountModel</c> to <c>UserAccountResponse</c>
        /// </summary>
        /// <param name="user"></param>
        public static implicit operator UserResponse(User user)
        {
            return new()
            {
                Id = user.Id,
                Name = user.UserName,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                UserStatus = user.Status,
                UserRoles = user.UserRoles?.Select(r => r.Role.ToString())
            };
        }
    }
}