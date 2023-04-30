using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerStore.Context.Entities
{
    public class Order : BaseEntity
    {
        public virtual User? User { get; set; }
        public DateTime DateTime { get; set; }
        public virtual ICollection<OrderItem>? OrederItems { get; set; }
        public decimal? TotalPrice { get; set; }
        public bool IsPayed { get; set; } = false;
        public bool IsCanceled { get; set; } = false;
    }
}
