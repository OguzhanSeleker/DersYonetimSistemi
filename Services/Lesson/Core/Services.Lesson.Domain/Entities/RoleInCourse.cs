using Services.Lesson.Domain.Entities.Base;

namespace Services.Lesson.Domain.Entities
{
    public class RoleInCourse : BaseEntity
    {
        public string RoleKey { get; set; }
        public string RoleName { get; set; }
    }

}
