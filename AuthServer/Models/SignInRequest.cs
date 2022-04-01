using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Models
{
    public class SignInRequest
    {
        public string connectionId { get; set; }
        public string  ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
