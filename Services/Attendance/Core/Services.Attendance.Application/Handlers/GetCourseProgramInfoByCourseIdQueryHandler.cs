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
    public class GetCourseProgramInfoByCourseIdQueryHandler : DbContextGenericHandler<AttendanceDbContext>, IRequestHandler<GetCourseProgramInfoByCourseIdQuery, GetCourseProgramInfoDto>
    {
        public GetCourseProgramInfoByCourseIdQueryHandler(AttendanceDbContext context) : base(context)
        {
        }

        public async Task<GetCourseProgramInfoDto> Handle(GetCourseProgramInfoByCourseIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.CourseProgramInfos.Where(i => i.CourseId == request.CourseId && !i.Deleted).ToListAsync();
            if (entity != null ? entity.Count > 1 : true) return null;
            return ObjectMapper.Mapper.Map<GetCourseProgramInfoDto>(entity.FirstOrDefault());
        }
    }
}
