using DiegoOrdonezBecerril_18300218_RazorPages.DataModels;
using DiegoOrdonezBecerril_18300218_RazorPages.Models;
using Firebase.Database;
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
        private readonly FirebaseClient firebaseClient;
        public List<ProfesorFToCursoF> ProfesoresFToCursosF;

        public IndexModel(FirebaseClient firebaseClient)
        {
            this.firebaseClient = firebaseClient;
            ProfesoresFToCursosF = new List<ProfesorFToCursoF>();
        }

        public async Task OnGet()
        {
            IReadOnlyCollection<FirebaseObject<ProfesorFToCursoF>> profesoresFToCursosF = await firebaseClient.Child("ProfesorToCurso").OnceAsync<ProfesorFToCursoF>();

            foreach (FirebaseObject<ProfesorFToCursoF> firebaseObject in profesoresFToCursosF)
            {
                ProfesorFToCursoF profesorFToCursoF = firebaseObject.Object;
                profesorFToCursoF.Key = firebaseObject.Key;
                ProfesoresFToCursosF.Add(profesorFToCursoF);
            }
        }

        public async Task<IActionResult> OnPostDelete(string key)
        {
            await firebaseClient.Child("ProfesorToCurso/" + key + "/").DeleteAsync();
            return RedirectToPage("Index");
        }
    }
}
