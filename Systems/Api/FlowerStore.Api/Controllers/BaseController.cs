using Microsoft.AspNetCore.Mvc;

namespace FlowerStore.Api.Controllers
{
    /// <summary>
    /// Base controller
    /// </summary>
    public abstract class BaseController : ControllerBase
    {
        /// <summary>
        /// Gets user id
        /// </summary>
        /// <returns></returns>
        protected string? GetUser()
        {
            var claim = User.Claims.FirstOrDefault(c => c.Type == "Id");
            return claim?.Value;
        }
    }
}
