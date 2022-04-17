using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RabbitMQ.Consumer
{
    public class RabbitMqSettings
    {
        public string RabbitMqRootUri { get; set; }
        public string RabbitMqCourseCreatedQueue { get; set; }
        public string RabbitMqUsername { get; set; }
        public string RabbitMqPassword { get; set; }
        public string RabbitMqLessonServiceQueue { get; set; }
    }
}
