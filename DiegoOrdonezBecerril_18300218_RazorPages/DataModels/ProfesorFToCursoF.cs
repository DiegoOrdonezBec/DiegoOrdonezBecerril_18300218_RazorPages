using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DiegoOrdonezBecerril_18300218_RazorPages.DataModels
{
    public class ProfesorFToCursoF
    {
        [JsonIgnore]
        public string Key { get; set; }
        public string KeyProfesor { get; set; }
        [Display(Name = "Nombre del profesor")]
        public string NombreProfesor { get; set; }
        public string KeyCurso { get; set; }
        [Display(Name = "Nombre del curso")]
        public string NombreCurso { get; set; }
    }
}
