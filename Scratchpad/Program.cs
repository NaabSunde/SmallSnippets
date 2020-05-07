using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Scratchpad
{
    class Program
    {
        public static string[,] pelikentta = { { "[ ]", "[ ]", "[ ]" }, { "[ ]", "[ ]", "[ ]" }, { "[ ]", "[ ]", "[ ]" } };
        public static char pelaaja1;
        public static char pelaaja2;
        static void Main()
        {
            PyydaPelaajat();
            PiirraPelikentta();
            Peli();
        }
        public static void Peli()
        {
            while (true)
            {
                PyydaSiirtoa(pelaaja1);
                PyydaSiirtoa(pelaaja2);
            }
            
        }
        public static bool Voitontarkistaja(char pelaaja)
        {
            if (pelikentta[0, 0].Contains(pelaaja) && pelikentta[1, 0].Contains(pelaaja) && pelikentta[2, 0].Contains(pelaaja)) return true;
            if (pelikentta[0, 1].Contains(pelaaja) && pelikentta[1, 1].Contains(pelaaja) && pelikentta[2, 1].Contains(pelaaja)) return true;
            if (pelikentta[0, 2].Contains(pelaaja) && pelikentta[1, 2].Contains(pelaaja) && pelikentta[2, 2].Contains(pelaaja)) return true;

            if (pelikentta[0, 0].Contains(pelaaja) && pelikentta[0, 1].Contains(pelaaja) && pelikentta[0, 2].Contains(pelaaja)) return true;
            if (pelikentta[1, 0].Contains(pelaaja) && pelikentta[1, 1].Contains(pelaaja) && pelikentta[1, 2].Contains(pelaaja)) return true;
            if (pelikentta[2, 0].Contains(pelaaja) && pelikentta[2, 1].Contains(pelaaja) && pelikentta[2, 2].Contains(pelaaja)) return true;

            if (pelikentta[0, 0].Contains(pelaaja) && pelikentta[1, 1].Contains(pelaaja) && pelikentta[2, 2].Contains(pelaaja)) return true;
            if (pelikentta[0, 2].Contains(pelaaja) && pelikentta[1, 1].Contains(pelaaja) && pelikentta[2, 0].Contains(pelaaja)) return true;

            return false;
        }
        public static void PyydaPelaajat()
        {
            do
            {
                Console.Clear();
                Console.Write("Pelaaja 1, mikä kirjain haluat olla? > "); pelaaja1 = Console.ReadKey().KeyChar;
            } while (pelaaja1 == default(char) || !char.IsLetter(pelaaja1));
            do
            {
                Console.Clear();
                Console.WriteLine("Pelaaja 2, mikä kirjain haluat olla? > "); pelaaja2 = Console.ReadKey().KeyChar;
            } while (pelaaja2 == pelaaja1 || pelaaja2 == default(char) || !char.IsLetter(pelaaja2));
            Console.Clear();
            Console.WriteLine("Pelaajat ovat nyt '{0}' ja '{1}'.", pelaaja1, pelaaja2);
        }

        public static void PiirraPelikentta()
        {

            for (int i = 0; i < pelikentta.GetLength(0); i++)
            {
                for (int j = 0; j < pelikentta.GetLength(1); j++)
                {
                    Console.Write(string.Format("{0} ", pelikentta[i, j]));
                }
                Console.WriteLine();
            }
        }
        public static bool TeeSiirto(int[] siirto, char pelaaja)
        {
            int y = siirto[0];
            int x = siirto[1];

            if (pelikentta[x, y] == "[ ]")
            {
                pelikentta[x, y] = "[" + pelaaja + "]";
                return true;
            }
            else
            {
                Console.WriteLine("Paikka varattu!");
                return false;
            }
        }
        public static void PyydaSiirtoa(char pelaaja)
        {
            bool onnistuiko;
            do
            {
                Console.WriteLine("{0}, tee siirto muodossa 'x,y'.", pelaaja);
                int[] siirto = Siirto(Console.ReadLine());
                onnistuiko = TeeSiirto(siirto, pelaaja);

            } while (onnistuiko == false);
            Console.Clear();
            PiirraPelikentta();
            if(Voitontarkistaja(pelaaja) == true)
            {
                Console.WriteLine("{0} voitti pelin!", pelaaja);
                System.Environment.Exit(0);
            };
        }
        public static int[] Siirto(string siirto)
        {
            int[] siirtoParseroitu = Regex.Matches(siirto, @"\d+").Select(m => int.Parse(m.Value)).ToArray();
            for(int i = 0;i < siirtoParseroitu.Length; i++)
            {
                siirtoParseroitu[i] -= 1;
            }
            return siirtoParseroitu;
        }
    }
}
