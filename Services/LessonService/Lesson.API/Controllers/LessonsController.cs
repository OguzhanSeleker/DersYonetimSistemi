using Lesson.DAL.Abstract;
using Lesson.DAL.Concrete.Dtos;
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

        [HttpGet]
        [Route("/api/[controller]/[action]")]
        public async Task<IActionResult> GetAll()
        {
            var lessons = await _lessonService.GetAllAsync();
            return CreateActionResultInstance(lessons);
        }
        [HttpGet]
        [Route("/api/[controller]/GetById")]
        public async Task<IActionResult> GetById([FromQuery]GetLessonDto getLessonDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var lesson = await _lessonService.GetByIdAsync(getLessonDto);
            return CreateActionResultInstance(lesson);
        }

        [HttpPost]
        [Route("/api/[controller]/[action]")]
        public async Task<IActionResult> Create(AddLessonDto addLessonDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _lessonService.CreateLessonAsync(addLessonDto);
            return CreateActionResultInstance(result); 
        }

        [HttpPut]
        [Route("/api/[controller]/[action]")]
        public async Task<IActionResult> AddStudentsToLesson(AddStudentsToLessonDto addStudentsToLessonDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _lessonService.AddStudentToLessonAsync(addStudentsToLessonDto);
            return CreateActionResultInstance(result);
        }
        [HttpPut]
        [Route("/api/[controller]/[action]")]
        public async Task<IActionResult> AddAssistantsToLesson(AddAssistantToLessonDto addAssistantToLessonDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _lessonService.AddAssistantToLessonAsync(addAssistantToLessonDto);
            return CreateActionResultInstance(result);
        }
        [HttpPut]
        [Route("/api/[controller]/[action]")]
        public async Task<IActionResult> UpdateLesson(UpdateLessonDto updateLessonDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _lessonService.UpdateLessonAsync(updateLessonDto);
            return CreateActionResultInstance(result);
        }
        [HttpPost]
        [Route("/api/[controller]/[action]")]
        public async Task<IActionResult> RemoveAssistantsFromLesson(RemoveAssistantsFromLessonDto removeAssistantsFromLessonDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _lessonService.RemoveAssistantsFromLessonAsync(removeAssistantsFromLessonDto);
            return CreateActionResultInstance(result);
        }

        [HttpPost]
        [Route("/api/[controller]/[action]")]
        public async Task<IActionResult> RemoveStudentsFromLesson(RemoveStudentsFromLessonDto removeStudentsFromLessonDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _lessonService.RemoveStudentsFromLessonAsync(removeStudentsFromLessonDto);
            return CreateActionResultInstance(result);
        }
        [HttpPost]
        [Route("/api/[controller]/[action]")]
        public async Task<IActionResult> RemoveLecturerFromLesson(RemoveLecturerFromLessonDto removeLecturerFromLessonDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _lessonService.RemoveLecturerFromLessonAsync(removeLecturerFromLessonDto);
            return CreateActionResultInstance(result);
        }

    }
}
