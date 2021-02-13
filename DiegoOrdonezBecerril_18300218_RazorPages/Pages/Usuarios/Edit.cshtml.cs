using DiegoOrdonezBecerril_18300218_RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Pages.Usuarios
{
    public class EditModel : PageModel
    {
        public readonly ApplicationDbContext _db;
        [BindProperty]
        public User Usuario { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet(int id)
        {
            Usuario = await _db.User.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var UsuarioDb = await _db.User.FindAsync(Usuario.Id);

                UsuarioDb.Nombre = Usuario.Nombre;
                UsuarioDb.NombreUsuario = Usuario.NombreUsuario;
                UsuarioDb.Password = Usuario.Password;

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
