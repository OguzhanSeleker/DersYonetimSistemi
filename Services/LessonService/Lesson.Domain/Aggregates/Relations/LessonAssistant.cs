using Lesson.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.Aggregates
{
    [Table("LessonAssistants")]
    public class LessonAssistant : AuditEntity<int>
    {
        public int LessonId { get; set; }
        public int AssistantId { get; set; }
        public string AssistantFullName { get; set; }

        [ForeignKey(nameof(LessonId))]
        public Lesson Lesson { get; set; }
    }
}
