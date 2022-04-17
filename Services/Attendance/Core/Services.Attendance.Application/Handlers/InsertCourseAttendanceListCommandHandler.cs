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
    public class InsertCourseAttendanceListCommandHandler : DbContextGenericHandler<AttendanceDbContext>, IRequestHandler<InsertCourseAttendanceListCommand, List<GetCourseAttendanceDto>>
    {
        public InsertCourseAttendanceListCommandHandler(AttendanceDbContext context) : base(context)
        {
        }

        public async Task<List<GetCourseAttendanceDto>> Handle(InsertCourseAttendanceListCommand request, CancellationToken cancellationToken)
        {
            var entities = ObjectMapper.Mapper.Map<List<CourseAttendance>>(request.AddCourseAttendanceDtos);
            await _context.Set<CourseAttendance>().AddRangeAsync(entities);
            int save = await _context.SaveChangesAsync(cancellationToken);
            return save > 0 ? ObjectMapper.Mapper.Map<List<GetCourseAttendanceDto>>(entities) : null; 
        }
    }
}
