using Microsoft.EntityFrameworkCore;
using Services.Notification.Application.Repositories;
using Services.Notification.Domain.Entities.Common;
using Services.Notification.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Notification.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly NotificationServiceDbContext _context;

        public ReadRepository(NotificationServiceDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(i => !i.Deleted).Where(method).AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return await query.Where(i => !i.Deleted).FirstOrDefaultAsync(method);
        }

        public async Task<T> GetByIdAsync(string Id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(i => i.Id == Guid.Parse(Id) && !i.Deleted);
        }


    }
}
