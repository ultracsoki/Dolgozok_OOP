using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace Dolgozok_OOP
{
    internal class Program
    {
        static List<Dolgozo> dolgozok = new List<Dolgozo>();
        static void Main(string[] args)
        {
            //Halasi-Czalbert Tibor

            Beolvasas("dolgozok.csv");
            //Kiiratas();
            //Torles(20);
            //Kiiratas();
            //Felvetel("Lajos","férfi",37,150000);
            //Kiiratas();
            FerfiDolgozokSzama();
            NoiDolgozokSzama();
            Console.WriteLine(LegnagyobbFizetes());
            Console.WriteLine(LegkisebbFizetes());
            FerfiAtlagFizetes();
            NoiAtlagFizetes();

            Console.ReadKey();
        }

        static void Beolvasas(string fajlNev)
        {
            StreamReader sr = new StreamReader(fajlNev);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] darabok = sor.Split(',');
                int id = int.Parse(darabok[0]);
                string name = darabok[1];
                string gender = darabok[2];
                int age = int.Parse(darabok[3]);
                int salary = int.Parse(darabok[4]);
                Dolgozo dolgozo = new Dolgozo(id, name, gender, age, salary);
                dolgozok.Add(dolgozo);
            }
            sr.Close();
        }

        static void Kiiratas()
        {
            foreach (var item in dolgozok)
            {
                Console.WriteLine(item);
            }
        }

        static void Torles(int deleteId)
        {
            for (int i = 0; i < dolgozok.Count; i++)
            {
                if (dolgozok[i].Id.Equals(deleteId))
                {
                    dolgozok.RemoveAt(i);
                }
            }
        }

        static void Felvetel(string name, string gender, int age, int salary)
        {
            try
            {
                Dolgozo dolgozo = new Dolgozo(dolgozok.Count + 1, name, gender, age, salary);
                dolgozok.Add(dolgozo);
            }
            catch (Exception)
            {
                throw new ArgumentException("Az id-t nem tudtuk megadni");
            }
        }

        static void FerfiDolgozokSzama()
        {
            int szamlalo = 0;
            for (int i = 0; i < dolgozok.Count; i++)
            {
                if (dolgozok[i].Gender.Equals("férfi"))
                {
                    szamlalo++;
                }
            }
            Console.WriteLine(szamlalo);
        }

        static void NoiDolgozokSzama()
        {
            int szamlalo = 0;
            for (int i = 0; i < dolgozok.Count; i++)
            {
                if (dolgozok[i].Gender.Equals("nő"))
                {
                    szamlalo++;
                }
            }
            Console.WriteLine(szamlalo);
        }

        static Dolgozo LegnagyobbFizetes()
        {
            int legnagyobb = dolgozok[0].Salary;
            int index = 0;
            for (int i = 1; i < dolgozok.Count; i++)
            {
                if (dolgozok[i].Salary > legnagyobb)
                {
                    legnagyobb = dolgozok[i].Salary;
                    index = i;
                }
            }
            return dolgozok[index];
        }

        static Dolgozo LegkisebbFizetes()
        {
            int legkisebb = dolgozok[0].Salary;
            int index = 0;
            for (int i = 1; i < dolgozok.Count; i++)
            {
                if (dolgozok[i].Salary < legkisebb)
                {
                    legkisebb = dolgozok[i].Salary;
                    index = i;
                }
            }
            return dolgozok[index];
        }

        static void FerfiAtlagFizetes()
        {
            List<Dolgozo> ferfiDolgozok = new List<Dolgozo>();
            int ferfiOsszKereset = 0;
            foreach (var item in dolgozok)
            {
                if (item.Gender.Equals("férfi"))
                {
                    ferfiDolgozok.Add(item);
                }
            }
            foreach (var item in ferfiDolgozok)
            {
                ferfiOsszKereset += item.Salary;
            }
            Console.WriteLine($"Átlag fizetés a férfiaknál:{ferfiOsszKereset/ferfiDolgozok.Count}");
        }
        static void NoiAtlagFizetes()
        {
            List<Dolgozo> noiDolgozok = new List<Dolgozo>();
            int noiOsszKereset = 0;
            foreach (var item in dolgozok)
            {
                if (item.Gender.Equals("nő"))
                {
                    noiDolgozok.Add(item);
                }
            }
            foreach (var item in noiDolgozok)
            {
                noiOsszKereset += item.Salary;
            }
            Console.WriteLine($"Átlag fizetés a nőknél:{noiOsszKereset / noiDolgozok.Count}");
        }
    }
}
