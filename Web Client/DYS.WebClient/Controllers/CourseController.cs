using DYS.WebClient.Models;
using DYS.WebClient.Models.Lesson;
using DYS.WebClient.Services;
using DYS.WebClient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DYS.WebClient.Controllers
{
    public class CourseController : BaseController
    {
        private readonly ILessonService _lessonService;
        public CourseController(IUserService userService, ISharedIdentityService sharedIdentityService, ILessonService lessonService) : base(userService, sharedIdentityService)
        {
            _lessonService = lessonService;
        }
        [HttpGet]
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
        public async Task<IActionResult> Add(CourseAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.LessonList = await _lessonService.GetLessonList();
                model.SideBarViewModel = await GetSideBarInfo(_lessonService);
                return View(model);
            }
            var times = model.InsertCourse.CourseTimeFormModels != null ? model.InsertCourse.CourseTimeFormModels.Select(i => new InsertTimePlaceDto { DayOfWeek = i.Gun, EndHour = i.EndTime, StartHour = i.EndTime }).ToList() : null;
            InsertCourseDto courseDto = new InsertCourseDto
            {
                CreatedBy = Guid.Parse(_sharedIdentityService.GetUserId),
                CreatedDate = DateTime.UtcNow,
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
                var teacherAdd = _lessonService.InsertCourseUser(new InsertCourseUserDto { RoleInCourseId = Guid.Parse(UserViewModel.TeacherRole), UserId = model.InsertCourse.Teacher.UserId, CourseId = entity.Id, CreatedBy = Guid.Parse(_sharedIdentityService.GetUserId) });

                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Add", "Course");

        }
    }
}
