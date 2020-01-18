using PersonalAccounting.Domain.Entities;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PersonalAccounting.Web.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public BudgetService(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("personal-accounting-api");
            _jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task GetBudget(int id)
        {
            var response = await _httpClient.GetAsync($"budgets/{id}");
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var budget = JsonSerializer.Deserialize<Budget>(responseString, _jsonSerializerOptions);

                    //using var responseStream = await response.Content.ReadAsStreamAsync();
                    //var users = await JsonSerializer.DeserializeAsync<UserTest>(responseStream);
                }
                catch (Exception ex)
                {

                    throw;
                }

            }
        }
    }
}
