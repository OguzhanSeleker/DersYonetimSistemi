using Lesson.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson.Domain.Aggregates
{
    [Table("LessonCodes")]
    public class LessonCode : AuditEntity<int>
    {
        public string Code { get; set; }
        public string CoordinatorId { get; set; }
    }
}