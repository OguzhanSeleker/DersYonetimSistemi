using System;
using System.ComponentModel.DataAnnotations;

namespace Services.Survey.Domain.Dtos
{
    public class AddAnswerDto : IDto
    {
        [Required]
        public Guid AnsweringPerson { get; set; }
        [Required]
        public DateTime AnsweringDate { get; set; }
        [Required]
        public string AnswerContent { get; set; }
        [Required]
        public Guid LessonId { get; set; }
        [Required]
        public Guid QuestionId { get; set; }
        [Required]
        public Guid MainSurveyId { get; set; }
    }
}
