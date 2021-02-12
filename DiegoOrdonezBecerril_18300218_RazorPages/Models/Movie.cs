using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}
