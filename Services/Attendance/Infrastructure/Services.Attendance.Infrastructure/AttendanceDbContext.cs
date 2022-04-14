using Microsoft.EntityFrameworkCore;
using Services.Attendance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Attendance.Infrastructure
{
    public class AttendanceDbContext : DbContext
    {
        public AttendanceDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }
        public DbSet<CourseProgramInfo> CourseProgramInfos { get; set; }
        public DbSet<CourseAttendance> CourseAttendances { get; set; }
        public DbSet<StudentAttendance> StudentAttendances { get; set; }
    }
}
