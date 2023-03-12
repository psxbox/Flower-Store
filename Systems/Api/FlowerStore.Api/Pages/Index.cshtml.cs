using FlowerStore.Common;
using FlowerStore.Services.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;

namespace FlowerStore.Api.Pages;

/// <summary>
/// Index page model
/// </summary>
public class IndexModel : PageModel
{
    private readonly SwaggerSettings swaggerSettings;

    /// <summary>
    /// OpenApi enabled property
    /// </summary>
    [BindProperty]
    public bool OpenApiEnabled => swaggerSettings.Enabled;

    /// <summary>
    /// Vesion property
    /// </summary>
    /// <returns></returns>
    [BindProperty]
    public string? Version => Assembly.GetExecutingAssembly().GetAssemblyVersion();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="swaggerSettings"></param>
    public IndexModel(SwaggerSettings swaggerSettings)
    {
        this.swaggerSettings = swaggerSettings;
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnGet()
    {
    }
}
