using DYS.WebClient.Models;
using DYS.WebClient.Models.Lesson;
using DYS.WebClient.Services;
using DYS.WebClient.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            var model = new LessonAddViewModel() { 
                
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

            var insertedLesson = _lessonService.InsertLesson(model.AddFormModel);
            if (insertedLesson != null)
                return RedirectToAction("Add", "Lesson");
            return View(model);
        }
    }
}
