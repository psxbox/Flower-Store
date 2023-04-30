using System.ComponentModel.DataAnnotations;

namespace FlowerStore.Web.Models.User
{
    public class PasswordRequest
    {
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
