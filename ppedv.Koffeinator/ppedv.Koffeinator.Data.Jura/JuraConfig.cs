using Jura.Pressa2000;
using ppedv.Koffeinator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Koffeinator.Data.Jura
{
    public class JuraConfig
    {
        public void ErstelleKaffee(KaffeeRezept rezept)
        {
            if (rezept == null)
                throw new ArgumentNullException();

            CoffeMaker.MakeCoffee(rezept.Kaffee, rezept.Milch, rezept.Zucker,
                rezept.Kakao, rezept.Löffel ? 1 : 0);
        }

    }
}
