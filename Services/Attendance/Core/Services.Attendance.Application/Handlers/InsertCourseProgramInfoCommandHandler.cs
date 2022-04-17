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
    public class InsertCourseProgramInfoCommandHandler : DbContextGenericHandler<AttendanceDbContext>, IRequestHandler<InsertCourseProgramInfoCommand, GetCourseProgramInfoDto>
    {
        public InsertCourseProgramInfoCommandHandler(AttendanceDbContext context) : base(context)
        {
        }

        public async Task<GetCourseProgramInfoDto> Handle(InsertCourseProgramInfoCommand request, CancellationToken cancellationToken)
        {
            var cProgInfo = new CourseProgramInfo
            {
                CourseId = request.CourseId,
                CreatedDate = DateTime.UtcNow,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Deleted = false,

            };
            await _context.CourseProgramInfos.AddAsync(cProgInfo);
            int save = await _context.SaveChangesAsync(cancellationToken);
            return save > 0 ? ObjectMapper.Mapper.Map<GetCourseProgramInfoDto>(cProgInfo) : null;
        }
    }
}
