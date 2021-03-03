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
        private readonly FirebaseClient firebaseClient;
        public List<CursoF> CursosF;

        public IndexModel(FirebaseClient firebaseClient)
        {
            this.firebaseClient = firebaseClient;
            CursosF = new List<CursoF>();
        }

        public async Task OnGet()
        {   
            IReadOnlyCollection<FirebaseObject<CursoF>> cursosF = await firebaseClient.Child("Curso").OnceAsync<CursoF>();
            
            foreach (FirebaseObject<CursoF> firebaseObject in cursosF)
            {
                CursoF cursoF = firebaseObject.Object;
                cursoF.Key = firebaseObject.Key;
                CursosF.Add(cursoF);
            }
        }

        public async Task<IActionResult> OnPostDelete(string key)
        {
            await firebaseClient.Child("Curso/" + key + "/").DeleteAsync();
            return RedirectToPage("Index");
        }
    }
}
