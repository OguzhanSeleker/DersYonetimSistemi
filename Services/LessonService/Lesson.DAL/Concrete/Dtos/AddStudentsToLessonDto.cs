using System.Collections.Generic;
using Lesson.DAL.Concrete.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.DAL.Concrete.Dtos
{
    public class AddStudentsToLessonDto
    {
        [Required]
        public string LessonId { get; set; }
        [Required]
        public List<StudentDto> Students { get; set; }
    }
}
