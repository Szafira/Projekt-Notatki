
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Projekt_Notatki.Models
{
    public class SignUpModel
    {
         [Required]
        public string nazwa_użytkownika { get; set;}

        [Required(ErrorMessage = "Wpisz swój adres e-mail")]
        [Display(Name = "Adres e-mail")]
        [EmailAddress(ErrorMessage = "Wpisz poprawny adres e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Wybierz silne hasło")]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        public string Hasło { get; set; }

    
    }
}
