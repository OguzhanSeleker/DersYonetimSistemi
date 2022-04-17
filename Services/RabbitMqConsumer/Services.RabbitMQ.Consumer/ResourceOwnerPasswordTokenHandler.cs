
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Services.RabbitMQ.Consumer.Services;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Services.RabbitMQ.Consumer
{

    public class ResourceOwnerPasswordTokenHandler : DelegatingHandler
    {
        private readonly IIdentityService _identityService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<ResourceOwnerPasswordTokenHandler> _logger;

        public ResourceOwnerPasswordTokenHandler(IIdentityService identityService, IHttpContextAccessor httpContextAccessor, ILogger<ResourceOwnerPasswordTokenHandler> logger)
        {
            _identityService = identityService;
            _identityService.SignInForWorker();
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            var response = await base.SendAsync(request, cancellationToken);
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                var tokenResponse = await _identityService.GetAccessTokenByRefreshToken();
                if (tokenResponse != null)
                {
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);
                    response = await base.SendAsync(request, cancellationToken);

                }
            }

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                response.StatusCode = System.Net.HttpStatusCode.Unauthorized;

            }
            return response;
        }

    }
}
