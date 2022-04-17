using IdentityModel.Client;
using SharedLibrary.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RabbitMQ.Consumer.Services
{
    public interface IIdentityService
    {
        Task<OperationResult<bool>> SignInForWorker();
        Task<TokenResponse> GetAccessTokenByRefreshToken();
        Task RevokeRefreshToken();
    }
}
