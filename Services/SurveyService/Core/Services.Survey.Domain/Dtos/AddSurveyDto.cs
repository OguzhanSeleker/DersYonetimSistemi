using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Survey.Domain.Dtos
{
    public class AddSurveyDto : IDto
    {
        [Required]
        public Guid CreatedPerson { get; set; }
        [Required]
        public Guid LessonId { get; set; }
        [Required]
        public DateTime StartingDate { get; set; }
        [Required]
        public DateTime EndingDate { get; set; }
        [Required]
        public int QuestionNumber { get; set; }
        [Required]
        public bool Anonim { get; set; }
    }
}
