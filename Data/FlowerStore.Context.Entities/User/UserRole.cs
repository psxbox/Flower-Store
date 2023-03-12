using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerStore.Context.Entities
{
    [Index("Name", IsUnique = true)]
    public class UserRole 
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string? Name { get; set; }
        public virtual ICollection<User>? Users { get; set; }
    }
}