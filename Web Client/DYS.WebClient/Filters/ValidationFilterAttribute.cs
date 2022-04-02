using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace DYS.WebClient.Filters
{
    public class ValidationFilterAttribute : IOrderedFilter
    {
        public int Order => 1;

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var param = context.ActionArguments.FirstOrDefault();
            if (param.Value == null)
            {
                context.Result = new BadRequestObjectResult("Model is Null");
                return;
            }
            if (!context.ModelState.IsValid)
                context.Result = new BadRequestObjectResult(context.ModelState);
        }
    }
}
