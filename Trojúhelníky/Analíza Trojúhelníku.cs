using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trojúhelníky
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool znova = true;
            do 
            {
                bool spatne_zadano = true;

                double a = 0;
                double b = 0;
                double c = 0;

                while (spatne_zadano)
                {
                    Console.WriteLine("Zadej délku strany A.");
                    string strana_a = Console.ReadLine();

                    if (double.TryParse(strana_a, out a) && a > 0)
                    {
                        spatne_zadano = false;
                    }
                    else
                    {
                        Console.WriteLine("Neplatné číslo");
                    }
                }

                spatne_zadano = true;
                while (spatne_zadano)
                {
                    Console.WriteLine("Zadej délku strany B.");
                    string strana_b = Console.ReadLine();

                    if (double.TryParse(strana_b, out b) && b > 0)
                    {
                        spatne_zadano = false;
                    }
                    else
                    {
                        Console.WriteLine("Neplatné číslo");
                    }
                }

                spatne_zadano = true;
                while (spatne_zadano)
                {
                    Console.WriteLine("Zadej délku strany C.");
                    string strana_c = Console.ReadLine();

                    if (double.TryParse(strana_c, out c) && c > 0)
                    {
                        spatne_zadano = false;
                    }
                    else
                    {
                        Console.WriteLine("Neplatné číslo");
                    }
                }

                // sestrojitelnost
                bool sestrojitelny;
                if ((a + b > c) && (b + c > a) && (a + c > b))
                {
                    sestrojitelny = true;
                }
                else
                {
                    sestrojitelny = false;
                }

                if (sestrojitelny)
                {

                    // typ
                    string typ;
                    if (a == b && a == c)
                    {
                        typ = "rovnostraný";
                    }
                    else if (a == b || a == c || b == c)
                    {
                        typ = "rovnoramenný";
                    }
                    else
                    {
                        typ = "obecný";
                    }

                    // pravoúhlost
                    string pravouhlost;
                    if (a * a + b * b == c * c)
                    {
                        pravouhlost = "U bodu C";
                    }
                    else if (a * a + c * c == b * b)
                    {
                        pravouhlost = "U bodu B";
                    }
                    else if (b * b + c * c == a * a)
                    {
                        pravouhlost = "U bodu A";
                    }
                    else
                    {
                        pravouhlost = "Není";
                    }

                    double p = (a + b + c) / 2;

                    // vnitřní úhly
                    double uhel_a = Math.Round(VypocetUhluA(a, b, c), 2);
                    double uhel_b = Math.Round(VypocetUhluB(a, b, c), 2);
                    double uhel_c = Math.Round(VypocetUhluC(a, b, c), 2);

                    // obvod a plocha
                    double obvod = a + b + c;
                    double plocha = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

                    // výšky
                    double vyskaA = 2 * plocha / a;
                    double vyskaB = 2 * plocha / b;
                    double vyskaC = 2 * plocha / c;

                    // kružnice opsaná a vepsaná
                    double polomerVepsanehoKruhu = plocha / p;
                    double polomerOpsanehoKruhu = a * b * c / (4 * plocha);

                    // code by KikiZC
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("Typ trojúhelníku: " + typ);
                    Console.WriteLine("Pravý úhel: " + pravouhlost);
                    Console.WriteLine($"Přibližné velikosti úhlů: ");
                    Console.WriteLine($"A: {uhel_a}, B: {uhel_b}, C: {uhel_c}");
                    Console.WriteLine($"Výšky: va: {vyskaA}, vb: {vyskaB}, vc: {vyskaC}");
                    Console.WriteLine("Obvod: " + obvod + ", Plocha: " + plocha);
                    Console.WriteLine("Poloměr kružnice opsané: " + polomerOpsanehoKruhu);
                    Console.WriteLine("Poloměr kružnice vepsané: " + polomerVepsanehoKruhu);
                    Console.WriteLine("--------------------------------------------");
                }
                else
                {
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("Trujúhelník není možné sestrojit.");
                    Console.WriteLine("--------------------------------------------");
                }

                Console.WriteLine("");
                Console.WriteLine("Další příklad? A/n");
                string zonva = Console.ReadLine();

                if (zonva == "n")
                {
                    znova = false;
                }
                else
                {
                    Console.Clear();
                }

            } while (znova);

            Console.ReadLine();
        }

        static double VypocetUhluA(double a, double b, double c)
        {
            return Math.Acos((b * b + c * c - a * a) / (2 * b * c)) * (180 / Math.PI);
        }

        static double VypocetUhluB(double a, double b, double c)
        {
            return Math.Acos((a * a + c * c - b * b) / (2 * a * c)) * (180 / Math.PI);
        }

        static double VypocetUhluC(double a, double b, double c)
        {
            return Math.Acos((a * a + b * b - c * c) / (2 * a * b)) * (180 / Math.PI);
        }

    }
}
