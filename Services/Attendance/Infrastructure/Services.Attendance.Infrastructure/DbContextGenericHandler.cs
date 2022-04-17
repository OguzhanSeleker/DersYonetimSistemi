using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Attendance.Infrastructure
{
    public class DbContextGenericHandler<TContext> where TContext : DbContext
    {
        protected readonly TContext _context;

        public DbContextGenericHandler(TContext context)
        {
            _context = context;
        }
    }
}
