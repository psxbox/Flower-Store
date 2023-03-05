using FlowerStore.Common;
using FlowerStore.Services.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;

namespace FlowerStore.Api.Pages;

public class IndexModel : PageModel
{
    private readonly SwaggerSettings swaggerSettings;

    [BindProperty]
    public bool OpenApiEnabled => swaggerSettings.Enabled;

    [BindProperty]
    public string Version => Assembly.GetExecutingAssembly().GetAssemblyVersion();

    public IndexModel(SwaggerSettings swaggerSettings)
    {
        this.swaggerSettings = swaggerSettings;
    }

    public void OnGet()
    {
    }
}
