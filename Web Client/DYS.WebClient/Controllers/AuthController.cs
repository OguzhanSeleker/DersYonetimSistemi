﻿using DYS.WebClient.Models;
using DYS.WebClient.Services;
using DYS.WebClient.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
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

        public AuthController(IUserService userService, ISharedIdentityService sharedIdentityService, IIdentityService identityService) : base(userService, sharedIdentityService)
        {
            _identityService = identityService;
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

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await _identityService.RevokeRefreshToken();
            return RedirectToAction(nameof(HomeController.Index), "Home");

        }
    }
}
