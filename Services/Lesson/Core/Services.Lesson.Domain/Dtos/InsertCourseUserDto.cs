using System;
using System.ComponentModel.DataAnnotations;

namespace Services.Lesson.Domain.Dtos
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
