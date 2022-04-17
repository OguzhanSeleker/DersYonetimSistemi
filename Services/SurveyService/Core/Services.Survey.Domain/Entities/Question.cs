using Services.Survey.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Survey.Domain.Entities
{
    public class Question : BaseEntity
    {

        public string Content { get; set; }
        public int Number { get; set; }

        [ForeignKey("MainSurvey")]
        public Guid MainSurveyId { get; set; }
        public MainSurvey MainSurvey { get; set; }

        public virtual ICollection<QuestionContent> QuestionContents { get; set; }
    }
}
