using FlowerStore.Context.Entities;
using FlowerStore.Services.UserAccount.Models;
using ObjectMapper;
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
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public UserStatus Status { get; set; }

        /// <summary>
        /// Mapping 
        /// </summary>
        /// <param name="request"></param>
        public static implicit operator UpdateUserModel(UpdateUserRequest request)
        {
            return MapObject<UpdateUserRequest, UpdateUserModel>.GetMapObject().Get(request);
        }
    }
}
