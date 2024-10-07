using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApp.Model
{
    internal interface IOpiekun
    {
        void DodajZwierze(Zwierze zwierze);
        void UsunZwierze(int idZwierzecia);
        void WyswietlWszystkieZwierzęta();
    }
}