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

        }
    }
}
