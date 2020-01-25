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
            var idToken = _httpContextAccessor.HttpContext.GetTokenAsync(Constants.IdToken).Result;

            if (!string.IsNullOrWhiteSpace(idToken))
                request.Headers.Authorization = new AuthenticationHeaderValue(
                    Constants.JwtBearerDefaultsAuthenticationScheme, idToken);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
