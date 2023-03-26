using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerStore.Context.Settings
{
    public class DbSettings
    {
        public DbType Type { get; private set; }
        public string? ConnectionString { get; private set; }
        public string? ServerType { get; private set; }
        public string? Version { get; private set; }
    }
}