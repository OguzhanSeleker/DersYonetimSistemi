using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DYS.WebClient.Models
{
    public class UserViewModel
    {
        public const string TeacherRole = "576fd394-0b9e-4558-85c9-d060577841a8";
        public const string StudentRole = "274ebda3-619e-481b-b730-6893a108c6d8";
        public const string AsistantRole = "c96d7ead-6ca4-4244-be2f-ddc50776d11d";
        public const string AdminRole = "68c0b232-219e-4d50-b4cc-001e47585a4c";
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
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
