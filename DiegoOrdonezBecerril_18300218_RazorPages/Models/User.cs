using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string NombreUsuario { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [Required]
        public Role Role { get; set; }
    }

    public enum Role
    {
        ADMIN,
        USER
    }
}
