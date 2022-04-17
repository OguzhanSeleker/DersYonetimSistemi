using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Services.Survey.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Survey.API.Filters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var param = context.ActionArguments.FirstOrDefault(i => i.Value is IDto);
            if(param.Value == null)
            {
                context.Result = new BadRequestObjectResult("Model is Null");
                return;
            }
            if (!context.ModelState.IsValid)
                context.Result = new BadRequestObjectResult(context.ModelState);
        }
    }
}
