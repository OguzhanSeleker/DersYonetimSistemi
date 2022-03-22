using System;
using System.ComponentModel.DataAnnotations;

namespace Services.Lesson.Domain.Dtos
{
    public class UpdateCourseUserDto : GetDto
    {
        [Required]
        public Guid CourseId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid RoleInCourseId { get; set; }

    }
}
