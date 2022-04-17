using System.ComponentModel.DataAnnotations;

namespace Services.Lesson.Domain.Dtos
{
    public class RoleInCourseDto : GetDto
    {
        [Required]
        public string RoleKey { get; set; }
        [Required]
        public string RoleName { get; set; }

    }
}
