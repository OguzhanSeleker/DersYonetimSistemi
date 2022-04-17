using Services.Attendance.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Attendance.Domain.Entities
{
    public class CourseProgramInfo : BaseEntity,IAggregateRoot
    {
        public Guid CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<CourseAttendance> CourseAttendances { get; set; }
    }
}
