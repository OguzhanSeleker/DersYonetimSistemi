using System;
using System.ComponentModel.DataAnnotations;

namespace Services.Survey.Domain.Dtos
{
    public class AddQuestionContentDto : IDto
    {
        [Required]
        public string Option { get; set; }

        [Required]
        public Guid AnswerTypeId { get; set; }
    }
}
