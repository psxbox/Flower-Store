using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FlowerStore.Context.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string? FullName { get; set; }
        public UserStatus Status { get; set; }
        public byte[]? Logo { get; set; }
    }
}