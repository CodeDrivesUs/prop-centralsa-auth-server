using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.SignalRHubs
{
    public class signInConnection : Hub
    {
        private readonly IHubContext<signInConnection> _context;

        public signInConnection(IHubContext<signInConnection> context)
        {
            _context = context;
        }

        public override Task OnConnectedAsync()
        {
            _context.Clients.Client(Context.ConnectionId).SendAsync("connected", Context.ConnectionId);

            return base.OnConnectedAsync();
        }
    }
}
