using Microsoft.AspNetCore.Mvc;
using SharedLibrary.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.ControllerBases
{
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResultInstance<T>(OperationResult<T> result)
        {
            return new ObjectResult(result)
            {
                StatusCode = ((int)result.StatusCode)
            };
        }
        [NonAction]
        public IActionResult ReturnError() => CreateActionResultInstance(OperationResult<NoContent>.CreateFailure("Could Not Added or Updated or Deleted", ResponseDtos.StatusCode.Error));
        [NonAction]
        public IActionResult ReturnNotFound() => CreateActionResultInstance(OperationResult<NoContent>.CreateFailure("Could Not Found", ResponseDtos.StatusCode.NotFound));
        [NonAction]
        public IActionResult ReturnCreated<T>(T Dto) => CreateActionResultInstance<T>(OperationResult<T>.CreatedSuccessResult(Dto));
        [NonAction]
        public IActionResult ReturnCreated() => CreateActionResultInstance(OperationResult<NoContent>.CreatedSuccessResult());
        [NonAction]
        public IActionResult ReturnOk<T>(T Dto) => CreateActionResultInstance(OperationResult<T>.OkSuccessResult(Dto));
        [NonAction]
        public IActionResult ReturnBadMessage(string message) => CreateActionResultInstance(OperationResult<NoContent>.CreateFailure(message, ResponseDtos.StatusCode.BadRequest));
        [NonAction]
        public IActionResult ReturnSuccess() => CreateActionResultInstance(OperationResult<NoContent>.NoContentSuccessResult());
       


    }
}
