using Lesson.Domain.Aggregates;
using Lesson.Domain.Base;
using Lesson.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Infrastructure.Repositories
{
    public class LessonRepository : Repository<Domain.Aggregates.Lesson>, ILessonRepository
    {

        public LessonRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        public void AddAssistants(List<LessonAssistant> lessonAssistants)
        {
            base._dbFactory.DbContext.Set<LessonAssistant>().AddRange(lessonAssistants);
        }

        public void AddLecturers(List<LessonLecturer> lessonLecturers)
        {
            base._dbFactory.DbContext.Set<LessonLecturer>().AddRange(lessonLecturers);
        }

        public void AddStudents(List<LessonStudent> lessonStudents)
        {
            base._dbFactory.DbContext.Set<LessonStudent>().AddRange(lessonStudents);
        }

        public void RemoveAssistants(List<LessonAssistant> lessonAssistants)
        {
            foreach (var item in lessonAssistants)
            {
                LessonAssistant update = new LessonAssistant
                {
                    LessonId = item.LessonId,
                    AssistantId = item.AssistantId,
                    IsDeleted = true
                };
                _dbFactory.DbContext.Attach(update);
                _dbFactory.DbContext.Entry(update).Property(i => i.IsDeleted).IsModified = true;
            }
        }

        public void RemoveLecturers(List<LessonLecturer> lessonLecturers)
        {
            foreach (var item in lessonLecturers)
            {
                LessonLecturer update = new LessonLecturer
                {
                    LessonId = item.LessonId,
                    LecturerId = item.LecturerId,
                    IsDeleted = true
                };
                _dbFactory.DbContext.Attach(update);
                _dbFactory.DbContext.Entry(update).Property(i => i.IsDeleted).IsModified = true;
            }
        }

        public void RemoveStudents(List<LessonStudent> lessonStudents)
        {
            foreach (var item in lessonStudents)
            {
                LessonStudent update = new LessonStudent
                {
                    LessonId = item.LessonId,
                    StudentId = item.StudentId,
                    IsDeleted = true
                };
                _dbFactory.DbContext.Attach(update);
                _dbFactory.DbContext.Entry(update).Property(i => i.IsDeleted).IsModified = true;
            }
        }

    }
}
