using DiegoOrdonezBecerril_18300218_RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Pages.Profesores
{
    public class EditModel : PageModel
    {
        public readonly ApplicationDbContext _db;
        [BindProperty]
        public Profesor Profesor { get; set; }
        public SelectList OpcionesSexo;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;

            List<string> opciones = new List<string>();

            opciones.Add("MASCULINO");
            opciones.Add("FEMENINO");

            OpcionesSexo = new SelectList(opciones);
        }

        public async Task OnGet(int id)
        {
            Profesor = await _db.Profesor.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var ProfesorDb = await _db.Profesor.FindAsync(Profesor.Id);
                
                ProfesorDb.Nombre = Profesor.Nombre;
                ProfesorDb.FechaNacimiento = Profesor.FechaNacimiento;
                ProfesorDb.Sexo = Profesor.Sexo;

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
