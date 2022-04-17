using DYS.AuthServer.Dtos;
using DYS.AuthServer.Models;
using IdentityModel;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DYS.AuthServer.Services
{
    public class IdentityResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityResourceOwnerPasswordValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var existUser = await _userManager.FindByNameAsync(context.UserName);
            if (existUser == null)
            {
                var errors = new Dictionary<string, object>();
                errors.Add("errors", new List<string> { "kullanıcı Adı veya şifreniz hatalı" });

                context.Result.CustomResponse = errors;
                return;
            }

            var passwordCheck = await _userManager.CheckPasswordAsync(existUser, context.Password);
            if (passwordCheck == false)
            {
                var errors = new Dictionary<string, object>();
                errors.Add("errors", new List<string> { "kullanıcı Adı veya şifreniz hatalı" });

                context.Result.CustomResponse = errors;
                return;
            }
            GetUserDto userDto = new GetUserDto
            {
                Id = existUser.Id,
                Email = existUser.Email,
                FirstName = existUser.FirstName,
                LastName = existUser.LastName,
                UserName = existUser.UserName,
                Roles = await _userManager.GetRolesAsync(existUser)
            };
            context.Result = new GrantValidationResult(existUser.Id.ToString(), OidcConstants.AuthenticationMethods.Password,GetUserClaims(userDto));
        }

        public static Claim[] GetUserClaims(GetUserDto user)
        {
            List<Claim> claimList = new List<Claim>
            {
            new Claim("user_id", user.Id.ToString() ?? ""),
            new Claim(JwtClaimTypes.Name, (!string.IsNullOrEmpty(user.FirstName) && !string.IsNullOrEmpty(user.LastName)) ? (user.FirstName + " " + user.LastName) : ""),
            new Claim(JwtClaimTypes.GivenName, user.FirstName  ?? ""),
            new Claim(JwtClaimTypes.FamilyName, user.LastName  ?? ""),
            new Claim(JwtClaimTypes.Email, user.Email  ?? ""),

            };
            user.Roles.ToList().ForEach(x => claimList.Add(new Claim(JwtClaimTypes.Role, x)));

            return claimList.ToArray();
        }
    }
}
