using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.FileSystem.API.Filters;
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
        public async Task<IActionResult> AddCourseFile(AddFileSystemDto addFileSystemDto, IFormFile file, CancellationToken cancellationToken)
        {
            if (file != null && file.Length > 0 && file.Length <= 20971520 && addFileSystemDto != null && !string.IsNullOrEmpty(addFileSystemDto.CourseCRN))
            {
                string directory = "wwwroot/" + addFileSystemDto.CourseCRN;
                DirectoryInfo di = null;
                if (!Directory.Exists(directory)) di = Directory.CreateDirectory(directory);

                var path = Path.Combine(Directory.GetCurrentDirectory(), directory, file.FileName);
                using var stream = new FileStream(path: path, FileMode.Create);
                await file.CopyToAsync(stream, cancellationToken);
                addFileSystemDto.Path = file.FileName;
                addFileSystemDto.Extension = Path.GetExtension(file.FileName);
                var getmetadata = await _fileMetadataService.AddFileMetadata(addFileSystemDto);
                if (getmetadata.Success) return ReturnOk(getmetadata.Data);
                return ReturnError();
            }
            return ReturnBadMessage("metadata or file missing");
        }
        [HttpGet]
        [ServiceFilter(typeof(ParameterFilterAttribute))]
        public async Task<IActionResult> GetFileListByCourseId(string courseId)
        {
            var metadatalist = await _fileMetadataService.GetByCourseId(courseId);
            if (!metadatalist.Success) return ReturnNotFound();
            return ReturnOk(metadatalist.Data);
        }
    }
}
