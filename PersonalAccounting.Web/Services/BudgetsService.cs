using Microsoft.Extensions.Logging;
using PersonalAccounting.Domain.Dto;
using PersonalAccounting.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PersonalAccounting.Web.Services
{
    public class BudgetsService : BaseService, IBudgetsService
    {
        private readonly ILogger<BudgetsService> _logger;

        public BudgetsService(ILogger<BudgetsService> logger, IHttpClientFactory clientFactory)
            : base(clientFactory)
        {
            _logger = logger;
        }

        public async Task<List<BudgetDto>> GetBudgetsByUserId()
        {
            try
            {
                _logger.LogInformation("Enter to BudgetsService GetBudgetsByUserId");

                var response = await _httpClient.GetAsync($"budgets");
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var budgets = JsonSerializer.Deserialize<List<BudgetDto>>(responseString, _jsonSerializerOptions);
                    return budgets;
                }

                // TODO Handle error
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetBudgetsByUserId throw an error", ex.Message);
                throw;
            }
        }

        public async Task<BudgetDto> GetBudget(int id)
        {
            _logger.LogInformation("Enter to BudgetsService GetBudget");

            try
            {
                var response = await _httpClient.GetAsync($"budgets/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var budget = JsonSerializer.Deserialize<BudgetDto>(responseString, _jsonSerializerOptions);
                    return budget;
                }

                // TODO Handle error
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetBudget throw an error", ex.Message);
                throw;
            }
        }

        public async Task InsertBudget(BudgetDto budget)
        {
            try
            {
                _logger.LogInformation("Enter to TranasctionsService InsertBudget");

                var budgetJson = new StringContent(JsonSerializer.Serialize(budget), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"/api/Budgets", budgetJson);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error on inserting Budget");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
