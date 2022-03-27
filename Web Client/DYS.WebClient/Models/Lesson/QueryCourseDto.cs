using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DYS.WebClient.Models.Lesson
{ 
    [JsonObject]
    public class QueryCourseDto : GetDto
    {
        [JsonProperty("lessonId")]
        public Guid LessonId { get; set; }
        [JsonProperty("cRN")]
        public string CRN { get; set; }
        [JsonProperty("donem")]
        public string Donem { get; set; }
        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }
        [JsonProperty("endDate")]
        public DateTime EndDate { get; set; }
        [JsonProperty("lastAccessDate")]
        public DateTime LastAccessDate { get; set; }
        [JsonProperty("timePlaces")]
        public virtual ICollection<TimePlaceDto> TimePlaces { get; set; }
    }
}
