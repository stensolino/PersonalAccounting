using Microsoft.Extensions.Logging;
using PersonalAccounting.Domain.Dto;
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

        public async Task<long> CreateUserAsync(UserDto user)
        {
            try
            {
                _logger.LogInformation("Enter to UsersServices CreateUserAsync");

                var userJson = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("/api/Users", userJson);
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var userId = JsonSerializer.Deserialize<long>(responseString, _jsonSerializerOptions);
                    return userId;
                }

                throw new Exception("CreateUserAsync throw an error");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
