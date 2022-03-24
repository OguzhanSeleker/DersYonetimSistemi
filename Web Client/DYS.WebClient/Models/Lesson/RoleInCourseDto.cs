using System.ComponentModel.DataAnnotations;

namespace DYS.WebClient.Models.Lesson
{
    public class RoleInCourseDto : GetDto
    {
        [Required]
        public string RoleKey { get; set; }
        [Required]
        public string RoleName { get; set; }

    }
}
