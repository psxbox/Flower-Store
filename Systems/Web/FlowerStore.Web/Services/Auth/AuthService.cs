using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using FlowerStore.Web.Providers;
using FlowerStore.Web.Models.Auth;

namespace FlowerStore.Web.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient httpClient;
        private readonly AuthenticationStateProvider authenticationStateProvider;
        private readonly ILocalStorageService localStorageService;
        private readonly IConfiguration configuration;

        public AuthService(HttpClient httpClient,
            AuthenticationStateProvider authenticationStateProvider,
            ILocalStorageService localStorageService,
            IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.authenticationStateProvider = authenticationStateProvider;
            this.localStorageService = localStorageService;
            this.configuration = configuration;
        }

        public async Task<LoginResult> Login(string userName, string password)
        {
            var url = configuration["Server:LoginPath"];
            var requestBody = new
            {
                userName,
                password
            };

            var result = new LoginResult();

            try
            {
                var requestContent = JsonContent.Create(requestBody);
                var response = await httpClient.PostAsync(url, requestContent);

                result.Success = response.IsSuccessStatusCode;
                result.Error = response.ReasonPhrase;

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    await localStorageService.SetItemAsync("Token", content);
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Error = ex.Message;
            }

            return result;
        }

        public async Task Logout()
        {
            await ((JwtAuthenticationStateProvider)authenticationStateProvider).MakeUserAnonimousAsync();
        }
    }
}
