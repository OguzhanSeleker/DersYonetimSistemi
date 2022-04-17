using Services.Survey.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Survey.Domain.Entities
{
    public class Answer : BaseEntity
    {
        public Guid AnsweringPerson { get; set; }
        public DateTime AnsweringDate { get; set; }
        public string AnswerContent { get; set; }
        public Guid LessonId { get; set; }

        [ForeignKey("QuestionContent")]
        public Guid QuestionContentId { get; set; }
        public QuestionContent QuestionContent { get; set; }

        [ForeignKey("Question")]
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
        
        [ForeignKey("MainSurvey")]
        public Guid MainSurveyId { get; set; }
        public MainSurvey MainSurvey { get; set; }
    }
}
