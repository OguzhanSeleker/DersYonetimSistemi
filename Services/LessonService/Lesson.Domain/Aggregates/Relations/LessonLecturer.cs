using Lesson.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.Aggregates
{
    [Table("LessonLecturers")]
    public class LessonLecturer : AuditEntity<int>
    {
        public int LessonId { get; set; }
        public int LecturerId { get; set; }
        public string LecturerFullName { get; set; }

        [ForeignKey(nameof(LessonId))]
        public Lesson Lesson { get; set; }
    }
}
