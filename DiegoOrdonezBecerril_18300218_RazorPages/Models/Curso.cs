using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Models
{
    public class Curso
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre del curso")]
        public string Nombre { get; set; }
        [Display(Name = "Cantidad de clases")]
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public List<ProfesorToCurso> ProfesorToCursos { get; set; }
    }
}