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
            var model1 = model;
            return View(model);
        }
    }
}
