using Services.Lesson.Domain.Entities.Base;

namespace Services.Lesson.Domain.Entities
{
    public class RoleInCourse : BaseEntity
    {
        public const string Ogrenci = "a953a205-8343-427f-86f6-d09a5f1e659e";
        public const string Asistan = "72ab05e6-500a-4f80-8c1d-9c670d17612b";
        public const string Egitmen = "a65c19b0-b1d9-44a8-a1e6-3caef164b282";
        public string RoleKey { get; set; }
        public string RoleName { get; set; }
    }


}
