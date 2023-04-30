using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlowerStore.Context.Settings;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace FlowerStore.Context;

public static class DbContextOptionFactory
{
    private const string migrationProjctPrefix = "FlowerStore.Context.Migrations";

    public static Action<DbContextOptionsBuilder> Configure(string connectionString, DbType dbType,
        string? serverType = null, string? serverVersion = null)
    {
        return (options) =>
        {
            switch (dbType)
            {
                case DbType.MSSQL:
                    options.UseSqlServer(connectionString, o => o
                        .MigrationsAssembly($"{migrationProjctPrefix}.{dbType}"));
                    break;
                case DbType.PostgreSQL:
                    options.UseNpgsql(connectionString, o => o
                        .MigrationsAssembly($"{migrationProjctPrefix}.{dbType}"));
                    break;
                case DbType.SQLite:
                    options.UseSqlite(connectionString, o => o
                        .MigrationsAssembly($"{migrationProjctPrefix}.{dbType}"));
                    break;
                case DbType.MySQL:
                    options.UseMySql(connectionString, 
                        ServerVersion.Parse(serverVersion ?? "8.0", Enum.Parse<ServerType>(serverType ?? "MySQL", true)), 
                        o => o.MigrationsAssembly($"{migrationProjctPrefix}.{dbType}"));
                    break;
                default:
                    throw new Exception($"Unkown db type! {dbType}");
            }
            options
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
                .UseLazyLoadingProxies();
        };
    }
}