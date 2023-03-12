using FlowerStore.Api;
using FlowerStore.Api.Configuration;
using FlowerStore.Context;
using FlowerStore.Services.Settings;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

var builder = WebApplication.CreateBuilder(args);
var swaggerSettings = AppSettings.Settings.Load<SwaggerSettings>("Swagger", builder.Configuration);
//var identitySettings = AppSettings.Settings.Load<IdentitySettings>("Identity");

var services = builder.Services;

services.AddHttpContextAccessor();
services.AddCors();

services.AddSingleton(swaggerSettings);

services.AddAppDbContext(builder.Configuration);
services.AddAppAuth(builder.Configuration);

services.AddRazorPages();
services.AddControllers(options =>
{
    options.ModelMetadataDetailsProviders.Add(new SystemTextJsonValidationMetadataProvider());
});

services.AddEndpointsApiExplorer();

services.AddAppHealthChecks();
services.AddAppSwagger(swaggerSettings);
services.AddAppVersioning();
services.RegisterAppServices();

var app = builder.Build();

app.UseStaticFiles();
app.UseAppHealthChecks();
app.UseAppSwagger(swaggerSettings);

app.UseAppAuth();
app.UseCors(c => 
{
    c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
});

app.MapRazorPages();
app.MapControllers();

DbInitializer.Initialize(app.Services);
DbSeeder.Execute(app.Services, false);

app.Run();
