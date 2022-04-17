using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Attendance.Application.Commands
{
    public class AddStudentAttendanceMarkCommand : IRequest<bool>
    {
        public Guid StudentAttendanceId { get; set; }
        public bool Marked { get; set; }
    }
}
