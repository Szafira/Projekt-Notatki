using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Notatki.Models
    {
public class u¿ytkownik
{
    
    public decimal id_u¿ytkownik { get; set; }
    public string nazwa_u¿ytkownika { get; set; }
    public string email { get; set; }
    public string has³o { get; set; }
    

}
}