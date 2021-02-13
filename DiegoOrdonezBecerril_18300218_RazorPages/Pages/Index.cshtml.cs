using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        public async Task OnGet()
        {
            
        }

        public async Task<IActionResult> OnPost()
        {
            var authenticationManager = Request.HttpContext;
            await authenticationManager.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Auth/Login");
        }
    }
}
