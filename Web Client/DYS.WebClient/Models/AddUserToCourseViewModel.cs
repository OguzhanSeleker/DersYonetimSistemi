using DYS.WebClient.Models.Lesson;
using System.Collections.Generic;

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
        public List<UserInCourse> UserList { get; set; }
    }
    public class AddUserToCourseFormModel
    {
        public string RoleIdInCourse { get; set; }
        public string UserNames { get; set; }
        public string CourseId { get; set; }

    }
    public class UserInCourse
    {
        public string CourseUserId { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string RoleIdInCourse { get; set; }
        public string RoleNameInCourse { get; set; }
    }

}
