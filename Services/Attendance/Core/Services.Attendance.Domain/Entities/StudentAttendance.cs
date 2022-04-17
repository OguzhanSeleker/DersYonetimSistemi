using Services.Attendance.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Attendance.Domain.Entities
{
    public class StudentAttendance : BaseEntity, IAggregateRoot
    {
        public Guid StudentId { get; set; }
        [ForeignKey(nameof(CourseAttendance))]
        public Guid CourseAttendanceId { get; set; }
        public bool IsMarked { get; set; }
        public CourseAttendance CourseAttendance { get; set; }
    }
}
