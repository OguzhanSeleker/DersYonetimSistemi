using System;
using System.ComponentModel.DataAnnotations;

namespace Services.Lesson.Domain.Dtos
{
    public class UpdateLessonDto : GetDto
    {
        [Required]
        public string NameTR { get; set; }
        [Required]
        public string NameEn { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public Guid CoordinatorId { get; set; }
        [Required]
        public string CoordinatorFullName { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public int TermNumber { get; set; }
        [Required]
        public double Credit { get; set; }
        [Required]
        public string Goals { get; set; }
        [Required]
        public string Descriptions { get; set; }
        [Required]
        public string OtherInformations { get; set; }
    }
}
