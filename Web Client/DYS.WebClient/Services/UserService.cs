using DYS.WebClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DYS.WebClient.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _client;

        public UserService(HttpClient client)
        {
            _client = client;
        }

        public async Task<UserViewModel> GetUser()
        {
            return await _client.GetFromJsonAsync<UserViewModel>("/api/user/getuser");
        }

        public async Task<UserViewModel> GetUserById(string id)
        {
            var response = await _client.GetAsync($"/api/User/GetUserById/{id}");
            if (!response.IsSuccessStatusCode)
                return null;
            var usrmodel = await response.Content.ReadFromJsonAsync<UserViewModel>();
            return usrmodel;
        }
    }
}
