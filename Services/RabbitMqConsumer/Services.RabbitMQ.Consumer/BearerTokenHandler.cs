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
        private readonly string _bearerToken;
        public BearerTokenHandler(string bearerToken)
        {
            _bearerToken = bearerToken;
            InnerHandler = new HttpClientHandler();
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string[] splittedToken = _bearerToken.Split(" ");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(splittedToken[0],splittedToken[1]);
            var response = base.SendAsync(request, cancellationToken);
            return response;
        }
    }
}
