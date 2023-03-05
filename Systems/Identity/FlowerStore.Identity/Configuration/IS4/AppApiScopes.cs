using Duende.IdentityServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerStore.Common.Security;

namespace FlowerStore.Identity.Configuration.IS4
{
    public static class AppApiScopes
    {
        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
        {
            new ApiScope(AppScopes.FlowersRead),
            new ApiScope (AppScopes.FlowersWrite),
        };
    }
}