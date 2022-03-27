using System;
using System.ComponentModel.DataAnnotations;

namespace DYS.WebClient.Models.Lesson
{ 
    public class InsertCourseUserDto : InsertDto
    {
        [Required]
        public Guid CourseId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid RoleInCourseId { get; set; }

    }
}
