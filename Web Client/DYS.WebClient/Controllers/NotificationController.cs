using DYS.WebClient.Models;
using DYS.WebClient.Services;
using DYS.WebClient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Services;

namespace DYS.WebClient.Controllers
{
    public class NotificationController : BaseController
    {
        private readonly INotificationService _notificationService;
        public NotificationController(IUserService userService, ISharedIdentityService sharedIdentityService, INotificationService notificationService) : base(userService, sharedIdentityService)
        {
            _notificationService = notificationService;
        }

        public IActionResult Add(string courseId)
        {
            var model = new NotificationViewModel()
            {
                CourseId = courseId
            };
            return View(model);

        }
    }
}
