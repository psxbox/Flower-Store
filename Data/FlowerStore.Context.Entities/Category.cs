using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerStore.Context.Entities
{
    [Index("Name", IsUnique = true)]
    public class Category : BaseEntity
    {
        [Required(ErrorMessage = "Category name is required"), StringLength(50)]
        public string? Name { get; set; }
    }
}