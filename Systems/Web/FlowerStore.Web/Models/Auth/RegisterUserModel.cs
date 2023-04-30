using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerStore.Web.Models.Auth
{
    public class RegisterUserModel
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
    }
}