using DYS.WebClient.Models.Notification;
using Newtonsoft.Json;
using SharedLibrary.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DYS.WebClient.Services
{
    public class NotificationService : Interfaces.INotificationService
    {
        private readonly HttpClient _client;

        public NotificationService(HttpClient client)
        {
            _client = client;
        }

        public async Task<GetNotificationDto> AddNotificationAsync(AddNotificationDto addNotificationDto)
        {
            var response = await _client.PostAsJsonAsync<AddNotificationDto>($"Notifications", addNotificationDto);
            var str = await response.Content.ReadAsStringAsync();
            var converted = JsonConvert.DeserializeObject<OperationResult<GetNotificationDto>>(str);
            if (converted != null)
                return converted.Data;
            return null;
        }

        public async Task<bool> DeleteNotificationAsync(string id)
        {
            var response = await _client.DeleteAsync($"Notifications/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<GetNotificationDto>> GetLastFiveNotificationUserCourseByCourseIdList(string courseIds)
        {
            var response = await _client.GetAsync($"Notifications/GetLastFiveNotificationUserCourseByCourseIdList?courseIds={courseIds}");
            if (!response.IsSuccessStatusCode) return null;
            var str = await response.Content.ReadAsStringAsync();

            var converted = JsonConvert.DeserializeObject<OperationResult<List<GetNotificationDto>>>(str);

            return converted.Data;

        }

        public async Task<GetNotificationDto> GetNotificationByIdAsync(string id)
        {
            var response = await _client.GetAsync($"Notifications/{id}");
            var converted = JsonConvert.DeserializeObject<OperationResult<GetNotificationDto>>(await response.Content.ReadAsStringAsync());
            if (converted != null)
                return converted.Data;
            return null;
        }

        public async Task<List<GetNotificationDto>> GetNotificationListByCourseIdAsync(string courseId)
        {
            var response = await _client.GetAsync($"Notifications/GetNotificationListByCourseId/{courseId}");
            var converted = JsonConvert.DeserializeObject<OperationResult<List<GetNotificationDto>>>(await response.Content.ReadAsStringAsync());
            if (converted != null)
                return converted.Data;
            return null;
        }

        public async Task<bool> UpdateNotificationAync(UpdateNotificationDto updateNotificationDto)
        {
            var response = await _client.PutAsJsonAsync($"Notifications", updateNotificationDto);
            return response.IsSuccessStatusCode;
        }
    }
}
