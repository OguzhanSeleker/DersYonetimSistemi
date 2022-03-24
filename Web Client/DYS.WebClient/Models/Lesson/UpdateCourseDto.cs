using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DYS.WebClient.Models.Lesson
{
    public class UpdateCourseDto : GetDto
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
        [Required]
        public virtual ICollection<TimePlaceDto> TimePlaces { get; set; }
        [Required]
        public virtual ICollection<QueryCourseUserDto> CourseUsers { get; set; }
    }
}
