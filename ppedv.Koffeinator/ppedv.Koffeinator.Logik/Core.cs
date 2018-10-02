using ppedv.Koffeinator.Model;
using ppedv.Koffeinator.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Koffeinator.Logik
{
    public class Core
    {
        public IKaffeemaschine AktiveMaschine { get; set; }
        public IRepository Repository { get; private set; }

        public Core(IRepository repo)
        {
            Repository = repo;
        }

        public Core() : this(null)
        { }

        public KaffeeRezept GetRezeptMitMeistemKaffee()
        {
            return Repository.Query<KaffeeRezept>().OrderByDescending(x => x.Kaffee).FirstOrDefault();
        }

        public void MachAlleKaffees(IEnumerable<KaffeeRezept> rezepte)
        {
            if (rezepte == null)
                throw new ArgumentNullException("rezepte");
            if (AktiveMaschine == null)
                throw new InvalidOperationException();

            foreach (var rezept in rezepte.Where(x => x.Kaffee > 2))
            {
                AktiveMaschine.MachKaffee(rezept);
            }
        }

    }
}
