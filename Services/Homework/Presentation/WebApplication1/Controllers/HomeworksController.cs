using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Homework.API.Filters;
using Services.Homework.Application.Dtos;
using Services.Homework.Application.Mapping;
using Services.Homework.Application.Services;
using SharedLibrary.ControllerBases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Homework.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeworksController : CustomBaseController
    {
        private readonly IHomeworkInformationService _homeworkInformationService;
        private readonly IStudentHomeworkMetadataService _studentHomeworkMetadataService;
        private readonly IHomeworkMetadataService _homeworkMetadataService;

        public HomeworksController(IHomeworkInformationService homeworkInformationService, IStudentHomeworkMetadataService studentHomeworkMetadataService, IHomeworkMetadataService homeworkMetadataService)
        {
            _homeworkInformationService = homeworkInformationService;
            _studentHomeworkMetadataService = studentHomeworkMetadataService;
            _homeworkMetadataService = homeworkMetadataService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateHomework(AddHomeworkInformation model)
        {
            if (!ModelState.IsValid) return ReturnBadMessage("model is not valid");
            var mappedEntity = ObjectMapper.Mapper.Map<Homework.Domain.Entities.HomeworkInformation>(model);
            try
            {
                var entity = await _homeworkInformationService.AddAsync(mappedEntity);
                var dto = ObjectMapper.Mapper.Map<GetHomeworkInformation>(entity);
                return ReturnCreated<GetHomeworkInformation>(dto);
            }
            catch (Exception)
            {
                return ReturnError();
            }
        }

        [HttpGet]
        [ServiceFilter(typeof(ParameterFilterAttribute))]
        public async Task<IActionResult> GetHomeworkByCourseId(string courseId)
        {
            try
            {
                var homeworkList = _homeworkInformationService.GetByCourseId(courseId);
                var mappedList = ObjectMapper.Mapper.Map<List<GetHomeworkInformation>>(homeworkList);
                return ReturnOk(mappedList);
            }
            catch (Exception)
            {
                return ReturnNotFound();
            }
        }
        [HttpGet]
        [ServiceFilter(typeof(ParameterFilterAttribute))]
        public async Task<IActionResult> GetHomeworkInformationById(string id)
        {
            try
            {
                var homework = await _homeworkInformationService.GetByIdAsync(id);
                var mappedEntity = ObjectMapper.Mapper.Map<GetHomeworkInformation>(homework);
                return ReturnOk(mappedEntity);
            }
            catch (Exception)
            {
                return ReturnNotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddhomeworkFile(IFormFile File, IFormCollection metadatas, CancellationToken cancellationToken)
        {
            var homeworkInformationId = metadatas["homeworkInformationId"];
            var uploadBy = metadatas["uploadBy"];
            if (File != null && File.Length > 0 && !string.IsNullOrEmpty(homeworkInformationId) && !string.IsNullOrEmpty(uploadBy) && File.Length <= 20971520)
            {
                string directory = "wwwroot\\" + homeworkInformationId;
                DirectoryInfo di = null;
                if (!Directory.Exists(directory)) di = Directory.CreateDirectory(directory);
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(File.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), directory, fileName);
                using var stream = new FileStream(path: path, FileMode.Create);
                await File.CopyToAsync(stream, cancellationToken);
                var addHomeworkMetadata = new AddHomeworkMetadata
                {
                    DisplayName = File.FileName,
                    Extension = Path.GetExtension(File.FileName),
                    UploadBy = uploadBy,
                    UploadDate = DateTime.Now,
                    FullPath = path,
                    HomeworkInformationId = homeworkInformationId,
                    ShortPath = homeworkInformationId + "/" + fileName
                };
                var metadataEntity = await _homeworkMetadataService.AddAsync(ObjectMapper.Mapper.Map<Homework.Domain.Entities.HomeworkMetadata>(addHomeworkMetadata));
                if (metadataEntity != null) return ReturnOk(ObjectMapper.Mapper.Map<GetHomeworkMetadata>(metadataEntity));
                return ReturnError();
            }
            return ReturnBadMessage("metadata or file missing");
        }
    }
}
