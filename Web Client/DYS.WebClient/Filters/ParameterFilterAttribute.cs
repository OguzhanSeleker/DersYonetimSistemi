using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace DYS.WebClient.Filters
{
    public class ParameterFilterAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var paramList = context.ActionArguments.
                ToList();
            foreach (var param in paramList)
            {
                if (param.Key == null && param.Value == null)
                {
                    context.Result = new BadRequestObjectResult("parameter is null");
                    return;
                }
                if (string.IsNullOrEmpty(param.Value.ToString()))
                {
                    context.Result = new BadRequestObjectResult("Parameter is empty");
                    return;
                }

                Guid id = Guid.Empty;
                Guid.TryParse(param.Value.ToString(), out id);
                if (id == Guid.Empty)
                {
                    context.Result = new BadRequestObjectResult("Parameter is not guid");
                    return;
                }
            }

        }
    }
}
