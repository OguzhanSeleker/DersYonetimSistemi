using Lesson.API.Dtos;
using Lesson.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.ControllerBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : CustomBaseController
    {
        private readonly ILessonService _lessonService;

        public LessonsController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpPost]
        public async Task<IActionResult> Test([FromBody] CreateLessonDto createLessonDto)
        {
            return CreateActionResultInstance(await _lessonService.AddLesson(createLessonDto));
        }
    }
}
