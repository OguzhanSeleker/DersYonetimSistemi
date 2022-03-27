using DYS.WebClient.Models;
using DYS.WebClient.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharedLibrary.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DYS.WebClient.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IUserService userService, ISharedIdentityService sharedIdentityService) : base(userService, sharedIdentityService)
        {
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Lesson");
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Roles ="Admin")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
