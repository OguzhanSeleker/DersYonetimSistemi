using DYS.WebClient.Handler;
using DYS.WebClient.Services;
using DYS.WebClient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using SharedLibrary.Services;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace DYS.WebClient.Filters
{
    public class IsUserInCourseFilterAttribute : ActionFilterAttribute
    {
        private readonly ILessonService _lessonService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public IsUserInCourseFilterAttribute(ILessonService lessonService, ISharedIdentityService sharedIdentityService)
        {
            _lessonService = lessonService;
            _sharedIdentityService = sharedIdentityService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var param = context.ActionArguments.Where(i => i.Key == "id").FirstOrDefault();
            var test = _lessonService.IsUserInCourse(param.Value.ToString(), _sharedIdentityService.GetUserId).Result;
            if(!test)
            {
                context.HttpContext.Response.StatusCode = 401;
                return;
            }
            base.OnActionExecuting(context);    
        }


    }
}
