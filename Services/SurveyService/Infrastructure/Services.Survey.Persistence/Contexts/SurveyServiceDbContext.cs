using Microsoft.EntityFrameworkCore;
using Services.Survey.Domain.Entities;
using Services.Survey.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Survey.Persistence.Contexts
{
    public class SurveyServiceDbContext : DbContext
    {
        public SurveyServiceDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<AnswerType> AnswerTypes { get; set; }
        public DbSet<MainSurvey> MainSurveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionContent> QuestionContents { get; set; }

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
