using DYS.WebClient.Models;
using DYS.WebClient.Services;
using DYS.WebClient.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DYS.WebClient.Controllers
{
    [Authorize]
    public class LessonController : BaseController
    {
        private readonly ILessonService _lessonService;

        public LessonController(IUserService userService, ISharedIdentityService sharedIdentityService, ILessonService lessonService) : base(userService, sharedIdentityService)
        {
            _lessonService = lessonService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var sideBarModel = await GetSideBarInfo(_lessonService);
            var model = new LessonIndexViewModel
            {
                SideBarViewModel = sideBarModel,
                SigninInput = new SigninInput()
            };
            return View(model);

        }

        [HttpGet]
        [Authorize(Roles ="Admin,Teacher")]
        public async Task<IActionResult> Add()
        {
            return View(await GetSideBarInfo(_lessonService));

        }
    }
}
