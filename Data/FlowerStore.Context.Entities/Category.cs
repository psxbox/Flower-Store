using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerStore.Context.Entities
{
    public class Category : BaseEntity
    {
        [Required(ErrorMessage = "Category name is required"), StringLength(50)]
        public string? Name { get; set; }
        public virtual ICollection<Flower>? Flowers { get; set; }
    }
}