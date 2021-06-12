using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Projekt_Notatki.Data.Migrations
{
    public class NotatkiContext : DbContext
    {
        public NotatkiContext(DbContextOptions<NotatkiContext> options)
          : base(options)
        {

        }
        public DbSet<Projekt_Notatki.Models.notatka> notatka { get; set; }
        

    }
}

