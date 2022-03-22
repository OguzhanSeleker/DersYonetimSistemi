using Services.Lesson.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Lesson.Domain.Entities
{
    public class TimePlace : BaseEntity
    {
        public DayOfWeek DayOfWeek { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }
        public string ClassRoom { get; set; }

        [ForeignKey(nameof(Lesson))]
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
    }

}
