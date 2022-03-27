using DYS.WebClient.Models;
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
    public class BaseController : Controller
    {
        protected readonly IUserService _userService;
        protected readonly ISharedIdentityService _sharedIdentityService;
        private UserViewModel FieldCurrentUser;

        public UserViewModel CurrentUser
        {
            get
            {
                if (FieldCurrentUser == default(UserViewModel))
                {
                    if (User.Identity.IsAuthenticated)
                    {
                        var task = _userService.GetUserById(_sharedIdentityService.GetUserId);
                        FieldCurrentUser = task.Result == null ? default(UserViewModel) : task.Result;
                    }
                }
                return FieldCurrentUser;
            }
        }

        public BaseController(IUserService userService, ISharedIdentityService sharedIdentityService)
        {
            _userService = userService;
            _sharedIdentityService = sharedIdentityService;
        }
        [NonAction]
        protected async Task<SideBarViewModel> GetSideBarInfo(ILessonService lessonService)
        {

            var userNameSurname = User.Identity.Name;
            var getUserLessons = await lessonService.GetLessonlistByUserId(_sharedIdentityService.GetUserId);
            var sidebarLessonList = new List<SideBarLessonModel>();
            if (getUserLessons != null)
            {
                foreach (var userLesson in getUserLessons)
                {
                    var courseList = await lessonService.GetCourseListByLessonIdAndUserId(userLesson.Id.ToString(), _sharedIdentityService.GetUserId);
                    var sidebarlesson = new SideBarLessonModel
                    {
                        LessonName = userLesson.NameTR,
                        LessonCode = userLesson.Code,
                        LessonCourseModelList = courseList.ToList().Select(i => new SideBarLessonCourseModel { CourseCRN = i.CRN, CourseId = i.Id.ToString() }).ToList()
                    };
                    sidebarLessonList.Add(sidebarlesson);
                }

            }
            var sideBarModel = new SideBarViewModel { UserFullName = userNameSurname, LessonModelList = sidebarLessonList };
            return sideBarModel;
        }
    }
}
