using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.RabbitMQClasses
{
    public class CourseUserCreated
    {
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
    }
}
