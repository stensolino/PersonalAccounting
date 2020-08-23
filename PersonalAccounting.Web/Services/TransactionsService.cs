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
    public class TransactionsService : BaseService, ITransactionsService
    {
        private readonly ILogger<TransactionsService> _logger;

        public TransactionsService(ILogger<TransactionsService> logger, IHttpClientFactory clientFactory)
            : base(clientFactory)
        {
            _logger = logger;
        }

        public async Task<List<TransactionDto>> GetTransactionsByBudgetId(int id)
        {
            try
            {
                _logger.LogInformation("Enter to TranasctionsService GetTransactionsByBudgetId");

                var response = await _httpClient.GetAsync($"Budgets/{id}/Transactions");
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var budget = JsonSerializer.Deserialize<List<TransactionDto>>(responseString, _jsonSerializerOptions);
                    return budget;
                }

                // TODO Handle error
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetByBudgetId throw an error", ex.Message);
                throw;
            }
        }

        public async Task InsertTransaction(TransactionDto transaction)
        {
            try
            {
                _logger.LogInformation("Enter to TranasctionsService InsertTransaction");

                var transactionJson = new StringContent(JsonSerializer.Serialize(transaction), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"/api/Transactions", transactionJson);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error on saving data");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("GetByBudgetId throw an error", ex.Message);
                throw new Exception("Some Error occure");
            }
        }
    }
}
