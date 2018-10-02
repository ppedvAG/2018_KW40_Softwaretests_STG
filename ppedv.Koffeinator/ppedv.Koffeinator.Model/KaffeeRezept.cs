using System.Collections.Generic;

namespace ppedv.Koffeinator.Model
{
    public class KaffeeRezept : Entity
    {
        public string Bezeichnung { get; set; }
        public int Kaffee { get; set; }
        public int Milch { get; set; }
        public int Zucker { get; set; }
        public int Kakao { get; set; }
        public bool Löffel { get; set; }
        public virtual HashSet<Maschine> Maschinen { get; set; } = new HashSet<Maschine>();
    }

}
