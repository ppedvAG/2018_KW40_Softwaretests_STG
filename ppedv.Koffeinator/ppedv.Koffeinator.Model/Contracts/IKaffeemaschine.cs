using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Koffeinator.Model.Contracts
{
    public interface IKaffeemaschine
    {
        void MachKaffee(KaffeeRezept rezept);
    }
}
