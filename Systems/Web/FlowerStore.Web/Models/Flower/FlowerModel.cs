namespace FlowerStore.Web.Models.Flower
{
    public class FlowerModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? Count { get; set; }
        public List<string>? Categories { get; set; }
    }
}
