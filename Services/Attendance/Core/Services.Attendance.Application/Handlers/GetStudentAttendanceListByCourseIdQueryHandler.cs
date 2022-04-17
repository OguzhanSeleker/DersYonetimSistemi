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
    public class GetStudentAttendanceListByCourseIdQueryHandler : DbContextGenericHandler<AttendanceDbContext>, IRequestHandler<GetStudentAttendanceListByCourseIdQuery, List<GetStudentAttendanceDto>>
    {
        public GetStudentAttendanceListByCourseIdQueryHandler(AttendanceDbContext context) : base(context)
        {
        }

        public async Task<List<GetStudentAttendanceDto>> Handle(GetStudentAttendanceListByCourseIdQuery request, CancellationToken cancellationToken)
        {
            var entityList = await _context.StudentAttendances.Include(i => i.CourseAttendance).Where(i => i.CourseAttendance.CourseId == request.CourseId && !i.Deleted && !i.CourseAttendance.Deleted).ToListAsync();
            return entityList != null ? ObjectMapper.Mapper.Map<List<GetStudentAttendanceDto>>(entityList) : null;
                }
    }
}
