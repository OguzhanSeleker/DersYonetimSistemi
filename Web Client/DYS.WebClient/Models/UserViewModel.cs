using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DYS.WebClient.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<string> Roles { get; set; }

        public IEnumerable<string> getUserProps()
        {
            yield return UserName;
            yield return Email;
            yield return FirstName;
            yield return LastName;
        }
    }
}
