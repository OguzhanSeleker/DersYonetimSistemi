using DYS.WebClient.Models.Lesson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DYS.WebClient.Services.Interfaces
{
    public interface ILessonService
    {
        Task<QueryLessonDto> InsertLesson(InsertLessonDto insertLessonDto);
        Task<QueryCourseDto> InsertCourse(InsertCourseDto insertCourseDto);
        Task<bool> InsertCourseUser(InsertCourseUserDto insertCourseUserDto);
        Task<bool> InsertCourseUserList(List<InsertCourseUserDto> insertCourseUserDtos);
        Task<QueryLessonDto> GetLessonById(string id);
        Task<List<QueryLessonDto>> GetLessonlistByUserId(string userId);
        Task<QueryLessonDto> GetLessonByCourseId(string courseId);
        Task<bool> UpdateLesson(UpdateLessonDto updateLessonDto);
        Task<bool> DeleteLesson(string id);
        Task<bool> RemoveUserFromCourse(string courseUserId);
        Task<QueryCourseDto> GetCourseById(string id);
        Task<List<QueryCourseDto>> GetCourseListByLessonIdAndUserId(string lessonId, string userId);

    }
}
