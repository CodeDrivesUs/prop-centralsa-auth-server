using AuthServer.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace AuthServer.Pages.Account
{
    public class LogoutModel : PageModel
    {
  
        public virtual async Task<IActionResult> OnGetAsync()
        {
            await HttpContext.SignOutAsync("Cookies");
            await HttpContext.SignOutAsync("oidc");
            return RedirectPermanent($"{AppSettings.AuthorityUrl}/Account/Logout/");
        }
    }
}
