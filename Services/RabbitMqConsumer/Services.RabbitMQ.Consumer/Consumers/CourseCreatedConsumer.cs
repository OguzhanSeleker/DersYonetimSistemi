using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Services.RabbitMQ.Consumer.Models;
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
        private readonly ServiceApiSettings serviceApiSettings;

        public CourseCreatedConsumer(IConfiguration configuration, BearerTokenHandler bearerTokenHandler, IOptions<ServiceApiSettings> serviceApiSettings)
        {
            Configuration = configuration;
            this.bearerTokenHandler = bearerTokenHandler;
            this.serviceApiSettings = serviceApiSettings.Value;
        }

        public async Task Consume(ConsumeContext<CourseCreated> context)
        {
            HttpClient client = new HttpClient(bearerTokenHandler);

            var response = await client.PostAsJsonAsync(serviceApiSettings.AttendanceBaseUri + "CreateCourseInfo", new { CourseId = context.Message.CourseId, StartDate = context.Message.StartDate, EndDate = context.Message.EndDate });
            if (response.IsSuccessStatusCode)
            {
                var totalDays = (context.Message.EndDate.Date - context.Message.StartDate.Date).Days;
                var totalWeeks = totalDays / 7 + 1;
                List<AddCourseAttendanceDto> attendances = new List<AddCourseAttendanceDto>();
                for (int i = 0; i < totalWeeks; i++)
                {
                    for (int j = 0; j < context.Message.TimePlaces.Count(); j++)
                    {
                        AddCourseAttendanceDto model = new AddCourseAttendanceDto
                        {
                            CourseId = context.Message.CourseId,
                            TimePlaceId = context.Message.TimePlaces[j].Id,
                            WeeklyProgramNumber = j + 1,
                            WeekNumber = i + 1,
                        };
                        attendances.Add(model);
                    }

                }
                var attendanceResponse = await client.PostAsJsonAsync(serviceApiSettings.AttendanceBaseUri + "CreateCourseAttendanceList", attendances);
                if (!attendanceResponse.IsSuccessStatusCode)
                    throw new Exception();
            }
        }
    }
}
