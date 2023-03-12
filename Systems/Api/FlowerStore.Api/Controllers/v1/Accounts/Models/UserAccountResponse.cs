using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerStore.Services.UserAccount.Models;

namespace FlowerStore.Api.Controllers.v1.Accounts.Models
{
    /// <summary>
    /// UserAccountResponse
    /// </summary>
    public class UserAccountResponse
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
        /// Converts <c>UserAccountModel</c> to <c>UserAccountResponse</c>
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator UserAccountResponse(UserAccountModel model)
        {
            return new()
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                EmailConfirmed = model.EmailConfirmed,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                PhoneNumberConfirmed = model.PhoneNumberConfirmed
            };
        }
    }
}