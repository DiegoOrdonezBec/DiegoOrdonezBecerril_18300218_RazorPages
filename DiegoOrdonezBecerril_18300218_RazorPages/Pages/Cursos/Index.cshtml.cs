using DiegoOrdonezBecerril_18300218_RazorPages.Data;
using DiegoOrdonezBecerril_18300218_RazorPages.Models;
using Firebase.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Pages.Cursos
{
    public class IndexModel : PageModel
    {
        private readonly FirebaseClient FirebaseClient;
        private readonly ApplicationDbContext _db;
        public IEnumerable<Curso> Cursos;

        public IndexModel(ApplicationDbContext db, FirebaseClient firebaseClient)
        {
            _db = db;
            FirebaseClient = firebaseClient;
        }

        public async Task OnGet()
        {
            Cursos = await _db.Curso.ToListAsync();
            IReadOnlyCollection<FirebaseObject<CursoF>> lista = await FirebaseClient.Child("Cursos").OnceAsync<CursoF>();
            var curso = new CursoF();
            await FirebaseClient.Child("Cursos").PostAsync(JsonSerializer.Serialize(curso));
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var CursoDb = await _db.Curso.FindAsync(id);
            if (CursoDb is Curso)
            {
                _db.Curso.Remove(CursoDb);
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
