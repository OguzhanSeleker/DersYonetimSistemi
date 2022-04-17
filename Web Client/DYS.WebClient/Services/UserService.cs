using DYS.WebClient.Models;
using Newtonsoft.Json;
using SharedLibrary.ResponseDtos;
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
            var response = await _client.GetAsync($"/api/User/GetById/{id}");
            if (!response.IsSuccessStatusCode)
                return null;
            string str = await response.Content.ReadAsStringAsync();
            var usrmodel = JsonConvert.DeserializeObject<OperationResult<UserViewModel>>(str);
            return usrmodel.Data;
        }

        public async Task<UserViewModel> GetByUsername(string username)
        {
            var response = await _client.GetAsync($"/api/User/GetByUsername/{username}");
            if (!response.IsSuccessStatusCode)
                return null;
            string str = await response.Content.ReadAsStringAsync();
            var usrmodel = JsonConvert.DeserializeObject<OperationResult<UserViewModel>>(str);
            return usrmodel.Data;
        }
    }
}
