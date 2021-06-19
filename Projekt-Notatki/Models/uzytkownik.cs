using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Notatki.Models
    {
public class uzytkownik
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public decimal id_uzytkownika { get; set; }
    public string nazwa_uzytkownika { get; set; }
    public string email { get; set; }
    public string haslo { get; set; }
    

}
}