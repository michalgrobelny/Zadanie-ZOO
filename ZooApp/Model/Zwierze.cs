using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApp.Model
{
    public abstract class Zwierze
    {
        public string Imie { get; set; }
        public string Gatunek { get; set; }
        public int Wiek { get; set; }
        public int IdZwierzecia { get; private set; }

        private static int _id = 0;
        public Zwierze(string imie, string gatunek, int wiek)
        {
            Imie = imie;
            Gatunek = gatunek;
            Wiek = wiek;
            IdZwierzecia = ++_id;
        }
    }
}