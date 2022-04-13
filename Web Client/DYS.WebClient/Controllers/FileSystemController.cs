using DYS.WebClient.Filters;
using DYS.WebClient.Models;
using DYS.WebClient.Models.CourseFileSystem;
using DYS.WebClient.Services;
using DYS.WebClient.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DYS.WebClient.Controllers
{
    [Authorize]
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
            var fileList = await _courseFileSystemService.GetByCourseId(courseId);
            var model = new FileOperationViewModel()
            {
                Course = course,
                Lesson = lesson,
                SideBarViewModel = await GetSideBarInfo(_lessonService),
                FileList = fileList

            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> FileUpload(FileOperationViewModel model)
        {
             await _courseFileSystemService.AddCourseFile(new Models.CourseFileSystem.AddFileWithMetadata { AddFileSystemDto = new Models.CourseFileSystem.AddFileSystemDto { CourseId = model.FileOperationModel.CourseId.ToString(), CourseCRN = model.FileOperationModel.CourseCRN, CreatedBy = _sharedIdentityService.GetUserId }, File = model.FileOperationModel.File, FileName = model.FileOperationModel.FileName });
            return RedirectToAction("FileOperation", "FileSystem", new { courseId = model.FileOperationModel.CourseId }); 

        }

        [HttpGet]
        public async Task<IActionResult> DownloadFile(string fileId)
        {
            if (string.IsNullOrEmpty(fileId)) return NotFound();
            FileDto fileDto = await _courseFileSystemService.DownloadFile(fileId);
            if(fileDto == null) return NotFound();
            
            return File(fileDto.fileByteArr, "application/octet-stream",fileDto.DisplayName);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteFile(string fileId,string courseId)
        {
            if(string.IsNullOrEmpty(fileId)) return NotFound();
            var test = await _courseFileSystemService.DeleteFile(fileId);
            return test ? RedirectToAction("FileOperation", "FileSystem", new { courseId = courseId }) : NotFound();
        }
    }
}
