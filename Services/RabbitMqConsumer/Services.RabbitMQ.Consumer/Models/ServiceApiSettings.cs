using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RabbitMQ.Consumer
{
    public class ServiceApiSettings
    {
        public string IdentityBaseUri { get; set; }
        public string GatewayBaseUri { get; set; }
        public string LessonBaseUri { get; set; }
        public string AttendanceBaseUri { get; set; }
    }
}
