using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.RabbitMQ.Consumer
{
    public class BearerTokenHandler : DelegatingHandler
    {
        private readonly IConfiguration _conf;
        public BearerTokenHandler(IConfiguration conf)
        {
            InnerHandler = new HttpClientHandler();
            _conf = conf;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var bearerToken = await GetToken();
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",bearerToken);
            var response = await base.SendAsync(request, cancellationToken);
            return response;
        }

        private async Task<string> GetToken()
        {
            var clientSettings = _conf.GetSection("ClientSettings").Get<ClientSettings>();
            var serviceAPISettings = _conf.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync(serviceAPISettings.IdentityBaseUri);
            if (disco.IsError)
                return null;

            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = clientSettings.ConsumerWorker.ClientId,
                ClientSecret = clientSettings.ConsumerWorker.ClientSecret
            });

            if (tokenResponse.IsError)
                return null;

            return tokenResponse.AccessToken;

        }
    }
}
