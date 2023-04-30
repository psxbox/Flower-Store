using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerStore.Context.Entities
{
    public class Basket : BaseEntity
    {
        public virtual User? User { get; set; }
        public virtual Flower? Flower { get; set; }
        public int? FlowerCount { get; set; }
        public virtual Bouquet? Bouquet { get; set; }
    }
}
