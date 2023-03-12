using System.ComponentModel.DataAnnotations;

namespace FlowerStore.Api.Controllers.v1.Login.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class UserLogin
    {
        /// <summary>
        /// </summary>
        [Required]
        public string? UserName { get; set; }
        /// <summary>
        /// </summary>
        public string? Password { get; set; }
    }
}
