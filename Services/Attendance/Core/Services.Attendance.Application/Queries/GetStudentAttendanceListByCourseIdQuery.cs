using MediatR;
using Services.Attendance.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Attendance.Application.Queries
{
    public class GetStudentAttendanceListByCourseIdQuery : IRequest<List<GetStudentAttendanceDto>>
    {
        public Guid CourseId { get; set; }
    }
}
