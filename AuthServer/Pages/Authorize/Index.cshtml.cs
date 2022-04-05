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
        //    string UserName = User.Identity.Name.ToString();
            var token = await TokenService.GetBearerTokenAsync();
        }
    }
}
