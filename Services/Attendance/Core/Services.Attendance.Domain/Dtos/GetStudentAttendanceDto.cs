using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Attendance.Domain.Dtos
{
    public class GetStudentAttendanceDto
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid CourseAttendanceId { get; set; }
        public bool IsMarked { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
