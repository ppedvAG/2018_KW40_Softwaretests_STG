using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jura.Pressa2000
{
    public class CoffeMaker
    {
        public static void MakeCoffee(int kaffee, int milch, int zucker, int kakao, int löffel)
        {
            Console.Beep(100, kaffee * 10);
            Console.Beep(200, milch * 10);
            Console.Beep(300, zucker * 100);
            Console.Beep(400, kakao * 10);

            Console.Beep(50, 500);

        }
    }
}
