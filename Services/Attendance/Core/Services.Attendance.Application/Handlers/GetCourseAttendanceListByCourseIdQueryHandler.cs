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
    public class GetCourseAttendanceListByCourseIdQueryHandler : DbContextGenericHandler<AttendanceDbContext>, IRequestHandler<GetCourseAttendanceListByCourseIdQuery, List<GetCourseAttendanceDto>>
    {
        public GetCourseAttendanceListByCourseIdQueryHandler(AttendanceDbContext context) : base(context)
        {
        }

        public async Task<List<GetCourseAttendanceDto>> Handle(GetCourseAttendanceListByCourseIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _context.CourseAttendances.Include(i => i.CourseProgramInfoId).Where(i => i.CourseId == request.CourseId && !i.Deleted && !i.CourseProgramInfo.Deleted).ToListAsync();
            return entities != null ? ObjectMapper.Mapper.Map<List<GetCourseAttendanceDto>>(entities) : null;
        }
    }
}
