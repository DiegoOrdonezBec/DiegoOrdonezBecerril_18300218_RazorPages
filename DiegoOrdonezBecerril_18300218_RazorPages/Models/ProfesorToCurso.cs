using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Models
{
    public class ProfesorToCurso
    {
        [Key]
        public int ProfesorId { get; set; }
        public Profesor Profesor { get; set; }

        [Key]
        public int CursoId { get; set; }
        public Curso Curso { get; set; }

        public ProfesorToCurso()
        {

        }

        public ProfesorToCurso(Profesor p, Curso c)
        {
            this.ProfesorId = p.Id;
            this.Profesor = p;
            this.CursoId = c.Id;
            this.Curso = c;
        }
    }
}
