using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Attendance.Application.Commands;
using Services.Attendance.Application.Queries;
using Services.Attendance.Domain.Dtos;
using SharedLibrary.ControllerBases;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Attendance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendancesController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public AttendancesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Route("CreateCourseInfo")]
        public async Task<IActionResult> CreateCourseInfo(AddCourseProgramInfoDto addCourseProgramInfoDto)
        {
            var response = await _mediator.Send(new InsertCourseProgramInfoCommand { CourseId = addCourseProgramInfoDto.CourseId, EndDate = addCourseProgramInfoDto.EndDate,StartDate = addCourseProgramInfoDto.StartDate});
            if (response == null) return ReturnError();
            return ReturnCreated(response);
        }

        [HttpPost]
        [Route("CreateCourseAttendanceList")]
        public async Task<IActionResult> CreateCourseAttendanceList(List<AddCourseAttendanceDto> addCourseAttendanceDtos)
        {
            if(addCourseAttendanceDtos == null &&  (addCourseAttendanceDtos != null ? addCourseAttendanceDtos.Count == 0 : true)) return ReturnBadMessage("Model is null or empty");
            var getCourseProgram = await _mediator.Send(new GetCourseProgramInfoByCourseIdQuery { CourseId = addCourseAttendanceDtos[0].CourseId });
            if (getCourseProgram == null) return ReturnNotFound();
            addCourseAttendanceDtos.ForEach(i => i.CourseProgramInfoId = getCourseProgram.Id);
            var entities = await _mediator.Send(new InsertCourseAttendanceListCommand { AddCourseAttendanceDtos = addCourseAttendanceDtos });
            if(entities == null) return ReturnError();
            return ReturnCreated(entities);
        }

    }
}
