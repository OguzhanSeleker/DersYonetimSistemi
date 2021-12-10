using Lesson.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.Aggregates
{
    [Table("TimeDayRooms")]
    public class TimeDayRoom : AuditEntity<int>
    {
        public DayOfWeek DayOfWeek { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }
        public int ClassRoomId { get; set; }
        public int LessonId { get; set; }

        [ForeignKey(nameof(LessonId))]
        public Lesson Lesson { get; set; }
    }
}
