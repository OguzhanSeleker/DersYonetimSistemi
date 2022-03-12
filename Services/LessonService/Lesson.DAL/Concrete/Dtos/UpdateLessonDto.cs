using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.DAL.Concrete.Dtos
{
    public class UpdateLessonDto
    {
        [Required]
        public string LessonId { get; set; }
        [Required]
        public string LessonCode { get; set; }
        [Required]
        public string LessonName { get; set; }
        [Required]
        public string LessonCRN { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public DateTime LastAccessDate { get; set; }
        [Required]
        public List<TimeDayDto> TimesDays { get; set; }
        [Required]
        public List<LecturerDto> Lecturers { get; set; }
        [Required]
        public List<AssistantDto> Assistants { get; set; }
        [Required]
        public List<StudentDto> Students { get; set; }
    }
}
