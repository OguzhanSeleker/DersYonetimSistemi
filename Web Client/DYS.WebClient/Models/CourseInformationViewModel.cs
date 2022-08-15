using DYS.WebClient.Models.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DYS.WebClient.Models
{
    public class CourseInformationViewModel
    {
        public QueryCourseDto  CourseInformation { get; set; }
        public QueryLessonDto LessonInformation { get; set; }
        public SideBarViewModel SideBarViewModel { get; set; }
        public List<QueryCourseUserDto> CourseUserList { get; set; }
    }
}
