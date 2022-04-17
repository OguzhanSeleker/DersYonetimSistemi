using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DYS.WebClient.Models
{
    public class ServiceApiSettings
    {
        public string IdentityBaseUri { get; set; }
        public string GatewayBaseUri { get; set; }
        public ServiceApi Lesson { get; set; }
        public ServiceApi Message { get; set; }
        public ServiceApi Notification { get; set; }
        public ServiceApi Survey { get; set; }
        public ServiceApi FileSystem { get; set; }
    }
    public class ServiceApi
    {
        public string Path { get; set; }
    }
}
