using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TicTacToe;

namespace Scratchpad
{
    class Program
    {
        public static int?[] pelikentta = new int?[9];
        public static Pelaaja pelaaja1 = new Pelaaja(1);
        public static Pelaaja pelaaja2 = new Pelaaja(2);
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
        
        public static void PyydaPelaajat()
        {

            do
            {
                Console.Write("Pelaaja 1, mikä kirjain haluat olla? > "); pelaaja1.Tunnus = Console.ReadKey().KeyChar;
            } while (pelaaja1.Tunnus == default(char) || !char.IsLetter(pelaaja1.Tunnus));
            do
            {
                Console.WriteLine();
                Console.Write("Pelaaja 2, mikä kirjain haluat olla? > "); pelaaja2.Tunnus = Console.ReadKey().KeyChar;
            } while (pelaaja2.Tunnus == pelaaja1.Tunnus || pelaaja2.Tunnus == default(char) || !char.IsLetter(pelaaja2.Tunnus));
            Console.Clear();
            Console.WriteLine("Pelaajat ovat nyt '{0}' ja '{1}'.", pelaaja1.Tunnus, pelaaja2.Tunnus);
        }

        public static void PiirraPelikentta()
        {
            for (int i = 0; i < pelikentta.GetLength(0); i++)
            {
                char tulostettava = ' ';
                switch (pelikentta[i])
                {
                    case 1:
                        tulostettava = pelaaja1.Tunnus;
                        break;
                    case 2:
                        tulostettava = pelaaja2.Tunnus;
                        break;
                }
                Console.Write(string.Format("[{0}]", tulostettava));
                if((i+1) % Math.Sqrt(pelikentta.Length)==0) Console.WriteLine();
            }
        }
        public static bool TeeSiirto(int[] siirto, Pelaaja pelaaja)
        {
            int koordinaatti = (siirto[1])*3+(siirto[0]);
            if (koordinaatti < 0 || koordinaatti > pelikentta.Length) return false;

            if (pelikentta[koordinaatti] == null)
            {
                pelikentta[koordinaatti] = pelaaja.Numero;
                return true;
            }
            else
            {
                Console.WriteLine("Paikka varattu!");
                return false;
            }
        }
        public static void PyydaSiirtoa(Pelaaja pelaaja)
        {
            bool onnistuiko;
            do
            {
                Console.WriteLine("{0}, tee siirto muodossa 'x,y'.", pelaaja.Tunnus);
                int[] siirto = Siirto(Console.ReadLine());
                onnistuiko = TeeSiirto(siirto, pelaaja);

            } while (onnistuiko == false);

            Console.Clear();
            PiirraPelikentta();
            if(Voitontarkistaja(pelaaja.Numero) == true)
            {
                Console.WriteLine("{0} voitti pelin!", pelaaja.Tunnus);
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

        public static bool Voitontarkistaja(int pelaaja)
        {
            if (pelikentta[0] == pelaaja && pelikentta[1] == pelaaja && pelikentta[2] == pelaaja) return true;
            if (pelikentta[3] == pelaaja && pelikentta[4] == pelaaja && pelikentta[5] == pelaaja) return true;
            if (pelikentta[6] == pelaaja && pelikentta[7] == pelaaja && pelikentta[8] == pelaaja) return true;

            if (pelikentta[0] == pelaaja && pelikentta[3] == pelaaja && pelikentta[6] == pelaaja) return true;
            if (pelikentta[1] == pelaaja && pelikentta[4] == pelaaja && pelikentta[7] == pelaaja) return true;
            if (pelikentta[2] == pelaaja && pelikentta[5] == pelaaja && pelikentta[8] == pelaaja) return true;

            if (pelikentta[0] == pelaaja && pelikentta[4] == pelaaja && pelikentta[8] == pelaaja) return true;
            if (pelikentta[2] == pelaaja && pelikentta[4] == pelaaja && pelikentta[6] == pelaaja) return true;

            return false;
        }
    }
}
