using System.Collections.Generic;

namespace DYS.WebClient.Models
{
    public class LessonIndexViewModel
    {
        public SideBarViewModel SideBarViewModel { get; set; }
        public SigninInput SigninInput { get; set; }
        public List<NotificationViewModel> IndexNotificationList { get; set; }
    }
}
