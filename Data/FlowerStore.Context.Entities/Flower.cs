using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerStore.Context.Entities
{
    public class Flower : BaseEntity
    {
        [Required(ErrorMessage = "Flower name is required"), StringLength(50)]
        public string? Name { get; set; }
        public string? Desription { get; set; }
        public virtual ICollection<Category>? Categories { get; set; }
    }
}