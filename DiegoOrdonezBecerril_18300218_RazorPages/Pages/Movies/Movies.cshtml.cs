using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiegoOrdonezBecerril_18300218_RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Pages.Movies
{
    public class MoviesModel : PageModel
    {
        [BindProperty]
        public Movie Movie { get; set; }
        public SelectList Options { get; set; }
        [BindProperty]
        public int IdMovie { get; set; }
        public IActionResult OnGet()
        {
            List<Movie> movies = new List<Movie>();
            
            movies.Add(new Movie { Id = 1, Title = "Fragmentado"});
            movies.Add(new Movie { Id = 2, Title = "La traición" });
            movies.Add(new Movie { Id = 3, Title = "Identidad desconocida" });

            Options = new SelectList(movies, nameof(Movie.Id), nameof(Movie.Title));

            return Page();
        }

        public IActionResult OnPost()
        {
            var number = Request.Form["number"];
            if (ModelState.IsValid)
            {
                var x = Movie.Title;
                var y = Movie.Genre;
            }

            return Page();
        }
    }
}
