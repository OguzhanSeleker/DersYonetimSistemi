using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.Interfaces
{
    public interface ILessonRepository : IRepository<Aggregates.Lesson>
    {
        void AddLecturers(List<Aggregates.LessonLecturer> lessonLecturers);
        void AddAssistants(List<Aggregates.LessonAssistant> lessonAssistants);
        void AddStudents(List<Aggregates.LessonStudent> lessonStudents);
        void RemoveLecturers(List<Aggregates.LessonLecturer> lessonLecturers);
        void RemoveAssistants(List<Aggregates.LessonAssistant> lessonAssistants);
        void RemoveStudents(List<Aggregates.LessonStudent> lessonStudents);
    }
}
