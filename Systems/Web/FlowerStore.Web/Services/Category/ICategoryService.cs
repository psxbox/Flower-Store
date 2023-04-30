namespace FlowerStore.Web.Services.Category
{
    public interface ICategoryService
    {
        Task<IEnumerable<string>?> GetCategoriesAsync();
    }
}
