using Microsoft.EntityFrameworkCore;
using Services.Notification.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Notification.Persistence.Contexts
{
    public class NotificationServiceDbContext : DbContext
    {
        public NotificationServiceDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
        public DbSet<Domain.Entities.Notification> Notifications { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries<BaseEntity>();
            foreach (var entity in entities)
            {
                switch (entity.State)
                {
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        entity.Entity.UpdatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        entity.Entity.CreatedDate = DateTime.UtcNow;
                        entity.Entity.UpdatedDate = null;
                        entity.Entity.Deleted = false;
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
