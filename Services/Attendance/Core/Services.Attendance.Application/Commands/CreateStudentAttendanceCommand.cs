using MediatR;
using Services.Attendance.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Attendance.Application.Commands
{
    public class CreateStudentAttendanceCommand : IRequest<GetStudentAttendanceDto>
    {
        public AddStudentAttendanceDto AddStudentAttendanceDto { get; set; }
    }
}
