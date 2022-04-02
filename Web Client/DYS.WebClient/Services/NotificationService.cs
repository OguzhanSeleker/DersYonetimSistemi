using DYS.WebClient.Models.Notification;
using Newtonsoft.Json;
using SharedLibrary.ResponseDtos;
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

        public async Task<GetNotificationDto> AddNotification(AddNotificationDto addNotificationDto)
        {
            var response = await _client.PostAsJsonAsync<AddNotificationDto>($"Notifications", addNotificationDto);
            var converted = JsonConvert.DeserializeObject<OperationResult<GetNotificationDto>>(await response.Content.ReadAsStringAsync());
            return converted.Data;

        }

        public async Task<bool> DeleteNotification(string id)
        {
            var response = await _client.DeleteAsync($"Notifications/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<GetNotificationDto> GetNotificationById(string id)
        {
            var response = await _client.GetAsync($"Notifications/{id}");
            var converted = JsonConvert.DeserializeObject<OperationResult<GetNotificationDto>>(await response.Content.ReadAsStringAsync());
            return converted.Data;
        }

        public async Task<List<GetNotificationDto>> GetNotificationListByCourseId(string courseId)
        {
            var response = await _client.GetAsync($"Notifications/GetNotificationListByCourseId/{courseId}");
            var converted = JsonConvert.DeserializeObject<OperationResult<List<GetNotificationDto>>>(await response.Content.ReadAsStringAsync());
            return converted.Data;
        }

        public async Task<bool> UpdateNotifation(UpdateNotificationDto updateNotificationDto)
        {
            var response = await _client.PutAsJsonAsync($"Notifications", updateNotificationDto);
            return response.IsSuccessStatusCode;
        }
    }
}
