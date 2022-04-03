using System;
using System.ComponentModel.DataAnnotations;

namespace DYS.WebClient.Models
{
    public class NotificationViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string WriterId { get; set; }
        [Required]
        public string WriterFullname { get; set; }
        [Required]
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        [Required]
        public bool Priority { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
