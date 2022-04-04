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
    public class LessonController : BaseController
    {
        private readonly ILessonService _lessonService;
        private readonly INotificationService _notificationService;
        private readonly ILogger<LessonController> _logger;

        public LessonController(IUserService userService, ISharedIdentityService sharedIdentityService, ILessonService lessonService, ILogger<LessonController> logger, INotificationService notificationService) : base(userService, sharedIdentityService)
        {
            _lessonService = lessonService;
            _logger = logger;
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var sideBarModel = await GetSideBarInfo(_lessonService);
            var courseList = await _lessonService.GetCourseListByUserId(_sharedIdentityService.GetUserId);
            List<GetNotificationDto> notiflist = new List<GetNotificationDto>();
            if (courseList != null)
            {
                var test = await _notificationService.GetLastFiveNotificationUserCourseByCourseIdList(string.Join(',', courseList.Select(i => i.Id.ToString())));
                if (test != null)
                    notiflist.AddRange(test);
            }
            var model = new LessonIndexViewModel
            {
                SideBarViewModel = sideBarModel,
                SigninInput = new SigninInput(),
                IndexNotificationList = notiflist.Count > 0 ? notiflist.Select(i => new NotificationViewModel
                {
                    Id = i.Id,
                    CourseId = i.CourseId.ToString(),
                    Description = i.Description,
                    Title = i.Title,
                    Priority = i.Priority,
                    WriterFullname = (_userService.GetUserById(i.WriterId.ToString()).Result.FullName),
                    WriterId = i.WriterId.ToString(),
                    CourseName = _lessonService.GetLessonByCourseId(i.CourseId.ToString()).Result.NameTR,
                    CreatedDate = i.CreatedDate
                }).ToList() : null
            };
            return View(model);

        }

        [HttpGet]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> Add()
        {
            var model = new LessonAddViewModel()
            {

                SideBarViewModel = await GetSideBarInfo(_lessonService)
            };
            return View(model);

        }
        public async Task<IActionResult> Add(LessonAddViewModel model)
        {
            if (model.AddFormModel == null)
                return View(model);
            var insertLessonDto = new InsertLessonDto()
            {
                NameTR = model.AddFormModel.NameTR,
                NameEn = model.AddFormModel.NameEn,
                Code = model.AddFormModel.Code,
                CoordinatorFullName = model.AddFormModel.CoordinatorFullName,
                CoordinatorId = model.AddFormModel.CoordinatorId,
                Credit = model.AddFormModel.Credit,
                Descriptions = model.AddFormModel.Descriptions,
                Goals = model.AddFormModel.Goals,
                Language = model.AddFormModel.Language,
                OtherInformations = model.AddFormModel.OtherInformations,
                TermNumber = model.AddFormModel.TermNumber,


            };
            model.AddFormModel.CreatedBy = Guid.Parse(_sharedIdentityService.GetUserId);
            model.AddFormModel.CreatedDate = DateTime.UtcNow;

            var insertedLesson = await _lessonService.InsertLesson(model.AddFormModel);
            if (insertedLesson != null)
                return RedirectToAction("Add", "Lesson");
            return View(model);
        }
    }
}
