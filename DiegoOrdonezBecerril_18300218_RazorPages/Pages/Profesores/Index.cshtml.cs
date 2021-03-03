using DiegoOrdonezBecerril_18300218_RazorPages.DataModels;
using Firebase.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Pages.Profesores
{
    public class IndexModel : PageModel
    {
        private readonly FirebaseClient firebaseClient;
        public List<ProfesorF> ProfesoresF;

        public IndexModel(FirebaseClient firebaseClient)
        {
            this.firebaseClient = firebaseClient;
            ProfesoresF = new List<ProfesorF>();
        }

        public async Task OnGet()
        {
            IReadOnlyCollection<FirebaseObject<ProfesorF>> profesoresF = await firebaseClient.Child("Profesor").OnceAsync<ProfesorF>();

            foreach (FirebaseObject<ProfesorF> firebaseObject in profesoresF)
            {
                ProfesorF profesorF = firebaseObject.Object;
                profesorF.Key = firebaseObject.Key;
                ProfesoresF.Add(profesorF);
            }
        }

        public async Task<IActionResult> OnPostDelete(string key)
        {
            await firebaseClient.Child("Profesor/" + key + "/").DeleteAsync();
            return RedirectToPage("Index");
        }
    }
}
