using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Lesson.Infrastructure
{
    public abstract class DbContextGenericHandler<T> where T : DbContext
    {
        protected readonly DbContext _context;

        protected DbContextGenericHandler(DbContext context)
        {
            _context = context;
        }
    }
}
