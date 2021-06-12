using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;

namespace Projekt_Notatki.Data.Migrations
{
    public class UzytkownikContext : DbContext
    {
        public UzytkownikContext(DbContextOptions<UzytkownikContext> options)
         : base(options)
        {

        }
        public DbSet<Projekt_Notatki.Models.uzytkownik> uzytkownik { get; set; }
    }
}
