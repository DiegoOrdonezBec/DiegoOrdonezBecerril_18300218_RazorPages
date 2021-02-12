using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiegoOrdonezBecerril_18300218_RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Pages.Cursos
{
    public class CreateModel : PageModel
    {
        public readonly ApplicationDbContext _db;
        [BindProperty]
        public Curso Curso { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _db.Add(Curso);
            
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
