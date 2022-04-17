using DYS.WebClient.Models.Lesson;
using DYS.WebClient.Models.Notification;
using System.Collections.Generic;

namespace DYS.WebClient.Models
{
    public class CourseDetailViewModel
    {
        public QueryCourseDto Course { get; set; }
        public QueryLessonDto Lesson { get; set; }
        public List<NotificationViewModel> NotificationList { get; set; }
        public SideBarViewModel SideBarViewModel { get; set; }
        public NotificationViewModel FormModel { get; set; }
        //public  MyProperty { get; set; }
    }
}
