namespace Praktyki2024.Zadanie1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zadanie1();
            Zadanie2();
            Zadanie3i4();
            Zadanie5();
            Zadanie5b();
            Zadanie5c();
            Zadanie5d();
        }

        static void Zadanie1()
        {
            int liczba1 = 1, liczba2 = 2, liczba3 = 3;
            double zmienna1 = 1.1, zmienna2 = 2.2, zmienna3 = 3.3;
            string string1 = "string1", string2 = "string2", string3 = "string3";
            char litera1 = 'a', litera2 = 'b', litera3 = 'c';
            char[] litery1 = new char[] { 'a', 'b', 'c' }, litery2 = new char[] { 'd', 'e', 'f' }, litery3 = new char[] { 'g', 'h', 'i' };
        }

        static void Zadanie2()
        {
            int liczba1 = 1, liczba2 = 2, liczba3 = 3;
            double zmienna1 = 1.1, zmienna2 = 2.2, zmienna3 = 3.3;
            string string1 = "string1", string2 = "string2", string3 = "string3";
            char litera1 = 'a', litera2 = 'b', litera3 = 'c';
            char[] litery1 = new char[] { 'a', 'b', 'c' }, litery2 = new char[] { 'd', 'e', 'f' }, litery3 = new char[] { 'g', 'h', 'i' };

            Console.Write($"{liczba1} ");
            Console.Write($"{liczba2} ");
            Console.Write($"{liczba3} ");
            Console.Write($"{zmienna1} ");
            Console.Write($"{zmienna2} ");
            Console.Write($"{zmienna3} ");
            Console.Write($"{string1} ");
            Console.Write($"{string2} ");
            Console.Write($"{string3} ");
            Console.Write($"{litera1} ");
            Console.Write($"{litera2} ");
            Console.Write($"{litera3} ");
            Console.Write($"{new string(litery1)} ");
            Console.Write($"{new string(litery2)} ");
            Console.WriteLine($"{new string(litery3)} ");
        }

        static void Zadanie3i4()
        {
            Console.Write("Podaj swoje imię: ");
            string name = Console.ReadLine();

            Console.Write("Podaj swój wiek: ");
            int wiek;
            if (!int.TryParse(Console.ReadLine(), out wiek) || wiek <= 0 || wiek > 120)
            {
                Console.WriteLine("Błędny wiek!");
                return;
            }

            Console.Write("Podaj swój rok urodzenia: ");
            int rok;
            if (!int.TryParse(Console.ReadLine(), out rok) || rok > 2010)
            {
                Console.WriteLine("Błędny rok urodzenia!");
                return;
            }

            Console.Write("Podaj swoją płeć (m/k): ");
            char plec = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (plec != 'm' && plec != 'k')
            {
                Console.WriteLine("Błędna płeć! Podaj 'm' lub 'k'.");
                return;
            }

            Console.WriteLine("Twoje dane:");
            Console.WriteLine($"Imię: {name}");
            Console.WriteLine($"Wiek: {wiek}");
            Console.WriteLine($"Rok urodzenia: {rok}");
            Console.WriteLine($"Płeć: {plec}");
        }

        static void Zadanie5()
        {
            Console.WriteLine("Pętla for:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"for: {i}");
            }

            Console.WriteLine("Pętla while:");
            int j = 0;
            while (j < 5)
            {
                Console.WriteLine($"while: {j}");
                j++;
            }

            Console.WriteLine("Pętla do/while:");
            int k = 0;
            do
            {
                Console.WriteLine($"do/while: {k}");
                k++;
            } while (k < 5);
        }

        static void Zadanie5b()
        {
            int kod;
            do
            {
                Console.Write("Podaj 4-cyfrowy kod: ");
                int.TryParse(Console.ReadLine(), out kod);
            } while (kod != 1234);

            Console.WriteLine("Prawidłowy kod!");
        }

        static void Zadanie5c()
        {
            int x = 5;

            Console.WriteLine("Przykład while:");
            while (x > 5)
            {
                Console.WriteLine("To się nigdy nie wyświetli.");
            }

            Console.WriteLine("Przykład do/while:");
            do
            {
                Console.WriteLine("Ta linia wyświetli się chociaż raz.");
            } while (x > 5);
        }

        static void Zadanie5d()
        {
            Console.Write("Podaj wysokość choinki: ");
            int wys = int.Parse(Console.ReadLine());

            for (int i = 1; i <= wys; i++)
            {
                for (int j = 0; j < wys - i; j++)
                {
                    Console.Write(" ");
                }

                for (int k = 0; k < (2 * i) - 1; k++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }
    }
}

