using System;
using System.Collections.Generic;

namespace Services.Lesson.Domain.Dtos
{
    public class QueryCourseDto : GetDto
    {
        public Guid LessonId { get; set; }
        public string CRN { get; set; }
        public string Donem { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime LastAccessDate { get; set; }
        public virtual ICollection<TimePlaceDto> TimePlaces { get; set; }
    }
}
