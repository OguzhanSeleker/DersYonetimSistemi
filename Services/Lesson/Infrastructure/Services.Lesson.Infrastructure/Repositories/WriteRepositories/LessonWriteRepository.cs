using Services.Lesson.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Lesson.Infrastructure.Repositories
{
    public class LessonWriteRepository : WriteRepository<Domain.Entities.Lesson>, ILessonWriteRepository
    {
        public LessonWriteRepository(LessonServiceDbContext context) : base(context)
        {
        }
    }
}
