using MediatR;
using Services.Attendance.Application.Commands;
using Services.Attendance.Domain.Dtos;
using Services.Attendance.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Attendance.Application.Handlers
{
    public class InsertCourseProgramInfoQueryHandler : DbContextGenericHandler<AttendanceDbContext> IRequestHandler<InsertCourseProgramInfoQuery, GetCourseProgramInfoDto>
    {
        public InsertCourseProgramInfoQueryHandler(AttendanceDbContext context) : base(context)
        {
        }

        public Task<GetCourseProgramInfoDto> Handle(InsertCourseProgramInfoQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
