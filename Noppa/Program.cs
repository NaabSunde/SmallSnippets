using System;



namespace Noppa
{
    /// <summary>
    /// Nopanheitto.
    /// </summary>
    class Program
    {
        private static Random randomizer = new Random();
        private static int[] heitot;
        static void Main()
        {
            Console.Write("Moniko sivuista noppaa heitetään? > ");
            int sivujenLkm = Int32.Parse(Console.ReadLine());
            Console.Write("Montako kertaa noppaa heitetään? > ");
            int lkm = Int32.Parse(Console.ReadLine());

            heitot = new int[sivujenLkm];

            HeitaNoppaa(lkm);
            TulostaTulokset();
        }

        /// <summary>
        /// Nopanheittosilmukka.
        /// </summary>
        /// <param name="lkm"> Montako kertaa heitetään. </param>
        private static void HeitaNoppaa(int lkm)
        {
            for (int i = 0; i < lkm; i++)
            {
                heitot[Noppa()]++;
            }
        }

        /// <summary>
        /// Heittää noppaa.
        /// </summary>
        /// <returns> Lukuarvon nollan ja (nopan sivujen määrä - 1) välillä. Näin arvot mahtuvat arrayn sisään. </returns>
        public static int Noppa()
        {
            return randomizer.Next(0, heitot.Length);
        }

        /// <summary>
        /// Tulostaa tulokset.
        /// </summary>
        public static void TulostaTulokset()
        {
            for (int i = 0; i < heitot.Length; i++)
            {
                Console.WriteLine(i + 1 + ": " + heitot[i] + " ");
            }
        }
    }
}
