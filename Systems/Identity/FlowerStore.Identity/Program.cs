using Duende.IdentityServer.Services;
using FlowerStore.Context;
using FlowerStore.Identity.Configuration;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddCors();
services.AddHttpContextAccessor();
services.AddAppDbContext(builder.Configuration);
services.AddAppHealthCheck();
services.AddIS4();

var app = builder.Build();

app.UseCors(c =>
{
    c.AllowAnyOrigin();
    c.AllowAnyHeader();
    c.AllowAnyMethod();
});

app.UseAppHealthChecks();
app.UseIS4();
app.Run();
