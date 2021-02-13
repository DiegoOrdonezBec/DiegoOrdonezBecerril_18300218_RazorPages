using DiegoOrdonezBecerril_18300218_RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Pages.Profesores
{
    public class CreateModel : PageModel
    {
        public readonly ApplicationDbContext _db;
        [BindProperty]
        public Profesor Profesor { get; set; }
        public SelectList OpcionesSexo;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;

            List<string> opciones = new List<string>();

            opciones.Add("MASCULINO");
            opciones.Add("FEMENINO");

            OpcionesSexo = new SelectList(opciones);
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Add(Profesor);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
            
        }
    }
}
