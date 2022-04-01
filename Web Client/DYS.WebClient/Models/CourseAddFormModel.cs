using DYS.WebClient.Models.Lesson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DYS.WebClient.Models
{
    public class CourseAddFormModel
    {
        [Required]
        public Guid LessonId { get; set; }
        [Required]
        public string CRN { get; set; }
        [Required]
        public string Donem { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public DateTime LastAccessDate { get; set; }
        public InsertCourseUserDto Teacher { get; set; }
        public List<CourseTimeFormModel> CourseTimeFormModels { get; set; }
    }
    public class CourseTimeFormModel
    {
        public DayOfWeek Gun { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }

}
