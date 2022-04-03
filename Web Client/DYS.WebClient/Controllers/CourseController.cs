using DYS.WebClient.Filters;
using DYS.WebClient.Models;
using DYS.WebClient.Models.Lesson;
using DYS.WebClient.Models.Notification;
using DYS.WebClient.Services;
using DYS.WebClient.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharedLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DYS.WebClient.Controllers
{
    [Authorize]
    public class CourseController : BaseController
    {
        private ILessonService _lessonService;
        private readonly INotificationService _notificationService;
        private readonly ILogger<CourseController> _logger;
        public CourseController(IUserService userService, ISharedIdentityService sharedIdentityService, ILessonService lessonService, INotificationService notificationService, ILogger<CourseController> logger) : base(userService, sharedIdentityService)
        {
            _lessonService = lessonService;
            _notificationService = notificationService;
            _logger = logger;
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> Add()
        {
            var model = new CourseAddViewModel()
            {
                LessonList = await _lessonService.GetLessonList(),
                SideBarViewModel = await GetSideBarInfo(_lessonService)
            };
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> Add(CourseAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.LessonList = await _lessonService.GetLessonList();
                model.SideBarViewModel = await GetSideBarInfo(_lessonService);
                return View(model);
            }
            var times = model.InsertCourse.CourseTimeFormModels != null ? model.InsertCourse.CourseTimeFormModels.ToList() : null;
            InsertCourseDto courseDto = new InsertCourseDto
            {
                CreatedBy = Guid.Parse(_sharedIdentityService.GetUserId),
                CRN = model.InsertCourse.CRN,
                Donem = model.InsertCourse.Donem,
                EndDate = model.InsertCourse.EndDate,
                LastAccessDate = model.InsertCourse.LastAccessDate,
                StartDate = model.InsertCourse.StartDate,
                LessonId = model.InsertCourse.LessonId,
                TimePlaces = times,
                //Teacher = new InsertCourseUserDto { RoleInCourseId = Guid.Parse(UserViewModel.TeacherRole), UserId=model.InsertCourse.Teacher.UserId},
            };
            var entity = await _lessonService.InsertCourse(courseDto);
            if (entity != null)
            {
                var teacherAdd = _lessonService.InsertCourseUser(new InsertCourseUserDto { RoleInCourseId = Guid.Parse(RoleInCourse.Egitmen), UserId = model.InsertCourse.Teacher.UserId, CourseId = entity.Id, CreatedBy = Guid.Parse(_sharedIdentityService.GetUserId) });

                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Add", "Course");

        }

        [HttpGet]
        [Route("Course/{id}")]
        [ServiceFilter(typeof(ParameterFilterAttribute), Order = 1)]
        //[IsUserInCourseFilter(_lessonService,_sharedIdentityService,Order = 2)]
        public async Task<IActionResult> Detail(string id)
        {
            QueryCourseDto course = await _lessonService.GetCourseById(id);

            if (course == null)
                return NotFound();
            QueryLessonDto lesson = await _lessonService.GetLessonByCourseId(id);
            List<GetNotificationDto> notifList = await _notificationService.GetNotificationListByCourseIdAsync(id);
            List<NotificationViewModel> notificationList = new List<NotificationViewModel>();
            if (notifList != null && notifList.Count > 0)
            {
                foreach (var notif in notifList.OrderByDescending(i => i.CreatedDate).Take(5))
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
            var model = new CourseDetailViewModel()
            {
                Course = course,
                Lesson = lesson,
                NotificationList = notificationList,
                SideBarViewModel = await GetSideBarInfo(_lessonService)
            };
            return View(model);
        }

        [HttpGet]
        [Route("Course/{courseId}/Notifications")]
        [ServiceFilter(typeof(ParameterFilterAttribute),Order =1)]
        public async Task<IActionResult> CourseNotificationList(string courseId)
        {
            var course = await _lessonService.GetCourseById(courseId);
            if (course == null) return NotFound();
            var lesson = await _lessonService.GetLessonByCourseId(courseId);
            var notifListInCourse = await _notificationService.GetNotificationListByCourseIdAsync(courseId);

            var model = new NotificationListViewModel
            {
                Course = course,
                Lesson = lesson,
                NotificationList = notifListInCourse.Select(i => new NotificationViewModel { CourseId = i.CourseId.ToString(), CourseName = lesson.NameTR, CreatedDate = i.CreatedDate, Deleted = i.Deleted, Description = i.Description, Id = i.Id, Priority = i.Priority, Title = i.Title, UpdatedDate = i.UpdatedDate, WriterFullname = _userService.GetUserById(i.WriterId.ToString()).Result.FullName, WriterId = i.WriterId.ToString() }).ToList(),
                SideBarViewModel = await GetSideBarInfo(_lessonService),
            };
            return View(model);
        }
    }
}
