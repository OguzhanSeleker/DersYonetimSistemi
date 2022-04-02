using System;
using System.ComponentModel.DataAnnotations;

namespace DYS.WebClient.Models.Notification
{
    public class UpdateNotificationDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Guid WriterId { get; set; }
        [Required]
        public Guid CourseId { get; set; }
        [Required]
        public bool Priority { get; set; }
    }
}
