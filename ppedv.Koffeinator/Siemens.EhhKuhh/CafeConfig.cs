using System;

namespace Siemens.EhhKuhh
{
    public class CafeConfig
    {
        public long KaffeeInGramm { get; set; }
        public double MilchInLiter { get; set; }
        public bool[] Zucker { get; set; } //jedes true = 1mg zucker
        public string Kakao { get; set; }
        public DateTime Löffel { get; set; }
    }
}
