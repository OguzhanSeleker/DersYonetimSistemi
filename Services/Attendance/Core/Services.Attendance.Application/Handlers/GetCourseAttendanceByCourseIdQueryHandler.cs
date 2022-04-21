using MediatR;
using Microsoft.EntityFrameworkCore;
using Services.Attendance.Application.Queries;
using Services.Attendance.Domain.Dtos;
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
    public class GetCourseAttendanceByCourseIdQueryHandler : DbContextGenericHandler<AttendanceDbContext>, IRequestHandler<GetCourseAttendanceByCourseIdQuery, List<GetCourseAttendanceDto>>
    {
        public GetCourseAttendanceByCourseIdQueryHandler(AttendanceDbContext context) : base(context)
        {
        }

        public async Task<List<GetCourseAttendanceDto>> Handle(GetCourseAttendanceByCourseIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.CourseAttendances.Where(i => i.CourseId == request.CourseId && !i.Deleted).ToListAsync();

            return res == null ? null : ObjectMapper.Mapper.Map<List<GetCourseAttendanceDto>>(res);
        }
    }
}
