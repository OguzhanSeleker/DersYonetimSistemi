using Services.Lesson.Domain.Entities.Base;

namespace Services.Lesson.Domain.Entities
{
    public class RoleInCourse : BaseEntity
    {
        public const string Ogrenci = "";
        public string RoleKey { get; set; }
        public string RoleName { get; set; }
    }


}
