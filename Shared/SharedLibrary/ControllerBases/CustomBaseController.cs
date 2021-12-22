using Microsoft.AspNetCore.Mvc;
using SharedLibrary.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.ControllerBases
{
    public class CustomBaseController : ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(OperationResult<T> result)
        {
            return new ObjectResult(result)
            {
                StatusCode = ((int)result.StatusCode)
            };
        }
    }
}
