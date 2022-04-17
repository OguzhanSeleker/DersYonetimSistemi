using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Attendance.Domain.Dtos
{
    public class GetCourseProgramInfoDto
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<GetCourseAttendanceDto> CourseAttendances { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
