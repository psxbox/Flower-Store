using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace FlowerStore.Web.Providers
{
    public class JwtAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient httpClient;
        private readonly ILocalStorageService localStorageService;

        public JwtAuthenticationStateProvider(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            this.httpClient = httpClient;
            this.localStorageService = localStorageService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            var content = await localStorageService.GetItemAsync<string>("Token");
            if (content == null) { return CreteAnonimous(); }

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(content);
            var validTo = token?.ValidTo;

            if (token == null || validTo == null || validTo < DateTime.UtcNow)
                return CreteAnonimous();

            var identity = new ClaimsIdentity(token.Claims, "bearer", ClaimTypes.NameIdentifier, ClaimTypes.Role);
            var user = new ClaimsPrincipal(identity);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", content);

            return new AuthenticationState(user);
        }

        static AuthenticationState CreteAnonimous()
        {
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            return new AuthenticationState(user);
        }

        public async Task MakeUserAnonimousAsync()
        {
            await localStorageService.RemoveItemAsync("Token");
            NotifyAuthenticationStateChanged(Task.FromResult(CreteAnonimous()));
        }
    }
}
