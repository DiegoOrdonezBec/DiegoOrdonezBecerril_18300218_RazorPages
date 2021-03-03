using DiegoOrdonezBecerril_18300218_RazorPages.DataModels;
using Firebase.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Threading.Tasks;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Pages.Cursos
{
    public class CreateModel : PageModel
    {
        private readonly FirebaseClient firebaseClient;
        [BindProperty]
        public CursoF CursoF { get; set; }

        public CreateModel(FirebaseClient firebaseClient)
        {
            this.firebaseClient = firebaseClient;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await firebaseClient.Child("Curso").PostAsync(JsonSerializer.Serialize<CursoF>(CursoF));
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
            
        }
    }
}
