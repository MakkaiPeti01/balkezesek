using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace balkezesek
{
    class Program
    {
        static List<Balkezesek> lista = new List<Balkezesek>();
        static int be = 0;
        static void beolvas()
        {
            StreamReader olvas = new StreamReader("balkezesek.csv");
            olvas.ReadLine();
            while (!olvas.EndOfStream)
            {
                lista.Add(new Balkezesek(olvas.ReadLine()));
            }
            olvas.Close();          
                Console.WriteLine("3. feladat: {0}",lista.Count);
        }
        static void negyedik()
        {
            //1inch=2,54cm
            Console.WriteLine("4. feladat:");
            foreach (var i in lista)
            {
                if (i.Utolso.Contains("1999-10"))
                {
                    Console.WriteLine($"\t{i.Nev}, {Math.Round(i.Magassag*2.54),1:N1}cm");
                }
            }
        }
        static void otodik()
        {
            while (true)
            {
                Console.WriteLine("5. feladat:");
                Console.Write("Írjon be egy 1990 és 1999 közötti évszámot!");
                be = int.Parse(Console.ReadLine());
                if (be >= 1990 && be <= 1999)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Hibás adat! Kérek egy 1990 és 1999 közötti számot!");
                }
            }           
        }
        static void hatodik()
        {
            //substring
            double suly = 0;
            double db = 0;
            foreach (var i in lista)
            {
                if (be >= int.Parse(i.Elso.Substring(0, 4)) && be <= int.Parse(i.Utolso.Substring(0, 4)))
                {
                    suly = suly + i.Suly;
                    db++;
                }
            }
            double atlag = Math.Round(suly / db, 2);
            Console.WriteLine($"6. feladat: {atlag} font");
        }
        static void bonusz()
        {
            var nevek = from l in lista
                        select l.Nev;
            var nevlista = nevek.ToList();
            var kezdoBetu = from b in nevlista
                            orderby b
                            group b by b[0] into tempNevek
                            select tempNevek;
            foreach (var csoport in kezdoBetu)
            {
                Console.WriteLine("Kezdőbetű: {0}",csoport.Key);
                foreach (var tag in csoport)
                {
                    Console.WriteLine($"\t{tag}");
                }
            }         
        }
        static void Main(string[] args)
        {
            //var h = new Balkezesek("Jim Abbott","1989-04-08","1999-07-21",200,75);
            beolvas();
            negyedik();
            otodik();
            hatodik();
            bonusz();
            //játékosok nevei kezdőbetűnként
            Console.ReadKey();
        }
    }
}
