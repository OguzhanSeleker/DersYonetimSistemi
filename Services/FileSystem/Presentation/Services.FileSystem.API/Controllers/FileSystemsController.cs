using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.FileSystem.API.Filters;
using Services.FileSystem.API.Models;
using Services.FileSystem.Application;
using Services.FileSystem.Domain.Dtos;
using Services.FileSystem.Domain.Mapping;
using SharedLibrary.ControllerBases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.FileSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileSystemsController : CustomBaseController
    {
        private readonly IFileMetadataService _fileMetadataService;

        public FileSystemsController(IFileMetadataService fileMetadataService)
        {
            _fileMetadataService = fileMetadataService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCourseFile(IFormFile File,IFormCollection keyValues, CancellationToken cancellationToken)
        {
            var req = Request;
            var courseCRN = keyValues["courseCRN"];
            var courseId = keyValues["courseId"];
            var createdBy = keyValues["createdBy"];
            
            if (File != null && File.Length > 0 && !string.IsNullOrEmpty(courseId) && !string.IsNullOrEmpty(createdBy) && !string.IsNullOrEmpty(courseCRN) && File.Length <= 20971520)
            {
                string directory = "wwwroot\\" + courseCRN;
                DirectoryInfo di = null;
                if (!Directory.Exists(directory)) di = Directory.CreateDirectory(directory);

                var path = Path.Combine(Directory.GetCurrentDirectory(), directory, Guid.NewGuid().ToString() + Path.GetExtension(File.FileName));
                using var stream = new FileStream(path: path, FileMode.Create);
                await File.CopyToAsync(stream, cancellationToken);
                var addFileSystemDto = new AddFileSystemDto()
                {
                    CourseCRN = courseCRN,
                    Path = path,
                    CourseId = courseId,
                    CreatedBy = createdBy,
                    Extension = Path.GetExtension(File.FileName)
                };
                var getmetadata = await _fileMetadataService.AddFileMetadata(addFileSystemDto);
                if (getmetadata.Success) return ReturnOk(getmetadata.Data);
                return ReturnError();
            }
            return ReturnBadMessage("metadata or file missing");
        }
        [HttpGet]
        [ServiceFilter(typeof(ParameterFilterAttribute))]
        [Route("GetFileListByCourseId/{courseId}")]
        public async Task<IActionResult> GetFileListByCourseId(string courseId)
        {
            var metadatalist = await _fileMetadataService.GetByCourseId(courseId);
            if (!metadatalist.Success) return ReturnNotFound();
            return ReturnOk(metadatalist.Data);
        }
    }
}
