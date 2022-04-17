using MediatR;
using Services.Attendance.Application.Commands;
using Services.Attendance.Domain.Dtos;
using Services.Attendance.Domain.Entities;
using Services.Attendance.Domain.Mapping;
using Services.Attendance.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Attendance.Application.Handlers
{
    public class CreateStudentAttendanceCommandHandler : DbContextGenericHandler<AttendanceDbContext>, IRequestHandler<CreateStudentAttendanceCommand, GetStudentAttendanceDto>
    {
        public CreateStudentAttendanceCommandHandler(AttendanceDbContext context) : base(context)
        {
        }

        public async Task<GetStudentAttendanceDto> Handle(CreateStudentAttendanceCommand request, CancellationToken cancellationToken)
        {
            var entity = ObjectMapper.Mapper.Map<StudentAttendance>(request.AddStudentAttendanceDto);
            await _context.AddAsync(entity, cancellationToken);
            int save = await _context.SaveChangesAsync(cancellationToken);
            return save > 0 ? ObjectMapper.Mapper.Map<GetStudentAttendanceDto>(entity) : null;
        }
    }
}
