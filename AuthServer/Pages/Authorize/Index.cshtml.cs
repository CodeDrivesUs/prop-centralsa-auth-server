using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthServer.Pages.Authorize
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public void OnGet(string connectionId)
        {
        }
    }
}
