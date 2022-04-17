using Services.Survey.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Survey.Domain.Entities
{
    public class QuestionContent : BaseEntity
    {
        public string Option { get; set; }
        [ForeignKey("Question")]
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }

        [ForeignKey("AnswerType")]
        public Guid AnswerTypeId { get; set; }
        public AnswerType AnswerType { get; set; }
    }
}
