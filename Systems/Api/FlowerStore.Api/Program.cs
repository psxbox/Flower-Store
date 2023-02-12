using FlowerStore.Api;
using FlowerStore.Api.Configuration;
using FlowerStore.Services.Settings;

var builder = WebApplication.CreateBuilder(args);
var swaggerSettings = AppSettings.Settings.Load<SwaggerSettings>("Swagger", builder.Configuration);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAppSwagger(swaggerSettings);
builder.Services.AddAppVersioning();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAppSwagger(swaggerSettings);

app.UseAuthorization();

app.MapControllers();

app.Run();
