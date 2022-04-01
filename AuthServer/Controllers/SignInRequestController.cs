using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SignInRequestController: ControllerBase
    {
        private readonly ILogger<SignInRequestController> _logger;

        public SignInRequestController(ILogger<SignInRequestController> logger)
        {
            _logger = logger;
        }
    }
}
