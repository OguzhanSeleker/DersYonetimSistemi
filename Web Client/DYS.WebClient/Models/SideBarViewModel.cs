using System.Collections.Generic;

namespace DYS.WebClient.Models
{
    public class SideBarViewModel
    {
        public string UserFullName { get; set; }
        public List<SideBarLessonModel> LessonModelList { get; set; }

    }
    public class SideBarLessonModel
    {
        public string LessonName { get; set; }
        public string LessonCode { get; set; }
        public List<SideBarLessonCourseModel> LessonCourseModelList { get; set; }
    }

    public class SideBarLessonCourseModel
    {
        public string CourseId { get; set; }
        public string CourseCRN { get; set; }
    }
}
