using Lesson.Domain.Aggregates;
using Lesson.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Infrastructure.Repositories
{
    public class LessonCodeRepository : Repository<LessonCode>, ILessonCodeRepository
    {
        public LessonCodeRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
