using System;

namespace Services.Attendance.API.Models
{
    public class CreateStudentAttendanceModel
    {
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
    }
}
