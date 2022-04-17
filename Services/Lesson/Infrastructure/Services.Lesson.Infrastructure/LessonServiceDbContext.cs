using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Lesson.Infrastructure
{
    public class LessonServiceDbContext : DbContext
    {
        public LessonServiceDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
        public DbSet<Domain.Entities.Lesson> Lessons { get; set; }
        public DbSet<Domain.Entities.Course> Courses { get; set; }
        public DbSet<Domain.Entities.CourseUser> CourseUsers { get; set; }
        public DbSet<Domain.Entities.RoleInCourse> RoleInCourses { get; set; }
        public DbSet<Domain.Entities.TimePlace> TimePlaces { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries<Domain.Entities.Base.BaseEntity>();
            foreach (var entity in entities)
            {
                switch (entity.State)
                {
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        entity.Entity.Deleted = true;
                        entity.Entity.DeletedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entity.Entity.UpdatedDate = DateTime.Now;
                        
                        break;
                    case EntityState.Added:
                        entity.Entity.CreatedDate = DateTime.Now;
                        entity.Entity.UpdatedDate = null;
                        entity.Entity.Deleted = false;
                        entity.Entity.DeletedDate = null;
                        entity.Entity.UpdatedBy = null;
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);    
        }
    }
}
