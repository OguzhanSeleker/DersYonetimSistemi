using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Attendance.Application.Commands;
using Services.Attendance.Domain.Dtos;
using SharedLibrary.ControllerBases;
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
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCourseInfo(AddCourseProgramInfoDto addCourseProgramInfoDto)
        {
            var response = await _mediator.Send(new InsertCourseProgramInfoCommand { CourseId = addCourseProgramInfoDto.CourseId, EndDate = addCourseProgramInfoDto.EndDate,StartDate = addCourseProgramInfoDto.StartDate});
            if (response == null) return ReturnError();
            return ReturnCreated(response);
        }
    }
}
