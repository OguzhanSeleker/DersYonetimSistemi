using System;

namespace DYS.WebClient.Models.Notification
{
    public class GetNotificationDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid WriterId { get; set; }
        public Guid CourseId { get; set; }
        public bool Priority { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
