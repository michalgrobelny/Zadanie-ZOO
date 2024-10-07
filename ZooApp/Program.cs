
using ZooApp.Model;

namespace ZooApp
{
    public class Program
    {
        private static List<Zwierze> Zwierzeta = new List<Zwierze>();
        private static List<Opiekun> Opiekunowie = new List<Opiekun>();

        static void Main(string[] args)
        {
            DodajDane();

            Console.WriteLine("Witamy w Zoo!\n");
            Console.WriteLine("Wybierz jedna z opcji:");
            Console.WriteLine("1. Dodaj zwierze");
            Console.WriteLine("2. Usun zwierze");
            Console.WriteLine("3. Dodaj opiekuna");
            Console.WriteLine("4. Usun opiekuna");
            Console.WriteLine("5. Wyswietl wszystkie zwierzeta");
            Console.WriteLine("6. Wyswietl wszystkich opiekunow");
            Console.WriteLine("7. Wyjdź z programu");

            string? wybranaOpcjaMenuStr;
            int wybranaOpcja;

            while (true)
            {
                wybranaOpcjaMenuStr = Console.ReadLine();

                if (wybranaOpcjaMenuStr == null)
                {
                    Console.WriteLine("Nie wybrano żadnej opcji.");
                    continue;
                }

                if (int.TryParse(wybranaOpcjaMenuStr, out wybranaOpcja) && wybranaOpcja >= 1 && wybranaOpcja <= 7)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Nieprawidłowa opcja. Proszę wybrać opcję od 1 do 7.");
                }

            }

            switch (wybranaOpcja)
            {
                case 1:
                    Console.WriteLine("Nie zaimplementowano tej opcji menu. Działa tylko wywołanie odpowiedniej metody.");
                    break;
                case 2:
                    Console.WriteLine("Nie zaimplementowano tej opcji menu. Działa tylko wywołanie odpowiedniej metody.");
                    break;
                case 3:
                    Console.WriteLine("Nie zaimplementowano tej opcji menu. Działa tylko wywołanie odpowiedniej metody.");
                    break;
                case 4:
                    Console.WriteLine("Nie zaimplementowano tej opcji menu. Działa tylko wywołanie odpowiedniej metody.");
                    break;
                case 5:
                    WyswietlWszystkieZwierzeta();
                    break;
                case 6:
                    WyswietlWszystkichOpiekunow();
                    break;
                case 7:
                    Console.WriteLine("\nWyjście z programu...");
                    return;
                default:
                    return;
            }

        }

        private static void DodajZwierze(Zwierze zwierze, int idOpiekuna)
        {
            if (!Zwierzeta.Any(z => z.IdZwierzecia == zwierze.IdZwierzecia))
            {
                Console.WriteLine($"\nDodaje nowe zwierze:");
                Console.WriteLine($"\tID {zwierze.IdZwierzecia}: {zwierze.Gatunek} {zwierze.Imie}");

                Zwierzeta.Add(zwierze);
                Opiekunowie.FirstOrDefault(o => o.IdOpiekuna == idOpiekuna)?.DodajZwierze(zwierze);
            }
            else
            {
                Console.WriteLine("Błąd - to zwierze jest już dodane.");
            }
        }

        private static void UsunZwierze(int idZwierzecia)
        {
            Console.WriteLine($"\nUsuwam zwierze o ID {idZwierzecia}");

            Zwierze? zwierze;

            var opiekun = Opiekunowie.
                SelectMany(o => o.Zwierzeta, (o, z) => new { Opiekun = o, Zwierze = z })
                .FirstOrDefault(oz => oz.Zwierze.IdZwierzecia == idZwierzecia)?.Opiekun;

            if (opiekun is not null)
            {
                Console.WriteLine($"Usuwanie zwierzecia - znaleziono opiekuna {opiekun.Imie} {opiekun.Nazwisko}");
                
                zwierze = opiekun.Zwierzeta.FirstOrDefault(z => z.IdZwierzecia == idZwierzecia);
                if (zwierze is not null)
                {
                    Console.WriteLine($"\nUsuwam zwierze u opiekuna {opiekun.Imie} {opiekun.Nazwisko}:");
                    Console.WriteLine($"\tID {zwierze.IdZwierzecia}: {zwierze.Gatunek} {zwierze.Imie}");

                    opiekun.Zwierzeta.Remove(zwierze);
                }
            }

            zwierze = Zwierzeta.FirstOrDefault(z => z.IdZwierzecia == idZwierzecia);
            if (zwierze is not null)
            {
                Console.WriteLine($"\nUsuwam zwierze z listy globalnej:");
                Console.WriteLine($"\tID {zwierze.IdZwierzecia}: {zwierze.Gatunek} {zwierze.Imie}");

                Zwierzeta.Remove(zwierze);
            }
        }

        private static void DodajOpiekuna(Opiekun opiekun)
        {
            Console.WriteLine($"\nDodaje nowego opiekuna:\n\tID {opiekun.IdOpiekuna}: {opiekun.Imie} {opiekun.Nazwisko}");

            Opiekunowie.Add(opiekun);
        }
        private static void usunOpiekuna(int idOpiekuna)
        {
            var opiekun = Opiekunowie.FirstOrDefault(o => o.IdOpiekuna == idOpiekuna);

            if (opiekun is not null)
            {
                Console.WriteLine($"\nUsuwam opiekuna:\n\t{opiekun.Imie} {opiekun.Nazwisko}");

                Opiekunowie.Remove(opiekun);
            }
        }

        private static void WyswietlWszystkieZwierzeta()
        {
            Console.WriteLine("\nWyswietlam wszystkie zwierzeta:");

            foreach (var zwierze in Zwierzeta)
            {
                Console.WriteLine($"\tID {zwierze.IdZwierzecia}: {zwierze.Gatunek} {zwierze.Imie}, wiek {zwierze.Wiek} lat");
            }

            foreach (Opiekun opiekun in Opiekunowie)
            {
                opiekun.WyswietlWszystkieZwierzęta();
            }
        }

        private static void WyswietlWszystkichOpiekunow()
        {
            Console.WriteLine("\nWyswietlam wszystkich opiekunow:");

            foreach (Opiekun opiekun in Opiekunowie)
            {
                Console.WriteLine($"\tID {opiekun.IdOpiekuna}: {opiekun.Imie} {opiekun.Nazwisko}");
            }
        }

        private static void DodajDane()
        {
            DodajOpiekuna(new Opiekun("Jan", "Kowalski"));
            DodajOpiekuna(new Opiekun("Stanislaw", "Stanislawski"));
            DodajOpiekuna(new Opiekun("John", "Lennon"));

            DodajZwierze(new Ssak("Jacus", "Tygrys", 3), 1);
            DodajZwierze(new Ssak("Leon", "Lew", 5), 1);
            DodajZwierze(new Ptak("Marysia", "Sowa", 2), 2);

            WyswietlWszystkieZwierzeta();

            UsunZwierze(1);

            WyswietlWszystkieZwierzeta();
            WyswietlWszystkichOpiekunow();

            usunOpiekuna(1);

            WyswietlWszystkichOpiekunow();
        }

    }
}
