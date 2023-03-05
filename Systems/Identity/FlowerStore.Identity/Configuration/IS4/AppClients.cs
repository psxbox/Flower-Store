using Duende.IdentityServer.Models;
using FlowerStore.Common.Security;

namespace FlowerStore.Identity.Configuration.IS4;

public static class AppClients
{
    public static IEnumerable<Client> Clients => new List<Client>
    {
        new Client
        {
            ClientId = "swagger",
            ClientSecrets =
            {
                new Secret("secret".Sha256())
            },

            AllowedGrantTypes = GrantTypes.ClientCredentials,
            AccessTokenLifetime = 3600,
            AllowedScopes =
            {
                AppScopes.FlowersRead,
                AppScopes.FlowersWrite,
            }
        },
        new Client
        {
            ClientId = "frontend",
            ClientSecrets =
            {
                new Secret("secret".Sha256())
            },
            AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,
            AllowOfflineAccess = true,
            AccessTokenLifetime = 3600,
            AccessTokenType = AccessTokenType.Jwt,
            RefreshTokenUsage = TokenUsage.OneTimeOnly,
            RefreshTokenExpiration = TokenExpiration.Sliding,
            AbsoluteRefreshTokenLifetime = 2592000,
            SlidingRefreshTokenLifetime = 1296000,

            AllowedScopes =
            {
                AppScopes.FlowersRead,
                AppScopes.FlowersWrite,
            }
        }
    };
}
