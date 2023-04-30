using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerStore.Context.Entities
{
    public class Bouquet : BaseEntity
    {
        public virtual User? User { get; set; }

        [Required(ErrorMessage = "Bouquet name is required"), StringLength(50)]
        public string? Name { get; set; }
        public string? Desription { get; set; }
        public virtual ICollection<Flower>? Flowers { get; set; }
        public decimal? TotalPrice { get; set; }
        public virtual ICollection<Category>? Categories { get; set; }
    }
}