using System.Collections.Generic;

namespace Lesson.DAL.Concrete.Dtos
{
    public class AddAssistantToLessonDto
    {
        public string LessonId { get; set; }
        public List<AssistantDto> Assistants { get; set; }
    }
}
