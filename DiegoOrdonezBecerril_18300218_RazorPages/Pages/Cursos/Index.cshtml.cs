using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiegoOrdonezBecerril_18300218_RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Pages.Cursos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<Curso> Cursos;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet()
        {
            Cursos = await _db.Curso.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var cursoDb = await _db.Curso.FindAsync(id);
            if (cursoDb is Curso)
            {
                _db.Curso.Remove(cursoDb);
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
