using System;
using System.ComponentModel.DataAnnotations;

namespace Services.Lesson.Domain.Dtos
{
    public class GetDto : IDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public Guid CreatedBy { get; set; }
        [Required]
        public DateTime? UpdatedDate { get; set; }
        [Required]
        public Guid? UpdatedBy { get; set; }
        [Required]
        public DateTime? DeletedDate { get; set; }
        [Required]
        public bool Deleted { get; set; }
    }
}
