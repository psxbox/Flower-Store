using FlowerStore.Context.Entities;

namespace FlowerStore.Services.UserAccount.Models
{
    public class UpdateUserModel
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public bool EmailConfirmed { get; set; } 
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public UserStatus Status { get; set; }
    }
}