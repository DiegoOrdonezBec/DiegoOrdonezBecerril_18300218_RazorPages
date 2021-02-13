using DiegoOrdonezBecerril_18300218_RazorPages.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Pages.Auth
{
    public class SignupModel : PageModel
    {
        public readonly ApplicationDbContext _db;

        [BindProperty]
        public User Usuario { get; set; }

        public SignupModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGet()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Index");
            }
            else
            {
                return Page();
            }

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                int isInDb = _db.User.Where(user => user.NombreUsuario.Equals(Usuario.NombreUsuario)).Count();
                if (isInDb == 0)
                {
                    _db.Add(Usuario);
                    _db.SaveChanges();

                    Usuario = _db.User.Where(user => user.NombreUsuario.Equals(Usuario.NombreUsuario)).FirstOrDefault();

                    await this.SignInUser(Usuario.NombreUsuario);
                    return RedirectToPage("/Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Duplicaded username");
                    return Page();
                }
            }
            else
            {
                return Page();
            }

        }

        private async Task SignInUser(string username)
        {
            var claims = new List<Claim>();

            try
            {
                claims.Add(new Claim(ClaimTypes.Name, username));
                var claimIdenties = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimPrincipal = new ClaimsPrincipal(claimIdenties);
                var authenticationManager = Request.HttpContext;

                await authenticationManager.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
