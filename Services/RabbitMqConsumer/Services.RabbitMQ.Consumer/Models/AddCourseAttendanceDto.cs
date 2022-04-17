using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RabbitMQ.Consumer.Models
{
    public class AddCourseAttendanceDto
    {
        public Guid CourseId { get; set; }
        public Guid TimePlaceId { get; set; }
        public int WeekNumber { get; set; }
        public int WeeklyProgramNumber { get; set; }
        public Guid CourseProgramInfoId { get; set; }
    }
}
