using System;
using System.ComponentModel.DataAnnotations;

namespace Services.Attendance.API.Models
{
    public class CreateStudentAttendanceModel
    {
        [Required]
        public Guid CourseId { get; set; }
        [Required]
        public Guid StudentId { get; set; }
    }
}
