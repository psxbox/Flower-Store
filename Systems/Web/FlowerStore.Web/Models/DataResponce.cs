namespace FlowerStore.Web.Models
{
    public class DataResponce<T>
    {
        public IEnumerable<T>? Data { get; set; }
        public int TotalPages { get; set; }
        public int TotalElements { get; set; }
        public bool HasNext { get; set; }
    }
}
