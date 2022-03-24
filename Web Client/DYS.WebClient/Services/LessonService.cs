using DYS.WebClient.Models.Lesson;
using DYS.WebClient.Services.Interfaces;
using SharedLibrary.ResponseDtos;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DYS.WebClient.Services
{
    public class LessonService : ILessonService
    {
        private readonly HttpClient _client;

        public LessonService(HttpClient client)
        {
            _client = client;
        }

        public async Task<bool> DeleteLesson(string id)
        {
            var response = await _client.DeleteAsync($"Lessons/DeleteLesson/{id}");
            if(response.IsSuccessStatusCode)
                return true;
            return false;
        }

        public async Task<QueryCourseDto> GetCourseById(string id)
        {
            var response = await _client.GetAsync($"Lessons/GetCourseById/{id}");
            if(response.IsSuccessStatusCode && response.Content != null)
            {
                var result = await response.Content.ReadFromJsonAsync<OperationResult<QueryCourseDto>>();
                return result.Data;
            }
            return null;
        }

        public async Task<QueryLessonDto> GetLessonByCourseId(string courseId)
        {
            var response = await _client.GetAsync($"Lessons/GetLessonByCourseId/{courseId}");
            if (!response.IsSuccessStatusCode)
                return null;
            var result = await response.Content.ReadFromJsonAsync<OperationResult<QueryLessonDto>>();
            return result.Data;
        }

        public async Task<QueryLessonDto> GetLessonById(string id)
        {
            var response = await _client.GetAsync($"Lessons/GetLessonById/{id}");
            if (!response.IsSuccessStatusCode)
                return null;
            var result = await response.Content.ReadFromJsonAsync<OperationResult<QueryLessonDto>>();
            return result.Data;
        }

        public async Task<List<QueryLessonDto>> GetLessonlistByUserId(string userId)
        {
            var response = await _client.GetAsync($"Lessons/GetLessonlistByUserId/{userId}");
            if (!response.IsSuccessStatusCode)
                return null;
            var result = await response.Content.ReadFromJsonAsync<OperationResult<List<QueryLessonDto>>>();
            return result.Data;
        }

        public Task<QueryCourseDto> InsertCourse(InsertCourseDto insertCourseDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> InsertCourseUser(InsertCourseUserDto insertCourseUserDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> InsertCourseUserList(List<InsertCourseUserDto> insertCourseUserDtos)
        {
            throw new System.NotImplementedException();
        }

        public Task<QueryLessonDto> InsertLesson(InsertLessonDto insertLessonDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> RemoveUserFromCourse(string courseUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateLesson(UpdateLessonDto updateLessonDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
