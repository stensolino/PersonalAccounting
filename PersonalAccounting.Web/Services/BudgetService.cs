using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PersonalAccounting.Web.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly HttpClient _httpClient;

        public BudgetService(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("personal-accounting-api");
        }

        public async Task GetBudget(int id)
        {
            // Example
            var response = await _httpClient.GetAsync("users");
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var users = await System.Text.Json.JsonSerializer.DeserializeAsync<UserTest>(responseStream);
            }
        }
    }

    public class UserTest
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }
        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }
        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}
