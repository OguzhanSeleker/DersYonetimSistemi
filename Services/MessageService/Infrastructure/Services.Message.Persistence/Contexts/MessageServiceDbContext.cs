using Microsoft.EntityFrameworkCore;
using Services.Message.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Message.Persistence.Contexts
{
    public class MessageServiceDbContext : DbContext
    {
        public MessageServiceDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Message.Domain.Entities.Message> Messages { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries<BaseEntity>();
            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.Deleted = false;
                    entity.Entity.CreatedDate = DateTime.UtcNow;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
