using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DYS.AuthServer.Dtos
{
    public class GetUserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<string>  Roles { get; set; }
    }
}
