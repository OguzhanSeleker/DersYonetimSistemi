using DYS.WebClient.Models.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DYS.WebClient.Models
{
    public class FileOperationViewModel
    {
        public QueryCourseDto Course { get; set; }
        public QueryLessonDto Lesson { get; set; }
        public FileOperationModel FileOperationModel { get; set; }
        public SideBarViewModel SideBarViewModel { get; set; }
    }
}
