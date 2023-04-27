namespace FlowerStore.Context.Entities
{
    public class OrderItem : BaseEntity
    {
        public virtual Order? Order { get; set; }
        public virtual Flower? Flower { get; set; }
        public int? FlowerCount { get; set; }
        public virtual Bouquet? Bouquet { get; set; }
    }
}