using ppedv.Koffeinator.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Koffeinator.Data.EF
{
    public class EfContext : DbContext
    {
        public DbSet<Maschine> Maschinen { get; set; }
        public DbSet<KaffeeRezept> Rezepte { get; set; }

        public EfContext() : base("Server=.;Database=KoffeinatorDB;Trusted_Connection=true;")
        { }
    }
}
