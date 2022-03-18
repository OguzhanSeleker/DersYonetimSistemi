using System;
using System.Collections.Generic;

namespace Services.Survey.Domain.Dtos
{
    public class GetSurveyDto : IDto
    {
        public Guid Id { get; set; }
        public Guid CreatedPerson { get; set; }
        public Guid LessonId { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public int QuestionNumber { get; set; }
        public bool Anonim { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }
        public virtual ICollection<GetQuestionDto> QuestionDtos { get; set; }
    }
}
