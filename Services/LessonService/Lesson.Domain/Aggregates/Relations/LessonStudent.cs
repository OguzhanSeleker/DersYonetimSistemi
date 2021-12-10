using Lesson.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.Aggregates
{
    [Table("LessonStudents")]
    public class LessonStudent : AuditEntity<int>
    {
        public int LessonId { get; set; }
        public int StudentId { get; set; }

        [ForeignKey(nameof(LessonId))]
        public Lesson Lesson { get; set; }
    }
}
