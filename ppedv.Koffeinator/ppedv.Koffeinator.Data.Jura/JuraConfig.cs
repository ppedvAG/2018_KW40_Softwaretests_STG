using Jura.Pressa2000;
using ppedv.Koffeinator.Model;
using ppedv.Koffeinator.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Koffeinator.Data.Jura
{
    public class JuraConfig : IKaffeemaschine
    {


        public void ErstelleKaffee(KaffeeRezept rezept)
        {
            if (rezept == null)
                throw new ArgumentNullException();

            CoffeMaker.MakeCoffee(rezept.Kaffee, rezept.Milch, rezept.Zucker,
                rezept.Kakao, rezept.Löffel ? 1 : 0);
        }

        public void MachKaffee(KaffeeRezept rezept)
        {
            ErstelleKaffee(rezept);
        }
    }
}
