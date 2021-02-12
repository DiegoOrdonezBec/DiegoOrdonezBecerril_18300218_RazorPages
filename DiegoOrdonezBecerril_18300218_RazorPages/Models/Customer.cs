using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Field required"), StringLength(10)]
        public string Name { get; set; }
    }
}
