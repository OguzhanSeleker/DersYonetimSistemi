using DYS.WebClient.Models.Lesson;

namespace DYS.WebClient.Models
{
    public class AddUserToCourseViewModel
    {
        public QueryCourseDto Course { get; set; }
        public QueryLessonDto Lesson { get; set; }
        public SideBarViewModel SideBarViewModel { get; set; }
        public AddUserToCourseFormModel Egitmen { get; set; }
        public AddUserToCourseFormModel Asistan { get; set; }
        public AddUserToCourseFormModel Ogrenciler { get; set; }
    }
    public class AddUserToCourseFormModel
    {
        public string RoleIdInCourse { get; set; }
        public string UserNames { get; set; }
        public string CourseId { get; set; }

    }
}
