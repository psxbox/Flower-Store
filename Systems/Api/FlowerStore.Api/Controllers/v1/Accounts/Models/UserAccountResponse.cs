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
        /// Full name
        /// </summary>
        public string? FullName { get; set; }

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
                FullName = model.FullName
            };
        }
    }
}