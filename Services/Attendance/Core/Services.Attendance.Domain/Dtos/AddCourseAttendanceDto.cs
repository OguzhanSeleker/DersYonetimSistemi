using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Attendance.Domain.Dtos
{
    public class AddCourseAttendanceDto
    {
        public Guid CourseId { get; set; }
        public Guid TimePlaceId { get; set; }
        public int WeekNumber { get; set; }
        public DateTime WeekDateTime { get; set; }
        public Guid CourseProgramInfoId { get; set; }
    }
}
