using System;
using System.ComponentModel.DataAnnotations;

namespace DYS.WebClient.Models.Lesson
{
    public class InsertDto : IDto
    {
        [Required]
        public Guid CreatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
