﻿using Microsoft.Extensions.Logging;
using PersonalAccounting.Domain.Entities;
using PersonalAccounting.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
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

        public async Task<List<Transaction>> GetByBudgetId(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/Budgets/{id}/Transactions");
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var budget = JsonSerializer.Deserialize<List<Transaction>>(responseString, _jsonSerializerOptions);
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
    }
}
