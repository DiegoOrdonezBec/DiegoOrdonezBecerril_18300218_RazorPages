using DiegoOrdonezBecerril_18300218_RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Pages.Usuarios
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<User> Usuarios;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet()
        {
            Usuarios = await _db.User.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var UsuarioDb = await _db.User.FindAsync(id);
            if (UsuarioDb is User)
            {
                _db.User.Remove(UsuarioDb);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
