using FlowerStore.Web.Models.Flower;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Text.Json;

namespace FlowerStore.Web.Services.Flower
{
    public class FlowerService : IFlowerService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;
        private string? ApiUrl => configuration["Server:ApiRoot"];

        private JsonSerializerOptions jsonSerializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public FlowerService(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
        }
        public async Task AddFlowerAsync(FlowerModel model)
        {
            var result = await httpClient.PostAsJsonAsync($"{ApiUrl}/v1/flowers", model, jsonSerializerOptions);
            if (!result.IsSuccessStatusCode)
            {
                throw new HttpRequestException(result.ReasonPhrase, null, result.StatusCode);
            }

        }

        public async Task DeleteFlowerAsync(int id)
        {
            var result = await httpClient.DeleteAsync($"{ApiUrl}/v1/flowers/{id}");
            if (!result.IsSuccessStatusCode)
            {
                throw new HttpRequestException(result.ReasonPhrase, null, result.StatusCode);
            }
        }

        public async Task<FlowersResponce?> GetAllAsync(int page = 1, int limit = 10)
        {
            var result = await httpClient.GetFromJsonAsync<FlowersResponce>(
                $"{ApiUrl}/v1/flowers?page={page}&limit={limit}", jsonSerializerOptions);

            return result;
        }

        public async Task<FlowerModel> GetByIdAsync(int id)
        {
            var result = await httpClient.GetFromJsonAsync<FlowerModel>($"{ApiUrl}/v1/flowers/{id}",
                jsonSerializerOptions) 
                ?? throw new HttpRequestException("Not found", null, System.Net.HttpStatusCode.NotFound);
            return result;
        }

        public async Task UpdateFlowerAsync(int id, FlowerModel model)
        {
            var result = await httpClient.PutAsJsonAsync($"{ApiUrl}/v1/flowers/{id}", model, jsonSerializerOptions);
            if (!result.IsSuccessStatusCode)
            {
                throw new HttpRequestException(result.ReasonPhrase, null, result.StatusCode);
            }
        }
    }
}
