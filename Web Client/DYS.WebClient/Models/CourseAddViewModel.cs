using DYS.WebClient.Models.Lesson;
using System.Collections;
using System.Collections.Generic;

namespace DYS.WebClient.Models
{
    public class CourseAddViewModel
    {
        public SideBarViewModel SideBarViewModel { get; set; }
        public IEnumerable<QueryLessonDto> LessonList { get; set; }
        public CourseAddFormModel InsertCourse { get; set; }
    }
}
