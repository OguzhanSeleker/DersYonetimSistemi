using System;

namespace Services.Survey.Domain.Dtos
{
    public class GetQuestionContentDto : IDto
    {
        public string Option { get; set; }
        public Guid QuestionId { get; set; }
        public GetQuestionDto GetQuestionDto { get; set; }
        public Guid AnswerTypeId { get; set; }
        public GetAnswerTypeDto GetAnswerTypeDto { get; set; }
    }
}
