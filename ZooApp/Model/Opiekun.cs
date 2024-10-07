using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApp.Model
{
    public class Opiekun : IOpiekun
    {
        public int IdOpiekuna { get; private set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        private static int _id = 0;

        public List<Zwierze> Zwierzeta = new List<Zwierze>();

        public Opiekun(string imie, string nazwisko)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            IdOpiekuna = ++_id;
        }

        public void DodajZwierze(Zwierze zwierze)
        {
            if (!Zwierzeta.Any(z => z.IdZwierzecia == zwierze.IdZwierzecia))
            {
                Zwierzeta.Add(zwierze);
                return;
            }
            else {
                Console.WriteLine("Nie można dodać tego samego zwierzęcia.");
            }
        }
        public void UsunZwierze(int idZwierzecia)
        {
            Zwierze? zwierze = Zwierzeta.FirstOrDefault(z => z.IdZwierzecia == idZwierzecia);

            if (zwierze is not null)
            {
                Console.WriteLine($"\nUsuwam zwierze u opiekuna {Imie} {Nazwisko}:");
                Console.WriteLine($"\tID {zwierze.IdZwierzecia}: {zwierze.Gatunek} {zwierze.Imie}");

                Zwierzeta.Remove(zwierze);
            }
        }
        public void WyswietlWszystkieZwierzęta()
        {
            if (Zwierzeta.Count > 0)
            {
                Console.WriteLine($"\nOpiekun {Imie} {Nazwisko} ma nastepujace zwierzeta:");

                foreach (var zwierze in Zwierzeta)
                {
                    Console.WriteLine($"\t{zwierze.Imie}, {zwierze.Gatunek}, {zwierze.Wiek} lat, ID: {zwierze.IdZwierzecia}");
                }
            }
            else
            {
                Console.WriteLine($"\nOpiekun {Imie} {Nazwisko} nie ma zadnych zwierzat pod opieka.");
            }
        }
    }
}
