using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.DAL.Concrete.Dtos
{
    public class AddLecturerToLessonDto
    {
        public string LessonId { get; set; }
        public LecturerDto Lecturer { get; set; }
    }
}
