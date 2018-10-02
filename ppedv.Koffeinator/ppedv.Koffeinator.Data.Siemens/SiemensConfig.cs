using ppedv.Koffeinator.Model;
using ppedv.Koffeinator.Model.Contracts;
using Siemens.EhhKuhh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Koffeinator.Data.Siemens
{
    public class SiemensConfig : IKaffeemaschine
    {
        public void MachKaffee(KaffeeRezept rezept)
        {
            if (rezept == null)
                throw new ArgumentNullException();

            var cc = new CafeConfig()
            {
                KaffeeInGramm = rezept.Kaffee * 1000,
                MilchInLiter = rezept.Milch / 1000,
                Kakao = rezept.Kakao.ToString()
            };

            if (rezept.Löffel)
                cc.Löffel = DateTime.Now;
            else
                cc.Löffel = DateTime.Now.AddDays(-1);

            cc.Zucker = new bool[rezept.Zucker];
            for (int i = 0; i < rezept.Zucker - 1; i++)
            {
                cc.Zucker[i] = true;
            }

            var cs = new CafeStarter(cc);
            cs.HeatUp();
            cs.CreateCafe();
        }
    }
}
