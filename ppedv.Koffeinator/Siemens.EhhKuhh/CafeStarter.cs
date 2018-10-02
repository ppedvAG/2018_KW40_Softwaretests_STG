using System;
using System.Threading;

namespace Siemens.EhhKuhh
{
    public class CafeStarter
    {
        CafeConfig cc;
        bool hot = false;
        public CafeStarter(CafeConfig cc)
        {
            this.cc = cc;
        }

        public void HeatUp()
        {
            Thread.Sleep(1000);
            hot = true;
        }

        public void CreateCafe()
        {
            Console.Beep(300, 500);
            hot = false;
        }
    }
}
