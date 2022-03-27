using DYS.AuthServer.Dtos;
using DYS.AuthServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.ControllerBases;
using SharedLibrary.ResponseDtos;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace DYS.AuthServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    //[Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDto signupDto)
        {
            var user = new ApplicationUser
            {
                UserName = signupDto.UserName,
                Email = signupDto.Email,
                FirstName = signupDto.FirstName,
                LastName = signupDto.LastName
            };
            var existRole = await _roleManager.RoleExistsAsync(signupDto.RoleName);
            if (!existRole) return CreateActionResultInstance(OperationResult<NoContent>.CreateFailure("Role Bulunamadı.", SharedLibrary.ResponseDtos.StatusCode.NotFound));
            var result = await _userManager.CreateAsync(user, signupDto.Password);
            if (!result.Succeeded)
            {
                return CreateActionResultInstance(OperationResult<NoContent>.CreateFailure("Kayıt olurken bir hata ile karşılaşıldı. " + result.Errors.FirstOrDefault().Description, SharedLibrary.ResponseDtos.StatusCode.Error));
            }
            var resultRole = await _userManager.AddToRoleAsync(user, signupDto.RoleName);
            if (!resultRole.Succeeded)
            {
                return CreateActionResultInstance(OperationResult<NoContent>.CreateFailure("Rol eklenirken bir hata ile karşılaşıldı. Mesaj : " + resultRole.Errors.FirstOrDefault().Description, SharedLibrary.ResponseDtos.StatusCode.Error));
            }

            return CreateActionResultInstance(OperationResult<NoContent>.CreatedSuccessResult());
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
            if (userIdClaim == null) return CreateActionResultInstance(OperationResult<NoContent>.CreateFailure("UserClaim Not Found", SharedLibrary.ResponseDtos.StatusCode.BadRequest));

            var user = await _userManager.FindByIdAsync(userIdClaim.Value);
            if (user == null) return CreateActionResultInstance(OperationResult<NoContent>.CreateFailure("UserClaim Not Found", SharedLibrary.ResponseDtos.StatusCode.BadRequest));
            var userRole = await _userManager.GetRolesAsync(user);
            return CreateActionResultInstance(OperationResult<GetUserDto>.OkSuccessResult(new GetUserDto { Id = user.Id, UserName = user.UserName, Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, Roles = userRole }));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            if (string.IsNullOrEmpty(id)) return ReturnBadMessage("parameter could not null");
            Guid userId = Guid.Empty;
            Guid.TryParse(id,out userId);
            if (userId == Guid.Empty) return ReturnBadMessage("id is not guid");
            //return ReturnError();
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return ReturnNotFound();
            var userRole = await _userManager.GetRolesAsync(user);
            return CreateActionResultInstance(OperationResult<GetUserDto>.OkSuccessResult(new GetUserDto { Id = user.Id, UserName = user.UserName, Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, Roles = userRole }));
        }
    }
}
