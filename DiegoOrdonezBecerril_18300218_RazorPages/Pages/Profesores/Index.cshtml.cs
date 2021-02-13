using DiegoOrdonezBecerril_18300218_RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Pages.Profesores
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<Profesor> Profesores;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet()
        {
            Profesores = await _db.Profesor.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var ProfesorDb = await _db.Profesor.FindAsync(id);
            if (ProfesorDb is Profesor)
            {
                _db.Profesor.Remove(ProfesorDb);
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
