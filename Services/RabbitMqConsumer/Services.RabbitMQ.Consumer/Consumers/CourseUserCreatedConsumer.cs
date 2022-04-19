using MassTransit;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SharedLibrary.RabbitMQClasses;
using SharedLibrary.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Services.RabbitMQ.Consumer.Consumers
{
    public class CourseUserCreatedConsumer : IConsumer<CourseUserCreated>
    {
        private readonly IConfiguration Configuration;
        private readonly BearerTokenHandler bearerTokenHandler;

        public CourseUserCreatedConsumer(BearerTokenHandler bearerTokenHandler, IConfiguration configuration)
        {
            this.bearerTokenHandler = bearerTokenHandler;
            Configuration = configuration;
        }

        public async Task Consume(ConsumeContext<CourseUserCreated> context)
        {
            HttpClient client = new HttpClient(bearerTokenHandler);
            var serviceAPISettings = Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
            var response = await client.PostAsJsonAsync(serviceAPISettings.AttendanceBaseUri + "CreateStudentAttendance", new { CourseId = context.Message.CourseId, StudentId = context.Message.StudentId });
            var str = await response.Content.ReadAsStringAsync();
            var converted = JsonConvert.DeserializeObject<OperationResult<NoContent>>(str);

            if (!converted.Success) throw new Exception(converted.ErrorMessage);

        }
    }
}
