

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
