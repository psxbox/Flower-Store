using System.ComponentModel.DataAnnotations;

namespace FlowerStore.Web.Models.User
{
    public class UserModel
    {
        public Guid Id { get; set; }
        [Required]
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        [Required]
        public UserStatus Status { get; set; }
        public IEnumerable<string>? UserRoles { get; set; }
    }
}
