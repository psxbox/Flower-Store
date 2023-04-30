namespace FlowerStore.Web.Models.Flower
{
    public class FlowerModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; } = string.Empty;
        public decimal? Price { get; set; } = 0;
        public int? Count { get; set; } = 0;
        public List<string>? Categories { get; set; }
    }
}
