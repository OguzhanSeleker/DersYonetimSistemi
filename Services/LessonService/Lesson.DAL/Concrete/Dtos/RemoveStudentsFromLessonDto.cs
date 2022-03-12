using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.DAL.Concrete.Dtos
{
    public class RemoveStudentsFromLessonDto
    {
        public string LessonId { get; set; }
        public List<string> StudentIdList { get; set; }
    }
}
