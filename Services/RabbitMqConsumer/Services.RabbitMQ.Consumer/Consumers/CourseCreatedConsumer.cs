using MassTransit;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Services.RabbitMQ.Consumer.Services;
using SharedLibrary.RabbitMQClasses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Services.RabbitMQ.Consumer.Consumers
{
    public class CourseCreatedConsumer : IConsumer<CourseCreated>
    {
        private readonly IConfiguration Configuration;
        private readonly BearerTokenHandler bearerTokenHandler;

        public CourseCreatedConsumer(IConfiguration configuration, BearerTokenHandler bearerTokenHandler)
        {
            Configuration = configuration;
            this.bearerTokenHandler = bearerTokenHandler;
        }

        public async Task Consume(ConsumeContext<CourseCreated> context)
        {
            HttpClient client = new HttpClient(bearerTokenHandler);
            var serviceAPISettings = Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
            
            var response = await client.PostAsJsonAsync(serviceAPISettings.AttendanceBaseUri + "api/attendances/CreateCourseInfo", new { CourseId = context.Message.CourseId, StartDate = context.Message.StartDate, EndDate = context.Message.EndDate });
            if (response.IsSuccessStatusCode)
            {
                //context.
            }
        }
    }
}
