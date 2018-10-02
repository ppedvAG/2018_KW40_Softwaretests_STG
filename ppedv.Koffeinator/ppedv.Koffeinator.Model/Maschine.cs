using System.Collections.Generic;

namespace ppedv.Koffeinator.Model
{
    public class Maschine : Entity
    {
        public string Standort { get; set; }
        public string SerienNr { get; set; }
        public string Modell { get; set; }
        public virtual HashSet<KaffeeRezept> Rezepte { get; set; } = new HashSet<KaffeeRezept>();
    }

}
