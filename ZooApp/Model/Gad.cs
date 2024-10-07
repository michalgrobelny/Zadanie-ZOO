using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApp.Model
{
    public class Gad : Zwierze, IZwierze
    {
        public Gad(string imie, string gatunek, int wiek) : base(imie, gatunek, wiek)
        {
        }

        public void Jedz() { }
        public void Spij() { }
        public void WydajDzwiek() { }
    }
}