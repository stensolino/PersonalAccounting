using Microsoft.Extensions.Logging;
using PersonalAccounting.Domain.Entities;
using PersonalAccounting.Web.Services.Interfaces;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PersonalAccounting.Web.Services
{
    public class UsersServices : BaseService, IUsersServices
    {
        private readonly ILogger<UsersServices> _logger;

        public UsersServices(ILogger<UsersServices> logger, IHttpClientFactory clientFactory)
            : base(clientFactory)
        {
            _logger = logger;
        }

        public async Task CreateUserAsync(User user)
        {
            try
            {
                var userJson = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"/api/Users", userJson);
                if (response.IsSuccessStatusCode)
                {
                }
                // TODO Handle error
            }
            catch (Exception ex)
            {
                _logger.LogError("CreateUserAsync throw an error", ex.Message);
                throw;
            }
        }
    }
}
