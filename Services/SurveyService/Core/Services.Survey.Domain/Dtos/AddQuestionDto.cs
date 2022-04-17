using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Services.Survey.Domain.Dtos
{
    public class AddQuestionDto : IDto
    {
        [Required]
        public string Content { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public Guid MainSurveyId { get; set; }

        [Required]
        public ICollection<AddQuestionContentDto> QuestionContents { get; set; }
    }
}
