using System;

namespace DYS.WebClient.Models
{
    public class NotificationViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string WriterId { get; set; }
        public string WriterFullname { get; set; }
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public bool Priority { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
