using DiegoOrdonezBecerril_18300218_RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Pages.ProfesorCursos
{
    public class CreateModel : PageModel
    {
        public readonly ApplicationDbContext _db;
        [BindProperty]
        public ProfesorToCurso ProfesorToCurso { get; set; }
        public SelectList Profesores { get; set; }
        public SelectList Cursos { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;

            var listProfesores = _db.Profesor.ToList();
            var listCursos = _db.Curso.ToList();

            Profesores = new SelectList(listProfesores, nameof(Profesor.Id), nameof(Profesor.Nombre));
            Cursos = new SelectList(listCursos, nameof(Curso.Id), nameof(Curso.Nombre));
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                int isInDb = _db.ProfesorToCurso.Where(p2c => p2c.ProfesorId == ProfesorToCurso.ProfesorId && p2c.CursoId == ProfesorToCurso.CursoId).Count();
                if (isInDb == 0)
                {
                    _db.Add(ProfesorToCurso);
                    await _db.SaveChangesAsync();
                    return RedirectToPage("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Ese curso ya es impartido por ese profesor");
                    return Page();
                }
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
