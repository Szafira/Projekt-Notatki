
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Projekt_Notatki.Models
{
    public class notatka
    {
        public decimal id_notatka { get; set; }
        public decimal id_użytkownik { get; set; }
        public string tytuł { get; set; }
        public string tekst { get; set; }
        public string przedmiot { get; set; }
        public string klasa { get; set; }

    }
}
