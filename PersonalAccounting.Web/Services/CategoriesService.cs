using Microsoft.Extensions.Logging;
using PersonalAccounting.Domain.Dto;
using PersonalAccounting.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PersonalAccounting.Web.Services
{
    public class CategoriesService : BaseService, ICategoriesService
    {
        private readonly ILogger<CategoriesService> _logger;

        public CategoriesService(ILogger<CategoriesService> logger, IHttpClientFactory clientFactory)
            : base(clientFactory)
        {
            _logger = logger;
        }

        public async Task<List<CategoryDto>> GetCategories(int budgetId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/Budgets/{budgetId}/Categories");
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var categories = JsonSerializer.Deserialize<List<CategoryDto>>(responseString, _jsonSerializerOptions);
                    return categories;
                }

                // TODO Handle error
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetCategories throw an error", ex.Message);
                throw;
            }
        }
    }
}
