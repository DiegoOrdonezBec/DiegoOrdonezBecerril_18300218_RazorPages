using DiegoOrdonezBecerril_18300218_RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Pages.ProfesorCursos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<ProfesorToCurso> ProfesoresToCursos;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet()
        {
            IQueryable<ProfesorToCurso> query = from p in _db.Profesor join p2c in _db.ProfesorToCurso on p.Id equals p2c.ProfesorId join c in _db.Curso on p2c.CursoId equals c.Id orderby p.Nombre select new ProfesorToCurso(p,c);
            ProfesoresToCursos = await query.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int profesor, int curso)
        {
            var ProfesorToCurso = _db.ProfesorToCurso.Where(p2c => p2c.ProfesorId == profesor && p2c.CursoId == curso).FirstOrDefault();
            if (ProfesorToCurso is ProfesorToCurso)
            {
                _db.ProfesorToCurso.Remove(ProfesorToCurso);
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
