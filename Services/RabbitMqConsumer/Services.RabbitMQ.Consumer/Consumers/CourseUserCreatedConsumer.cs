using MassTransit;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.RabbitMQ.Consumer.Consumers
{
    public class CourseUserCreatedConsumer : IConsumer<CourseUserCreatedConsumer>
    {
        private readonly IConfiguration Configuration;
        private readonly BearerTokenHandler bearerTokenHandler;

        public CourseUserCreatedConsumer(BearerTokenHandler bearerTokenHandler, IConfiguration configuration)
        {
            this.bearerTokenHandler = bearerTokenHandler;
            Configuration = configuration;
        }

        public Task Consume(ConsumeContext<CourseUserCreatedConsumer> context)
        {
            HttpClient client = new HttpClient(bearerTokenHandler);
            var serviceAPISettings = Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        }
    }
}
