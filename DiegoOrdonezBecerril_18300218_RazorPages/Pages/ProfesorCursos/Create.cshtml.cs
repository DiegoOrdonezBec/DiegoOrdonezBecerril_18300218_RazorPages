using DiegoOrdonezBecerril_18300218_RazorPages.DataModels;
using Firebase.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Pages.ProfesorCursos
{
    public class CreateModel : PageModel
    {
        private readonly FirebaseClient firebaseClient;
        [BindProperty]
        public ProfesorFToCursoF ProfesorFToCursoF { get; set; }
        public SelectList Profesores { get; set; }
        public SelectList Cursos { get; set; }

        public CreateModel(FirebaseClient firebaseClient)
        {
            this.firebaseClient = firebaseClient;
        }

        public async Task<IActionResult> OnGet()
        {
            List<ProfesorF> profesoresF = new List<ProfesorF>();
            List<CursoF> cursosF = new List<CursoF>();

            IReadOnlyCollection<FirebaseObject<ProfesorF>> profesores = await firebaseClient.Child("Profesor").OnceAsync<ProfesorF>();
            IReadOnlyCollection<FirebaseObject<CursoF>> cursos = await firebaseClient.Child("Curso").OnceAsync<CursoF>();

            foreach (FirebaseObject<ProfesorF> firebaseObject in profesores)
            {
                ProfesorF profesorF = firebaseObject.Object;
                profesorF.Key = firebaseObject.Key;
                profesoresF.Add(profesorF);
            }

            foreach (FirebaseObject<CursoF> firebaseObject in cursos)
            {
                CursoF cursoF = firebaseObject.Object;
                cursoF.Key = firebaseObject.Key;
                cursosF.Add(cursoF);
            }

            Profesores = new SelectList(profesoresF, nameof(ProfesorF.Key), nameof(ProfesorF.Nombre));
            Cursos = new SelectList(cursosF, nameof(CursoF.Key), nameof(CursoF.Nombre));

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                ProfesorF profesorF = await firebaseClient.Child("Profesor/" + ProfesorFToCursoF.KeyProfesor).OnceSingleAsync<ProfesorF>();
                CursoF cursoF = await firebaseClient.Child("Curso/" + ProfesorFToCursoF.KeyCurso).OnceSingleAsync<CursoF>();

                ProfesorFToCursoF.NombreProfesor = profesorF.Nombre;
                ProfesorFToCursoF.NombreCurso = cursoF.Nombre;

                await firebaseClient.Child("ProfesorToCurso").PostAsync(JsonSerializer.Serialize<ProfesorFToCursoF>(ProfesorFToCursoF));

                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
