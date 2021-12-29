using DYS.WebClient.Models;
using DYS.WebClient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.ControllerBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DYS.WebClient.Controllers
{

    public class AuthController : Controller
    {
        private readonly IIdentityService _identityService;

        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SigninInput signinInput)
        {
            if (!ModelState.IsValid) return View();

            var response = await _identityService.SignIn(signinInput);
            if (!response.Success)
            {
                ModelState.AddModelError("error",response.ErrorMessage);
                return View();
            }

            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
