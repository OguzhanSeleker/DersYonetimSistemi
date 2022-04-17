using DYS.WebClient.Models;
using IdentityModel.Client;
using SharedLibrary.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DYS.WebClient.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<OperationResult<bool>> SignIn(SigninInput signinInput);
        Task<TokenResponse> GetAccessTokenByRefreshToken();
        Task RevokeRefreshToken();
    }
}
