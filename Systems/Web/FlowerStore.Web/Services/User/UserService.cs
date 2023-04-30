using FlowerStore.Common.Exceptions;
using FlowerStore.Web.Models.Auth;
using FlowerStore.Web.Models.User;

namespace FlowerStore.Web.Services.User
{
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;
        private string? ApiUrl => configuration["Server:ApiRoot"];

        public UserService(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
        }

        public async Task ChangePasswordAsync(ChangePasswordRequest changePasswordRequest)
        {
            var result = await httpClient.PatchAsJsonAsync($"{ApiUrl}/v1/accounts/password/change", changePasswordRequest);
            if (!result.IsSuccessStatusCode)
                if (!result.IsSuccessStatusCode)
                {
                    var msg = await result.Content.ReadAsStringAsync();
                    throw new HttpRequestException(result.ReasonPhrase, new Exception(msg), result.StatusCode);
                }
        }

        public async Task<IEnumerable<UserModel>?> GetAllAsync()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<UserModel>>($"{ApiUrl}/v1/accounts");
            return result;
        }

        public async Task<UserModel?> GetByIdAsync(Guid id)
        {
            var result = await httpClient.GetFromJsonAsync<UserModel>($"{ApiUrl}/v1/accounts/{id}");
            return result;
        }

        public async Task<IEnumerable<string>?> GetRoleTypesAsync()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<string>>($"{ApiUrl}/v1/accounts/roles/types");
            return result;
        }

        public async Task SetPasswordAsync(Guid userId, PasswordRequest passwordRequest)
        {
            var result = await httpClient.PatchAsJsonAsync($"{ApiUrl}/v1/accounts/{userId}/password/set", passwordRequest);
            if (!result.IsSuccessStatusCode)
                if (!result.IsSuccessStatusCode)
                {
                    var msg = await result.Content.ReadAsStringAsync();
                    throw new HttpRequestException(result.ReasonPhrase, new Exception(msg), result.StatusCode);
                }
        }

        public async Task SetRolesAsync(Guid userId, string roles)
        {
            var result = await httpClient.PatchAsync($"{ApiUrl}/v1/accounts/{userId}/roles?roles={roles}", null);
            if (!result.IsSuccessStatusCode)
                if (!result.IsSuccessStatusCode)
                {
                    var msg = await result.Content.ReadAsStringAsync();
                    throw new HttpRequestException(result.ReasonPhrase, new Exception(msg), result.StatusCode);
                }
        }

        public async Task UpdateUserAsync(Guid userId, UserModel user)
        {
            var result = await httpClient.PostAsJsonAsync($"{ApiUrl}/v1/accounts/update/{userId}", user);
            if (!result.IsSuccessStatusCode)
            {
                var msg = await result.Content.ReadAsStringAsync();
                throw new HttpRequestException(result.ReasonPhrase, new Exception(msg), result.StatusCode);
            }
        }

        public async Task<bool> RegisterAsync(RegisterUserModel model)
        {
            var result = await httpClient.PostAsJsonAsync($"{ApiUrl}/v1/accounts", model);
            if (result.IsSuccessStatusCode)
                return true;

            var msg = await result.Content.ReadAsStringAsync();
            throw new HttpRequestException(result.ReasonPhrase, new Exception(msg), result.StatusCode);
        }
    }
}
