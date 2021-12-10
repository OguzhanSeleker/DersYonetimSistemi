using Lesson.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Infrastructure
{
    public class LessonDbContext : DbContext
    {
        public DbSet<Domain.Aggregates.Lesson> Lessons { get; set; }
        public DbSet<LessonCode> LessonCodes { get; set; }
        public DbSet<TimeDayRoom> TimeDayRooms { get; set; }
        public DbSet<LessonLecturer> LessonLecturers { get; set; }
        public DbSet<LessonAssistant> LessonAssistants { get; set; }
        public DbSet<LessonStudent> LessonStudents { get; set; }
        public LessonDbContext(DbContextOptions<LessonDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
