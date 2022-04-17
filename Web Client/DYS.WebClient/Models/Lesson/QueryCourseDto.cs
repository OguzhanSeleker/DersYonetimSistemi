using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DYS.WebClient.Models.Lesson
{ 
    //[JsonObject]
    public class QueryCourseDto : GetDto
    {
        public Guid LessonId { get; set; }
        public string CRN { get; set; }
        public string Donem { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime LastAccessDate { get; set; }
        public virtual IEnumerable<TimePlaceDto> TimePlaces { get; set; }
    }
}
