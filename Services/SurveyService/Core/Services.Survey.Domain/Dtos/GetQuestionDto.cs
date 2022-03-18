using System;
using System.Collections.Generic;

namespace Services.Survey.Domain.Dtos
{
    public class GetQuestionDto : IDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public int Number { get; set; }
        public Guid MainSurveyId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<GetQuestionContentDto> GetQuestionContentDtos { get; set; }
    }
}
