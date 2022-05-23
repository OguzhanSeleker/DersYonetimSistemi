using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Homework.Application.Dtos;
using Services.Homework.Application.Services;
using SharedLibrary.ControllerBases;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IActionResult> AddHomework(AddHomeworkInformation addHomeworkInformation)
        {
            
        }
    }
}
