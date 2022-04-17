using MediatR;
using Services.Attendance.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Attendance.Application.Commands
{
    public class InsertCourseAttendanceListCommand : IRequest<List<GetCourseAttendanceDto>>
    {
        public List<AddCourseAttendanceDto> AddCourseAttendanceDtos { get; set; }
    }
}
