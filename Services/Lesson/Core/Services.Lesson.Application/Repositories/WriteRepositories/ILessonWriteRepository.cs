using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Lesson.Application.Repositories
{
    public interface ILessonWriteRepository : IWriteRepository<Domain.Entities.Lesson>
    {
    }
}
