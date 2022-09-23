using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Models
{
    public class SingInResponse
    {
        public string access_token { get; set; }
        public string userName { get; set; }
    }
}
