using DiegoOrdonezBecerril_18300218_RazorPages.DataModels;
using Firebase.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Pages.Profesores
{
    public class EditModel : PageModel
    {
        private readonly FirebaseClient firebaseClient;
        [BindProperty]
        public ProfesorF ProfesorF { get; set; }
        public SelectList OpcionesSexo;

        public EditModel(FirebaseClient firebaseClient)
        {
            this.firebaseClient = firebaseClient;

            List<string> opciones = new List<string>();

            opciones.Add("MASCULINO");
            opciones.Add("FEMENINO");

            OpcionesSexo = new SelectList(opciones);
        }

        public async Task OnGet(string key)
        {
            ProfesorF = await firebaseClient.Child("Profesor/" + key).OnceSingleAsync<ProfesorF>();
            ProfesorF.Key = key;
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await firebaseClient.Child("Profesor/" + ProfesorF.Key + "/").PutAsync(JsonSerializer.Serialize<ProfesorF>(ProfesorF));
                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
