using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Lesson.API.Filters;
using Services.Lesson.Application.Repositories;
using Services.Lesson.Domain.Dtos;
using Services.Lesson.Domain.Entities;
using Services.Lesson.Domain.Mapping;
using SharedLibrary.ControllerBases;
using SharedLibrary.RabbitMQClasses;
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
        private readonly ISendEndpointProvider _sendEndpointProvider;
        public LessonsController(ILessonWriteRepository lessonWriteRepository, ILessonReadRepository lessonReadRepository, ICourseReadRepository courseReadRepository, ICourseWriteRepository courseWriteRepository, ICourseUserReadRepository courseUserReadRepository, ICourseUserWriteRepository courseUserWriteRepository, IRoleInCourseReadRepository roleInCourseReadRepository, IRoleInCourseWriteRepository roleInCourseWriteRepository, ITimePlaceReadRepository timePlaceReadRepository, ITimePlaceWriteRepository timePlaceWriteRepository, ISendEndpointProvider sendEndpointProvider)
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
            _sendEndpointProvider = sendEndpointProvider;
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
            if (await _courseWriteRepository.SaveAsync() < 1) return ReturnError();

            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:course-created-queue"));
            var createdCourseCommand = new CourseCreated
            {
                CourseId = course.Id,
                CRN = course.CRN,
                EndDate = course.EndDate,
                StartDate = course.StartDate,
                TimePlaces = course.TimePlaces.Select(i => new CreatedTimePlaces { DayOfWeek = i.DayOfWeek, EndHour = i.EndHour, Id = i.Id, StartHour = i.StartHour }).ToList()
            };

            await sendEndpoint.Send<CourseCreated>(createdCourseCommand);
            return ReturnCreated(ObjectMapper.Mapper.Map<QueryCourseDto>(course));
        }

        [HttpPost]
        [Route("InsertUserInCourse")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> InsertCourseUser(InsertCourseUserDto insertCourseUserDto)
        {
            await _courseUserWriteRepository.AddAsync(ObjectMapper.Mapper.Map<CourseUser>(insertCourseUserDto));
            if (await _courseUserWriteRepository.SaveAsync() < 1)
                return ReturnError();
            if (insertCourseUserDto.RoleInCourseId == Guid.Parse(RoleInCourse.Ogrenci))
            {
                var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:course-user-created-queue"));
                var createdCourseUserCommand = new CourseUserCreated
                {
                    CourseId = insertCourseUserDto.CourseId,
                    StudentId = insertCourseUserDto.UserId
                };
                await sendEndpoint.Send<CourseUserCreated>(createdCourseUserCommand);
            }
            return ReturnCreated();
        }

        [HttpPost]
        [Route("InsertUserInCourseList")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> InsertCourseUserList(List<InsertCourseUserDto> insertCourseUserDtos)
        {
            await _courseUserWriteRepository.AddRangeAsync(ObjectMapper.Mapper.Map<List<CourseUser>>(insertCourseUserDtos));
            if (await _courseUserWriteRepository.SaveAsync() < 1)
                return ReturnError();

            insertCourseUserDtos.ForEach(i =>
            {
                if (i.RoleInCourseId == Guid.Parse(RoleInCourse.Ogrenci))
                {
                    var sendEndpoint = _sendEndpointProvider.GetSendEndpoint(new Uri("queue:course-user-created-queue"));
                    var createdCourseUserCommand = new CourseUserCreated
                    {
                        CourseId = i.CourseId,
                        StudentId = i.UserId
                    };
                    sendEndpoint.Wait();
                    sendEndpoint.Result.Send<CourseUserCreated>(createdCourseUserCommand);
                }
            });
            return ReturnCreated();
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
        [Route("GetLessonList")]
        public IActionResult GetLessonList()
        {
            var lesson = _lessonReadRepository.GetAll(false);
            if (lesson != null && lesson.Count() > 0)
                return ReturnOk(ObjectMapper.Mapper.Map<List<QueryLessonDto>>(lesson));
            return ReturnNotFound();
        }


        [HttpGet]
        [Route("GetLessonlistByUserId")]
        [ServiceFilter(typeof(ParameterFilterAttribute))]
        public IActionResult GetLessonlistByUserId(string userId)
        {
            var courseUserList = _courseUserReadRepository.GetWhere(i => i.UserId == Guid.Parse(userId));
            if (courseUserList == null && courseUserList.Count() == 0)
                return ReturnNotFound();
            var courseList = courseUserList.Select(i => i.Course);
            var lessonList = courseList.Select(i => i.Lesson).ToList();

            //courseUserList.ToList().ForEach(i => { lessonList.Add(i.Course.Lesson); });
            return ReturnOk(ObjectMapper.Mapper.Map<List<QueryLessonDto>>(lessonList));
        }

        [HttpGet]
        [Route("GetLessonByCourseId")]
        [ServiceFilter(typeof(ParameterFilterAttribute))]
        public async Task<IActionResult> GetLessonByCourseId(string courseId)
        {
            var lessonList = await _lessonReadRepository.GetSingleAsync(i => i.Courses.Any(i => i.Id == Guid.Parse(courseId)));
            if (lessonList == null)
                return ReturnNotFound();
            return ReturnOk(ObjectMapper.Mapper.Map<QueryLessonDto>(lessonList));
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
        [Route("RemoveUserFromCourse/{courseUserId}")]
        [ServiceFilter(typeof(ParameterFilterAttribute))]
        public async Task<IActionResult> RemoveUserFromCourse(string courseUserId)
        {
            await _courseUserWriteRepository.RemoveAsync(courseUserId);
            var save = await _courseUserWriteRepository.SaveAsync();
            if (save > 0)
                return ReturnSuccess();
            return ReturnError();
        }

        [HttpGet]
        [Route("GetCourseById/{id}")]
        [ServiceFilter(typeof(ParameterFilterAttribute))]
        public async Task<IActionResult> GetCourseById(string id)
        {
            var course = await _courseReadRepository.GetByIdAsync(id);
            if (course == null)
                return ReturnNotFound();
            return ReturnOk(ObjectMapper.Mapper.Map<QueryCourseDto>(course));
        }

        [HttpGet]
        [Route("GetCourseListByLessonIdAndUserId")]
        [ServiceFilter(typeof(ParameterFilterAttribute))]
        public IActionResult GetCourseListByLessonIdAndUserId(string lessonId, string userId)
        {
            var list = _courseReadRepository.GetWhere(i => i.LessonId == Guid.Parse(lessonId) && i.CourseUsers.Any(i => i.UserId == Guid.Parse(userId)));
            if (list == null)
                return ReturnNotFound();
            return ReturnOk(ObjectMapper.Mapper.Map<List<QueryCourseDto>>(list));
        }
        [HttpGet]
        [Route("IsUserInCourse")]
        [ServiceFilter(typeof(ParameterFilterAttribute))]
        public async Task<IActionResult> IsUserInCourse(string id, string userId)
        {
            var course = await _courseReadRepository.GetByIdAsync(id, false);
            if (course == null)
                return NotFound();
            var users = course.CourseUsers.Where(i => i.UserId == Guid.Parse(userId)).AsQueryable();
            if (users.Any())
                return ReturnSuccess();
            return NotFound();
        }
        [HttpGet]
        [Route("GetUserListByCourseId/{courseId}")]
        [ServiceFilter(typeof(ParameterFilterAttribute))]
        public IActionResult GetUserListByCourseId(string courseId)
        {
            var userList = _courseUserReadRepository.GetWhere(i => i.CourseId == Guid.Parse(courseId));
            if (userList == null) return ReturnNotFound();
            var roleList = _roleInCourseReadRepository.GetAll();
            foreach (var user in userList.ToList())
            {
                user.RoleInCourse = roleList.FirstOrDefault(i => i.Id == user.RoleInCourseId);
            }
            return ReturnOk(ObjectMapper.Mapper.Map<List<QueryCourseUserDto>>(userList));
        }

        [HttpGet]
        [Route("GetCourseListByUserId/{userId}")]
        [ServiceFilter(typeof(ParameterFilterAttribute))]
        public IActionResult GetCourseListByUserId(string userId)
        {
            var courseUser = _courseUserReadRepository.GetWhere(i => i.UserId == Guid.Parse(userId));
            if (courseUser == null)
                return ReturnNotFound();
            var courseList = courseUser.Select(i => i.Course).ToList();
            if (courseList == null)
                return ReturnNotFound();
            return ReturnOk(ObjectMapper.Mapper.Map<List<QueryCourseDto>>(courseList));
        }
        //[HttpGet]
        //public async Task<IActionResult> test()
        //{
        //    await _roleInCourseWriteRepository.AddRangeAsync(new List<RoleInCourse>
        //    {
        //        new RoleInCourse{Id=Guid.Parse("a953a205-8343-427f-86f6-d09a5f1e659e"),RoleName="Öğrenci", RoleKey="Student"},
        //        new RoleInCourse{Id=Guid.Parse("a65c19b0-b1d9-44a8-a1e6-3caef164b282"),RoleName="Eğitmen", RoleKey="Lecturer"},
        //        new RoleInCourse{Id=Guid.Parse("72ab05e6-500a-4f80-8c1d-9c670d17612b"),RoleName="Asistan",RoleKey="Assistant" }

        //    });
        //    await _roleInCourseWriteRepository.SaveAsync();
        //    return ReturnSuccess();
        //}

    }
}
