using Services.Lesson.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Lesson.Infrastructure.Repositories
{
    public class LessonReadRepository : ReadRepository<Domain.Entities.Lesson>, ILessonReadRepository
    {
        public LessonReadRepository(LessonServiceDbContext context) : base(context)
        {
        }
    }
}
