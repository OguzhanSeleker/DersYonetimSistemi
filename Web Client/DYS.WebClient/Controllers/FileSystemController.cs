using DYS.WebClient.Filters;
using DYS.WebClient.Models;
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
    public class FileSystemController : BaseController
    {
        private readonly ICourseFileSystemService _courseFileSystemService;
        private readonly ILessonService _lessonService;


        public FileSystemController(IUserService userService, ISharedIdentityService sharedIdentityService, ILessonService lessonService, ICourseFileSystemService courseFileSystemService) : base(userService, sharedIdentityService)
        {
            _lessonService = lessonService;
            _courseFileSystemService = courseFileSystemService;
        }

        [HttpGet]
        [Route("Course/{courseId}/FileOperation")]
        [ServiceFilter(typeof(ParameterFilterAttribute))]
        public async Task<IActionResult> FileOperation(string courseId)
        {
            var course = await _lessonService.GetCourseById(courseId);
            if (course == null) return NotFound();
            var lesson = await _lessonService.GetLessonByCourseId(courseId);
            if (lesson == null) return NotFound();

            var model = new FileOperationViewModel()
            {
                Course = course,
                Lesson = lesson,
                SideBarViewModel = await GetSideBarInfo(_lessonService)
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Teacher")]
        public IActionResult FileUpload(FileOperationViewModel model)
        {
             _courseFileSystemService.AddCourseFile(new Models.CourseFileSystem.AddFileWithMetadata { AddFileSystemDto = new Models.CourseFileSystem.AddFileSystemDto { CourseId = model.FileOperationModel.CourseId, CourseCRN = model.FileOperationModel.CourseCRN, CreatedBy = Guid.Parse(_sharedIdentityService.GetUserId) }, File = model.FileOperationModel.File, FileName = model.FileOperationModel.FileName });
            return RedirectToAction("FileOperation", "FileSystem", new { courseId = model.FileOperationModel.CourseId }); 

        }
    }
}
