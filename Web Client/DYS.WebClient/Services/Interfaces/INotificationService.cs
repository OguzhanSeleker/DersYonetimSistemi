using DYS.WebClient.Models.Notification;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DYS.WebClient.Services.Interfaces
{
    public interface INotificationService
    {
        Task<GetNotificationDto> AddNotificationAsync(AddNotificationDto addNotificationDto);
        Task<List<GetNotificationDto>> GetNotificationListByCourseIdAsync(string courseId);
        Task<GetNotificationDto> GetNotificationByIdAsync(string id);
        Task<bool> DeleteNotificationAsync(string id);
        Task<bool> UpdateNotificationAync(UpdateNotificationDto updateNotificationDto);
        Task<List<GetNotificationDto>> GetLastFiveNotificationUserCourseByCourseIdList(string courseIds);
    }
}
