using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Lesson.API.Filters;
using Services.Lesson.Application.Repositories;
using Services.Lesson.Domain.Dtos;
using Services.Lesson.Domain.Entities;
using Services.Lesson.Domain.Mapping;
using SharedLibrary.ControllerBases;
using SharedLibrary.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Lesson.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(HttpResponseExceptionFilter))]
    [Authorize]
    public class LessonsController : CustomBaseController
    {
        #region Repository
        private readonly ILessonWriteRepository _lessonWriteRepository;
        private readonly ILessonReadRepository _lessonReadRepository;
        private readonly ICourseReadRepository _courseReadRepository;
        private readonly ICourseWriteRepository _courseWriteRepository;
        private readonly ICourseUserReadRepository _courseUserReadRepository;
        private readonly ICourseUserWriteRepository _courseUserWriteRepository;
        private readonly IRoleInCourseReadRepository _roleInCourseReadRepository;
        private readonly IRoleInCourseWriteRepository _roleInCourseWriteRepository;
        private readonly ITimePlaceReadRepository _timePlaceReadRepository;
        private readonly ITimePlaceWriteRepository _timePlaceWriteRepository;
        #endregion
        public LessonsController(ILessonWriteRepository lessonWriteRepository, ILessonReadRepository lessonReadRepository, ICourseReadRepository courseReadRepository, ICourseWriteRepository courseWriteRepository, ICourseUserReadRepository courseUserReadRepository, ICourseUserWriteRepository courseUserWriteRepository, IRoleInCourseReadRepository roleInCourseReadRepository, IRoleInCourseWriteRepository roleInCourseWriteRepository, ITimePlaceReadRepository timePlaceReadRepository, ITimePlaceWriteRepository timePlaceWriteRepository)
        {
            _lessonWriteRepository = lessonWriteRepository;
            _lessonReadRepository = lessonReadRepository;
            _courseReadRepository = courseReadRepository;
            _courseWriteRepository = courseWriteRepository;
            _courseUserReadRepository = courseUserReadRepository;
            _courseUserWriteRepository = courseUserWriteRepository;
            _roleInCourseReadRepository = roleInCourseReadRepository;
            _roleInCourseWriteRepository = roleInCourseWriteRepository;
            _timePlaceReadRepository = timePlaceReadRepository;
            _timePlaceWriteRepository = timePlaceWriteRepository;
        }
        [HttpPost]
        [Route("InsertLesson")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> InsertLesson(InsertLessonDto insertLessonDto)
        {
            var lesson = await _lessonWriteRepository.AddAsync(ObjectMapper.Mapper.Map<Domain.Entities.Lesson>(insertLessonDto));
            int save = await _lessonWriteRepository.SaveAsync();
            if (save > 0)
                return ReturnCreated(ObjectMapper.Mapper.Map<QueryLessonDto>(lesson));
            return ReturnError();
        }
        [HttpPost]
        [Route("InsertCourse")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> InsertCourse(InsertCourseDto insertCourseDto)
        {
            var course = await _courseWriteRepository.AddAsync(ObjectMapper.Mapper.Map<Course>(insertCourseDto));
            if (await _courseWriteRepository.SaveAsync() > 0)
                return ReturnCreated(ObjectMapper.Mapper.Map<QueryCourseDto>(course));
            return ReturnError();
        }
        [HttpPost]
        [Route("InsertUserInCourse")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> InsertCourseUser(InsertCourseUserDto insertCourseUserDto)
        {
            await _courseUserWriteRepository.AddAsync(ObjectMapper.Mapper.Map<CourseUser>(insertCourseUserDto));
            if (await _courseUserWriteRepository.SaveAsync() > 0)
                return ReturnCreated();
            return ReturnError();
        }
        [HttpPost]
        [Route("InsertUserInCourseList")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> InsertCourseUserList(List<InsertCourseUserDto> insertCourseUserDtos)
        {
            await _courseUserWriteRepository.AddRangeAsync(ObjectMapper.Mapper.Map<List<CourseUser>>(insertCourseUserDtos));
            if(await _courseUserWriteRepository.SaveAsync() > 0)
                return ReturnCreated();
            return ReturnError();
        }
        [HttpGet]
        [Route("GetLessonById")]
        [ServiceFilter(typeof(ParameterFilterAttribute))]
        public async Task<IActionResult> GetLessonById(string id)
        {
            var lesson = await _lessonReadRepository.GetByIdAsync(id, false);
            if (lesson == null)
                return ReturnNotFound();
            return ReturnOk(ObjectMapper.Mapper.Map<QueryLessonDto>(lesson));
        }
        [HttpGet]
        [Route("GetLessonlistById")]
        [ServiceFilter(typeof(ParameterFilterAttribute))]
        public IActionResult GetLessonlistByUserId(string userId)
        {
            var courseUserList = _courseUserReadRepository.GetWhere(i => i.UserId == Guid.Parse(userId));
            if (courseUserList == null && courseUserList.Count() == 0)
                return ReturnNotFound();
            var lessonList = new List<Domain.Entities.Lesson>();
            courseUserList.ToList().ForEach(i => { lessonList.Add(i.Course.Lesson); });
            return ReturnOk(ObjectMapper.Mapper.Map<List<QueryLessonDto>>(lessonList));
        }

        [HttpGet]
        [Route("GetLessonByCourseId")]
        [ServiceFilter(typeof(ParameterFilterAttribute))]
        public IActionResult GetLessonByCourseId(string courseId)
        {
            var lessonList = _lessonReadRepository.GetWhere(i => i.Courses.Any(i => i.Id == Guid.Parse(courseId)));
            if (lessonList == null && lessonList.Count() == 0)
                return ReturnNotFound();
            return ReturnOk(ObjectMapper.Mapper.Map<List<QueryLessonDto>>(lessonList));
        }
        [HttpPut]
        [Route("UpdateLesson")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateLesson(UpdateLessonDto updateLessonDto)
        {
            _lessonWriteRepository.Update(ObjectMapper.Mapper.Map<Domain.Entities.Lesson>(updateLessonDto));
            if (await _lessonWriteRepository.SaveAsync() > 0)
                return ReturnSuccess();
            return ReturnError();
        }
        [HttpDelete]
        [Route("DeleteLesson")]
        [ServiceFilter(typeof(ParameterFilterAttribute))]
        public async Task<IActionResult> DeleteLesson(string id)
        {
            await _lessonWriteRepository.RemoveAsync(id);
            if (await _lessonWriteRepository.SaveAsync() > 0)
                return ReturnSuccess();
            return ReturnError();
        }
        [HttpDelete]
        [Route("RemoveUserFromCourse")]
        [ServiceFilter(typeof(ParameterFilterAttribute))]
        public async Task<IActionResult> RemoveUserFromCourse(string courseUserId)
        {
            await _courseUserWriteRepository.RemoveAsync(courseUserId);
            if(await _courseUserWriteRepository.SaveAsync() > 0)
                ReturnSuccess();
            return ReturnError();
        }
        [HttpGet]
        [Route("GetCourseById")]
        [ServiceFilter(typeof(ParameterFilterAttribute))]
        public async Task<IActionResult> GetCourseById(string id)
        {
            var course = _courseReadRepository.GetByIdAsync(id);
            if (course == null)
                return ReturnNotFound();
            return ReturnOk(ObjectMapper.Mapper.Map<QueryCourseDto>(course));
        }
        //[HttpGet]
        //public async Task<IActionResult> test()
        //{
        //    await _roleInCourseWriteRepository.AddRangeAsync(new List<RoleInCourse>
        //    {
        //        new RoleInCourse{RoleName="Öğrenci", RoleKey="Student"},
        //        new RoleInCourse{RoleName="Eğitmen", RoleKey="Lecturer"},
        //        new RoleInCourse{RoleName="Asistan",RoleKey="Assistant" }

        //    });
        //    await _roleInCourseWriteRepository.SaveAsync();
        //    return ReturnSuccess();
        //}

    }
}
