using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthServer.SignalRHubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using AuthServer.Services;
using System.Security.Claims;
using AuthServer.Models;

namespace AuthServer.Pages.Authorize
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IHubContext<signInConnection> _context;
        public IndexModel(IHubContext<signInConnection> context)
        {
            _context = context;
        }

        public async Task OnGetAsync(string connectionId)
        {
      
           await _context.Clients.Client(connectionId).SendAsync("signInSuccess", new SingInResponse { 
               access_token= await TokenService.GetBearerTokenAsync(),
               userName = User.FindFirstValue(ClaimTypes.Email)
           });

        }
    }
}
