using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Models
{
    public class Profesor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        
        public List<ProfesorToCurso> ProfesorToCursos { get; set; }
    }
}
