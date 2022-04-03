using DYS.WebClient.Models;
using DYS.WebClient.Services;
using DYS.WebClient.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharedLibrary.ControllerBases;
using SharedLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DYS.WebClient.Controllers
{

    public class AuthController : BaseController
    {
        private readonly IIdentityService _identityService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IUserService userService, ISharedIdentityService sharedIdentityService, IIdentityService identityService, ILogger<AuthController> logger) : base(userService, sharedIdentityService)
        {
            _identityService = identityService;
            _logger = logger;
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
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await _identityService.RevokeRefreshToken();
            return RedirectToAction(nameof(HomeController.Index), "Home");

        }
        [HttpGet]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            if (string.IsNullOrEmpty(username)) return BadRequest("kullanıcı adı geçerli değil");
            var user = await _userService.GetByUsername(username);
            if (user == null)
                return NotFound("Kişi bulunamadi");
            return Json(user);
        }
    }
}
