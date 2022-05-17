using DYS.WebClient.Models;
using DYS.WebClient.Models.Lesson;
using DYS.WebClient.Models.Notification;
using DYS.WebClient.Services;
using DYS.WebClient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SharedLibrary.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DYS.WebClient.Controllers
{
    public class NotificationController : BaseController
    {
        private readonly INotificationService _notificationService;
        private readonly ILessonService _lessonService;
        private readonly ILogger<NotificationController> _logger;
        public NotificationController(IUserService userService, ISharedIdentityService sharedIdentityService, INotificationService notificationService, ILessonService lessonService, ILogger<NotificationController> logger) : base(userService, sharedIdentityService)
        {
            _notificationService = notificationService;
            _lessonService = lessonService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Add(string courseId)
        {
            QueryCourseDto course = await _lessonService.GetCourseById(courseId);

            if (course == null)
                return NotFound();
            QueryLessonDto lesson = await _lessonService.GetLessonByCourseId(courseId);
            List<GetNotificationDto> notifList = await _notificationService.GetNotificationListByCourseIdAsync(courseId);
            List<NotificationViewModel> notificationList = new List<NotificationViewModel>();
            if (notifList != null && notifList.Count > 0)
            {
                foreach (var notif in notifList)
                {
                    var notification = new NotificationViewModel()
                    {
                        CreatedDate = notif.CreatedDate,
                        Deleted = notif.Deleted,
                        Description = notif.Description,
                        Id = notif.Id,
                        CourseId = notif.CourseId.ToString(),
                        Priority = notif.Priority,
                        Title = notif.Title,
                        UpdatedDate = notif.UpdatedDate,
                        WriterId = notif.WriterId.ToString(),
                        CourseName = lesson.NameEn,
                        WriterFullname = (await _userService.GetUserById(notif.WriterId.ToString())).FullName,
                    };
                    notificationList.Add(notification);
                }

            }
            var formModel = new NotificationViewModel()
            {
                CourseId = courseId,
                WriterId = _sharedIdentityService.GetUserId,
            };
            var model = new CourseDetailViewModel()
            {
                Course = course,
                Lesson = lesson,
                NotificationList = notificationList,
                SideBarViewModel = await GetSideBarInfo(_lessonService),
                FormModel = formModel
            };

            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> Add(CourseDetailViewModel model)
        {
            //throw new Exception(JsonConvert.SerializeObject(model));
            if (!ModelState.IsValid)
                return RedirectToAction("Add", "Notification",new { courseId=model.FormModel.CourseId });
            var addnotif = new AddNotificationDto
            {
                CourseId = Guid.Parse(model.FormModel.CourseId),
                Description = model.FormModel.Description,
                Title = model.FormModel.Title,
                Priority = model.FormModel.Priority,
                WriterId = Guid.Parse(model.FormModel.WriterId)
            };
            var addedNotif = await _notificationService.AddNotificationAsync(addnotif);
            return RedirectToAction("Detail", "Course", new { id = model.FormModel.CourseId });
        }
    }
}
