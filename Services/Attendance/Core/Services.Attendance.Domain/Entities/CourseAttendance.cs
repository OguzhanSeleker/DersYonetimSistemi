using Services.Attendance.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Attendance.Domain.Entities
{
    public class CourseAttendance : BaseEntity, IAggregateRoot
    {
        public Guid CourseId { get; set; }
        public Guid TimePlaceId { get; set; }
        public int WeekNumber { get; set; }
        public int WeeklyProgramNumber { get; set; }

        [ForeignKey(nameof(CourseProgramInfo))]
        public Guid CourseProgramInfoId { get; set; }
        public CourseProgramInfo CourseProgramInfo { get; set; }
        public virtual ICollection<StudentAttendance> StudentAttendances { get; set; }
    }
}
