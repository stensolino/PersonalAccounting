using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using PersonalAccounting.Domain;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace PersonalAccounting.Web.Handlers
{
    public class HttpClientMessageHandlers : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly HttpClient _httpClient;

        public HttpClientMessageHandlers(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var accessToken = _httpContextAccessor.HttpContext.GetTokenAsync(Constants.AccessToken).Result;
            if (!string.IsNullOrWhiteSpace(accessToken))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await base.SendAsync(request, cancellationToken);

            return response;
        }
    }
}
