
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Notatki.Models
{
    public class SignInModel
    {
        [Required]
        public string nazwa_użytkownika { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }
        [Display(Name = "Zapamiętaj hasło")]
    }
}
