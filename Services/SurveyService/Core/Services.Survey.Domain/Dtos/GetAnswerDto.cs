using System;

namespace Services.Survey.Domain.Dtos
{
    public class GetAnswerDto : IDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }
        public Guid AnsweringPerson { get; set; }
        public DateTime AnsweringDate { get; set; }
        public string AnswerContent { get; set; }
        public Guid LessonId { get; set; }
        public Guid QuestionId { get; set; }
        public GetQuestionDto GetQuestionDto { get; set; }
        public Guid MainSurveyId { get; set; }
        public GetSurveyDto GetSurveyDto { get; set; }
    }
}
