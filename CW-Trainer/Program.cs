using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security;
using System.Threading.Tasks;
using System.Threading;

namespace CW_Trainer
{
    class Program
    {
        public static char[] alphabets;
        public static string[] CW;
        public static int frequency = 500;
        public static Random random = new Random();

        static void Main(string[] args)
        {
            Formatter();
            Trainer();
        }

        public static void Formatter()
        {
            string PATH = @"C:\Users\Tom\source\repos\Small Snippets\CW-Trainer\kirjaimet.txt";
            string[] readLines = File.ReadAllLines(PATH);
            alphabets = new char[readLines.Length];
            CW = new string[readLines.Length];
            for(int i = 0; i < readLines.GetLength(0);i++)
            {
                string[] pair = readLines[i].Split(' ');
                alphabets[i] = char.Parse(pair[0]);
                CW[i] = pair[1];
            }

        }

        public static void Trainer()
        {
            PrintAll();
            while (true)
            {
                string input = null;
                while(string.IsNullOrEmpty(input))
                {
                    Console.Write("Kirjoita lause: ");

                    input = Console.ReadLine();
                }
                Console.Clear();
                string inCW = TextToCW(input);
                Console.WriteLine(input + " on CW:nä " + inCW);
                string backToText = CWtoText(inCW);
                Console.WriteLine("Ja tämä käännettynä takaisin on " + backToText);
                CWtoSound(inCW);


            }
        }

        public static string TextToCW(string question)
        {
            StringBuilder builder = new StringBuilder();
            foreach(char c in question)
            {
                if(c == ' ')
                {
                    builder.Append("/ ");
                }
                else
                {
                    builder.Append(CW[Array.IndexOf(alphabets, char.ToUpper(c))]);
                    builder.Append(' ');
                }
            }
            
            string answer = builder.ToString();
            return answer.Trim();

        }
        public static string CWtoText(string question)
        {
            StringBuilder builder = new StringBuilder();
            string[] questionSplitted = question.Split(' ');
            foreach(string s in questionSplitted)
            {
                if(s == "/")
                {
                    builder.Append(' ');
                }
                else
                {
                    builder.Append(alphabets[Array.IndexOf(CW, s)]);
                }
                
            }
            string answer = builder.ToString();
            return answer.Trim();
        }

        public static void PrintAll()
        {
            for (int i = 0; i < alphabets.GetLength(0); i++)
            {
                Console.WriteLine(alphabets[i] + " " + CW[i]);
            }
        }

        public static void CWtoSound(string CW)
        {
            foreach(char c in CW)
            {
                Beeper(c);
            }
            
        }

        public static void Beeper(char c)
        {
            if (c == '.')
            {
                Console.Beep(frequency, 200);
            }
            if (c == '-')
            {
                Console.Beep(frequency, 600);
            }
            else
                Thread.Sleep(500);
            
        }

    }
}
