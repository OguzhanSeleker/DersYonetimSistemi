using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DYS.WebClient.Models
{
    public class UserViewModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("userName")]
        public string UserName { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("roles")]
        public IList<string> Roles { get; set; }
        public string FullName
        {
            get => FirstName + " " + LastName;
        }

        public IEnumerable<string> getUserProps()
        {
            yield return UserName;
            yield return Email;
            yield return FirstName;
            yield return LastName;
        }
        public UserViewModel()
        {

        }
    }
}
