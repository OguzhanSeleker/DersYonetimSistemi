using Services.Lesson.Domain.Entities.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Lesson.Domain.Entities
{
    public class Course : BaseEntity
    {
        [ForeignKey(nameof(Lesson))]
        public Guid LessonId { get; set; }
        public string CRN { get; set; }
        public string Donem { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime LastAccessDate { get; set; }
        public virtual Lesson Lesson { get; set; }
        public virtual ICollection<TimePlace> TimePlaces { get; set; }
        public virtual ICollection<CourseUser> CourseUsers{ get; set; }
    }

}
