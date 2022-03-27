using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace DYS.WebClient.Models.Lesson
{
    [JsonObject]
    public class TimePlaceDto : GetDto
    {
        [JsonProperty("dayOfWeek")]
        public DayOfWeek DayOfWeek { get; set; }
        [JsonProperty("startHour")]
        public string StartHour { get; set; }
        [JsonProperty("endHour")]
        public string EndHour { get; set; }
        [JsonProperty("classRoom")]
        public string ClassRoom { get; set; }
        [JsonProperty("courseId")]
        public Guid CourseId { get; set; }
    }
}
