using Services.Survey.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Survey.Domain.Entities
{
    public class MainSurvey : BaseEntity
    {
        public Guid CreatedPerson { get; set; }
        public Guid LessonId { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public int QuestionNumber { get; set; }
        public bool Anonim { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
