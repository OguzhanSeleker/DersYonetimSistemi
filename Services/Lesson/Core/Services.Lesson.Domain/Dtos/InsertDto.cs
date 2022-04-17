using System;
using System.ComponentModel.DataAnnotations;

namespace Services.Lesson.Domain.Dtos
{
    public class InsertDto : IDto
    {
        [Required]
        public Guid CreatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
