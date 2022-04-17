using Services.Lesson.Application.Repositories;
using Services.Lesson.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Lesson.Infrastructure.Repositories
{
    public class RoleInCourseReadRepository : ReadRepository<RoleInCourse>, IRoleInCourseReadRepository
    {
        public RoleInCourseReadRepository(LessonServiceDbContext context) : base(context)
        {
        }
    }
}
