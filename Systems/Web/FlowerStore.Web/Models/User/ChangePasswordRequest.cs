using System.ComponentModel.DataAnnotations;

namespace FlowerStore.Web.Models.User
{
    public class ChangePasswordRequest
    {
        /// <summary>
        /// Old password
        /// </summary>
        [Required]
        public string? OldPassword { get; set; }

        /// <summary>
        /// New password
        /// </summary>
        [Required(ErrorMessage = "New password is required"), DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Must be between 4 and 50 characters")]
        public string? NewPassword { get; set; }

        /// <summary>
        /// New password confirmation
        /// </summary>
        [Required(ErrorMessage = "New confirm password is required"), DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Must be between 4 and 50 characters")]
        [Compare(nameof(NewPassword))]
        public string? NewConfirmedPassword { get; set; }
    }
}
