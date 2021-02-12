using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiegoOrdonezBecerril_18300218_RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Pages.Cursos
{
    public class EditModel : PageModel
    {
        public readonly ApplicationDbContext _db;
        [BindProperty]
        public Curso Curso { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet(int id)
        {
            Curso = await _db.Curso.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var CursoDb = await _db.Curso.FindAsync(Curso.Id);
                
                CursoDb.Nombre = Curso.Nombre;
                CursoDb.Cantidad = Curso.Cantidad;
                CursoDb.Precio = Curso.Precio;
                
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
