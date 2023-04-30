namespace FlowerStore.Web.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;
        private string? ApiRoot => configuration["Server:ApiRoot"];

        public CategoryService(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<string>?> GetCategoriesAsync()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<string>>($"{ApiRoot}/v1/categories");
            return result;
        }
    }
}
