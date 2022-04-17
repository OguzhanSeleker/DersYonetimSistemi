using MediatR;
using Services.Attendance.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Attendance.Application.Queries
{
    public class GetCourseAttendanceListByCourseIdQuery : IRequest<List<GetCourseAttendanceDto>>
    {
        public Guid CourseId { get; set; }
    }
}
