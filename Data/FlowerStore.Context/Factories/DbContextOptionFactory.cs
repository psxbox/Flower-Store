using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlowerStore.Context.Settings;

namespace FlowerStore.Context;

public static class DbContextOptionFactory
{
    public static Action<DbContextOptionsBuilder> Configure(string connectionString, DbType dbType)
    {
        return (options) =>
        {
            switch (dbType)
            {
                case DbType.MSSQL:
                    options.UseSqlServer(connectionString);
                    break;
                case DbType.PostgreSQL:
                    options.UseNpgsql(connectionString);
                    break;
                case DbType.SQLite:
                    options.UseSqlite(connectionString);
                    break;
                case DbType.MySQL:
                    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                    break;
                default:
                    throw new Exception($"Unkown db type! {dbType}");
            }
            options
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        };
    }
}