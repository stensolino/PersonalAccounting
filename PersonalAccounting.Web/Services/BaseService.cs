using PersonalAccounting.Domain;
using PersonalAccounting.Web.Services.Interfaces;
using System.Net.Http;
using System.Text.Json;

namespace PersonalAccounting.Web.Services
{
    public class BaseService// : IBaseService
    {
        protected readonly HttpClient _httpClient;
        protected readonly JsonSerializerOptions _jsonSerializerOptions;

        public BaseService(IHttpClientFactory clientFactory)
        {
            _jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _httpClient = clientFactory.CreateClient(Constants.PersonalAccountingApi);
        }
    }
}
