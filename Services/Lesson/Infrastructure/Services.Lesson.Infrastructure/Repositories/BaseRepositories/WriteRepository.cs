using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Services.Lesson.Application.Repositories;
using Services.Lesson.Domain.Entities.Base;
using Services.Lesson.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Lesson.Infrastructure.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly LessonServiceDbContext _context;

        public WriteRepository(LessonServiceDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<T> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added ? entityEntry.Entity : null;
        }

        public async Task<bool> AddRangeAsync(List<T> modelList)
        {
            await Table.AddRangeAsync(modelList);
            return true;
        }

        public async Task RemoveAsync(string id)
        {
            T entity = await Table.FirstOrDefaultAsync(i => i.Id == Guid.Parse(id) & !i.Deleted);
            entity.Deleted = true;
        }

        public bool Update(T model)
        {
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

    }
}
