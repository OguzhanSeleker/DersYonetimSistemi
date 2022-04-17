using DYS.WebClient.Models.Lesson;
using System.Collections.Generic;

namespace DYS.WebClient.Models
{
    public class NotificationListViewModel
    {
        public QueryCourseDto Course { get; set; }
        public QueryLessonDto Lesson { get; set; }
        public List<NotificationViewModel> NotificationList { get; set; }
        public SideBarViewModel SideBarViewModel { get; set; }
        //public NotificationViewModel FormModel { get; set; }
    }
}
