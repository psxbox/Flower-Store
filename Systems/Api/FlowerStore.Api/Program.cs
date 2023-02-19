using FlowerStore.Api;
using FlowerStore.Api.Configuration;
using FlowerStore.Services.Settings;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

var builder = WebApplication.CreateBuilder(args);
var swaggerSettings = AppSettings.Settings.Load<SwaggerSettings>("Swagger", builder.Configuration);

builder.Services.AddControllers(options =>
{
    options.ModelMetadataDetailsProviders.Add(new SystemTextJsonValidationMetadataProvider());
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAppHealthChecks();
builder.Services.AddAppSwagger(swaggerSettings);
builder.Services.AddAppVersioning();
builder.Services.RegisterAppServices();

var app = builder.Build();

app.UseAppHealthChecks();
app.UseAppSwagger(swaggerSettings);

app.UseAuthorization();

app.MapControllers();

app.Run();
