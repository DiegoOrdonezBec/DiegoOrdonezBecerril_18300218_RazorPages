using DiegoOrdonezBecerril_18300218_RazorPages.DataModels;
using Firebase.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Threading.Tasks;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Pages.Cursos
{
    public class EditModel : PageModel
    {
        private readonly FirebaseClient firebaseClient;
        [BindProperty]
        public CursoF CursoF { get; set; }

        public EditModel(FirebaseClient firebaseClient)
        {
            this.firebaseClient = firebaseClient;
        }

        public async Task OnGet(string key)
        {
            CursoF = await firebaseClient.Child("Curso/" + key).OnceSingleAsync<CursoF>();
            CursoF.Key = key;
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await firebaseClient.Child("Curso/" + CursoF.Key + "/").PutAsync(JsonSerializer.Serialize<CursoF>(CursoF));
                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
