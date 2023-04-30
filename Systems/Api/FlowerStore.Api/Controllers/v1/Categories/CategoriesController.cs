using FlowersStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlowerStore.Api.Controllers.v1.Categories
{
    /// <summary>
    /// Categories controller
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/categories")]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }


        [HttpGet]
        public async Task<IEnumerable<string>> GetCategoriesAsync()
        {
            return (await categoryService.GetAllAsync()).Select(c => c.Name!);
        }
    }
}
