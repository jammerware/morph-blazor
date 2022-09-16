using System.Text;
using System.Text.Json;
using MorphShared.Models;

namespace MorphShared.Services
{
    public class ApiService : IApiService
    {
        private static readonly string API_ROOT = "https://morph-chinese.herokuapp.com";
        private readonly HttpClient _http;

        public ApiService(HttpClient http)
        {
            this._http = http;
        }

        public async Task<CharacterDecomposition?> GetCharacterDetails(string character) =>
            await this.GetResponseContent<CharacterDecomposition>($"character/{character}");

        public async Task<WordDecomposition> GetWordDecomposition(string query) =>
            await this.GetResponseContent<WordDecomposition>($"decomposition/{query}");

        public async Task<string[]> GetRecommendedSearchTerms() =>
            await this.GetResponseContent<string[]>("recommended-search-terms");

        public async Task<TranslationResult> translate(string[] queries) =>
            await this.PostResponseContent<TranslationResult>("translate/all", new { text = queries });

        private async Task<T> GetResponseContent<T>(string requestUri)
        {
            var response = await this._http.GetAsync($"{ApiService.API_ROOT}/{requestUri}");
            response.EnsureSuccessStatusCode();
            var jsonContent = await response.Content.ReadAsStringAsync();
            var deserialized = JsonSerializer.Deserialize<T>(jsonContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (deserialized == null)
            {
                throw new InvalidOperationException($"Deserialization of request to {requestUri} with type {nameof(T)} failed.");
            }

            return deserialized;
        }

        private async Task<T> PostResponseContent<T>(string requestUri, Object payload)
        {
            var serializedPayload = JsonSerializer.Serialize(payload);

            var response = await this._http.PostAsync($"{ApiService.API_ROOT}/{requestUri}", new StringContent(serializedPayload, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            var jsonContent = await response.Content.ReadAsStringAsync();
            var deserialized = JsonSerializer.Deserialize<T>(jsonContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (deserialized == null)
            {
                throw new InvalidOperationException($"Deserialization of request to {requestUri} with type {nameof(T)} failed.");
            }

            return deserialized;
        }
    }
}
