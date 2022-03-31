using DYS.WebClient.Models.Lesson;
using DYS.WebClient.Services.Interfaces;
using Newtonsoft.Json;
using SharedLibrary.ResponseDtos;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
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
        public async Task<List<QueryLessonDto>> GetLessonList()
        {
            var response = await _client.GetAsync("Lessons/GetLessonList");
            if(response.IsSuccessStatusCode && response.Content != null)
            {
                var str = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<OperationResult<List<QueryLessonDto>>>(str);
                return result.Data;
            }
            return null;
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
                string str = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<OperationResult<QueryCourseDto>>(str);
                return result.Data;
            }
            return null;
        }

        [System.Obsolete]
        public async Task<List<QueryCourseDto>> GetCourseListByLessonIdAndUserId(string lessonId, string userId)
        {
            var response = await _client.GetAsync($"Lessons/GetCourseListByLessonIdAndUserId?lessonId={lessonId}&userId={userId}");
            if (!response.IsSuccessStatusCode)
                return null;
            string str = await response.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<OperationResult<List<QueryCourseDto>>>(str);
            return res.Data;
        }

        public async Task<QueryLessonDto> GetLessonByCourseId(string courseId)
        {
            var response = await _client.GetAsync($"Lessons/GetLessonByCourseId?courseId={courseId}");
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
            var response = await _client.GetAsync($"Lessons/GetLessonlistByUserId?userId={userId}");
            if (!response.IsSuccessStatusCode)
                return null;
            var byteArr = await response.Content.ReadAsByteArrayAsync();
            var result = JsonConvert.DeserializeObject<OperationResult<List<QueryLessonDto>>>(Encoding.UTF8.GetString(byteArr));
            return result.Data;
        }

        public async Task<QueryCourseDto> InsertCourse(InsertCourseDto insertCourseDto)
        {
            var response = await _client.PostAsJsonAsync<InsertCourseDto>($"Lessons/InsertCourse", insertCourseDto);
            if (!response.IsSuccessStatusCode)
                return null;
            return (await response.Content.ReadFromJsonAsync<OperationResult<QueryCourseDto>>()).Data;
        }

        public async Task<bool> InsertCourseUser(InsertCourseUserDto insertCourseUserDto)
        {
            var response = await _client.PostAsJsonAsync<InsertCourseUserDto>($"Lessons/InsertCourseUser", insertCourseUserDto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> InsertCourseUserList(List<InsertCourseUserDto> insertCourseUserDtos)
        {
            var response = await _client.PostAsJsonAsync<List<InsertCourseUserDto>>($"Lessons/InsertCourseUser", insertCourseUserDtos);
            return response.IsSuccessStatusCode;
        }

        public async Task<QueryLessonDto> InsertLesson(InsertLessonDto insertLessonDto)
        {
            var response = await _client.PostAsJsonAsync<InsertLessonDto>($"Lessons/InsertLesson", insertLessonDto);
            if (!response.IsSuccessStatusCode)
                return null;
            string str = await response.Content.ReadAsStringAsync();
            var res =  JsonConvert.DeserializeObject<OperationResult<QueryLessonDto>>(str);
            return res.Data;
        }

        public async Task<bool> RemoveUserFromCourse(string courseUserId)
        {
            var response = await _client.DeleteAsync($"Lessons/RemoveUserFromCourse{courseUserId}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateLesson(UpdateLessonDto updateLessonDto)
        {
            var response = await _client.PutAsJsonAsync<UpdateLessonDto>($"Lessons/UpdateLesson", updateLessonDto);
            return response.IsSuccessStatusCode;
        }
    }
}
