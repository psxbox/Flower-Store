using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerStore.Context.Entities
{
    public class Flower : BaseEntity
    {
        public virtual User? User { get; set; }

        [Required(ErrorMessage = "Flower name is required"), StringLength(50)]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int Count { get; set; }
        public virtual List<Category>? Categories { get; set; }
    }
}