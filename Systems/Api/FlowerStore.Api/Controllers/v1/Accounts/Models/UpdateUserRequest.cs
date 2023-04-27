using FlowerStore.Services.UserAccount.Models;
using System.ComponentModel.DataAnnotations;

namespace FlowerStore.Api.Controllers.v1.Accounts.Models
{
    /// <summary>
    /// User update request model
    /// </summary>
    public class UpdateUserRequest
    {
        /// <summary>
        /// User name - Login
        /// </summary>
        [Required]
        public string? UserName { get; set; }
        
        /// <summary>
        /// Email address
        /// </summary>
        [Required, EmailAddress]
        public string? Email { get; set; }

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
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Mapping 
        /// </summary>
        /// <param name="request"></param>
        public static implicit operator UpdateUserModel(UpdateUserRequest request)
        {
            return new UpdateUserModel
            {
                UserName = request.UserName,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
            };
        }
    }
}
