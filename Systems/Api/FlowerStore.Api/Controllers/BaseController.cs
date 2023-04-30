using FlowerStore.Context.Entities;
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
        protected string? GetUserId()
        {
            var claim = User.Claims.FirstOrDefault(c => c.Type == "Id");
            return claim?.Value;
        }

        /// <summary>
        /// Verify user is in role "SystemAdmin"
        /// </summary>
        protected bool IsSystemAdmin => User.IsInRole(Role.SystemAdmin.ToString());

        /// <summary>
        /// Chack user logged as Admin
        /// </summary>
        /// <returns></returns>
        protected bool AsAdmin()
        {
            var claim = User.Claims.FirstOrDefault(c => c.Type == "AsAdmin");
            if (bool.TryParse(claim?.Value ?? "False", out bool asAdmin)) { return asAdmin; }
            return false;
        }
    }
}
