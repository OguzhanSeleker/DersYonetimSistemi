using DYS.WebClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DYS.WebClient.Services
{
    public interface IUserService 
    {
        Task<UserViewModel> GetUser();
        Task<UserViewModel> GetUserById(string id);
    }
}
