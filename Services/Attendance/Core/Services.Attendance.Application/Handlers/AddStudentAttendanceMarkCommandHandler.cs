using MediatR;
using Services.Attendance.Application.Commands;
using Services.Attendance.Domain.Entities;
using Services.Attendance.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Attendance.Application.Handlers
{
    public class AddStudentAttendanceMarkCommandHandler : DbContextGenericHandler<AttendanceDbContext>, IRequestHandler<AddStudentAttendanceMarkCommand, bool>
    {
        public AddStudentAttendanceMarkCommandHandler(AttendanceDbContext context) : base(context)
        {
        }

        public async Task<bool> Handle(AddStudentAttendanceMarkCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.FindAsync<StudentAttendance>(request.StudentAttendanceId);
            if (entity == null) return false;
            entity.IsMarked = request.Marked;
            int save = await _context.SaveChangesAsync(cancellationToken);
            return save > 0;
        }
    }
}
