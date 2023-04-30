using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FlowerStore.Services.UserAccount.Models;

namespace FlowerStore.Api.Controllers.v1.Accounts.Models
{
    /// <summary>
    /// RegisterUserAccountRequest
    /// </summary>
    public class RegisterUserRequest
    {
        /// <summary>
        /// Name
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "User name is required.")]
        public string? Name { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "Email is required"), EmailAddress(ErrorMessage = "Incorrect email")]
        public string? Email { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "Password is required"), DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Must be between 4 and 50 characters")]
        public string? Password { get; set; }

        /// <summary>
        /// ConfirmPassword
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "Confirm password is required"), DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Must be between 4 and 50 characters")]
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }

        /// <summary>
        /// Converts <c>RegisterUserAccountRequest</c> to <c>RegisterAccountModel</c>
        /// </summary>
        /// <param name="registerUser"></param>
        public static implicit operator RegisterUserModel(RegisterUserRequest registerUser)
        {
            return new()
            {
                UserName = registerUser.Name,
                Email = registerUser.Email,
                Password = registerUser.Password
            };
        }
    }
}