using DYS.WebClient.Models.Notification;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DYS.WebClient.Services.Interfaces
{
    public interface INotificationService
    {
        Task<GetNotificationDto> AddNotification(AddNotificationDto addNotificationDto);
        Task<List<GetNotificationDto>> GetNotificationListByCourseId(string courseId);
        Task<GetNotificationDto> GetNotificationById(string id);
        Task<bool> DeleteNotification(string id);
        Task<bool> UpdateNotifation(UpdateNotificationDto updateNotificationDto);
    }
}
