using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using FlowerStore.Context.Settings;

namespace FlowerStore.Context;

public class DesignTimeDbFactory : IDesignTimeDbContextFactory<MainDbContext>
{
    public MainDbContext CreateDbContext(string[] args)
    {
        var provider = Enum.Parse<DbType>(args?[0] ?? $"{DbType.MSSQL}");
        var configuration = new ConfigurationBuilder()
             .AddJsonFile("appsettings.context.json")
             .Build();

        var connectionString = configuration.GetConnectionString(provider.ToString()) ??
            throw new Exception("Connection string is null!");

        var optionsBuilder = new DbContextOptionsBuilder<MainDbContext>();
        DbContextOptionFactory.Configure(connectionString, provider).Invoke(optionsBuilder);

        return new MainDbContext(optionsBuilder.Options);
    }
}