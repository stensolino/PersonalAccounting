using Microsoft.Extensions.Logging;
using PersonalAccounting.Domain.Entities;
using PersonalAccounting.Web.Services.Interfaces;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PersonalAccounting.Web.Services
{
    public class BudgetService : BaseService, IBudgetService
    {
        private readonly ILogger<BudgetService> _logger;

        public BudgetService(ILogger<BudgetService> logger, IHttpClientFactory clientFactory)
            : base(clientFactory)
        {
            _logger = logger;
        }

        public async Task<Budget> GetBudget(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"budgets/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var budget = JsonSerializer.Deserialize<Budget>(responseString, _jsonSerializerOptions);
                    return budget;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetBudget throw an error", ex.Message);
                throw;
            }
        }
    }
}
