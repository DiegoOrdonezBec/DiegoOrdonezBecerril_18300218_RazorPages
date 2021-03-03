using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DiegoOrdonezBecerril_18300218_RazorPages.DataModels
{
    public class ProfesorF
    {
        [JsonIgnore]
        public string Key { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre del profesor")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        [StringLength(20)]
        public string Sexo { get; set; }
    }
}
