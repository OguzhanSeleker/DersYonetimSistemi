using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DYS.WebClient.Models
{
    public class ClientSettings
    {
        public Client WebClientForUser { get; set; }
    }
    public class Client
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
