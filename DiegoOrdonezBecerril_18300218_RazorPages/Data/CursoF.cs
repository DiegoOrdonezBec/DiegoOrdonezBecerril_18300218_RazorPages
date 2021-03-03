using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Data
{
    public class CursoF
    {
        [JsonIgnore]
        public string Key { get; set; }
        [Required]
        [Display(Name = "Nombre del curso")]
        public string Nombre { get; set; }
        [Display(Name = "Cantidad de clases")]
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}
