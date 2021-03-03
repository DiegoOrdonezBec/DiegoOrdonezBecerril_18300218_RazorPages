using DiegoOrdonezBecerril_18300218_RazorPages.DataModels;
using DiegoOrdonezBecerril_18300218_RazorPages.Models;
using Firebase.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Pages.Profesores
{
    public class CreateModel : PageModel
    {
        private readonly FirebaseClient firebaseClient;
        public SelectList OpcionesSexo;
        [BindProperty]
        public ProfesorF ProfesorF { get; set; }

        public CreateModel(FirebaseClient firebaseClient)
        {
            this.firebaseClient = firebaseClient;

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
                await firebaseClient.Child("Profesor").PostAsync(JsonSerializer.Serialize<ProfesorF>(ProfesorF));
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
            
        }
    }
}
