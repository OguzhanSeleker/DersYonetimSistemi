using Lesson.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.Aggregates
{
    [Table("Lessons")]
    public class Lesson : AuditEntity<int>
    {
        public Lesson()
        {

        }
        public int LessonCodeId { get; set; }
        public string LessonName { get; set; }
        public string LessonCRN { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime LastAccessDate { get; set; }

        public ICollection<TimeDayRoom> TimeDayRooms { get; set; }
        public ICollection<LessonLecturer> LessonLecturers { get; set; }
        public ICollection<LessonAssistant> LessonAssistants { get; set; }
        public ICollection<LessonStudent> LessonStudents { get; set; }

        //Virtuals
        [ForeignKey(nameof(LessonCodeId))]
        public virtual LessonCode LessonCode { get; set; }

    }
}
