using MediatR;
using Services.Attendance.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Attendance.Application.Commands
{
    public class InsertCourseProgramInfoQuery : IRequest<GetCourseProgramInfoDto>
    {
        public Guid CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
