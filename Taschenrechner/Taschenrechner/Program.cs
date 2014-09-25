using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Taschenrechner
{
    class Program
    {
        //Zahleingabe Funktion
        static float ZahlEingabe()
        {
            float zahl;
            bool next;
            do
            {
                Console.WriteLine("\nGeben Sie eine Zahl ein.");
                next = float.TryParse(Console.ReadLine(), out zahl);
                if (!next)
                {
                    Console.WriteLine("Ungültige Zahl.");
                }
            }
            while (!next);
            return zahl;
        }

        //Fakultät
        static void Fakultät(float zahl)
        {
            ulong fak = 1;
            for (uint i = 1; i <= zahl; i++) { fak *= i; }
            if (fak == 1) { fak = 0; }
            Console.WriteLine(String.Format("\n{0}! = {1}", zahl, fak));
        }

        //Phytago
        static void Phytago(float zahl)
        {
            bool pyth = false;
            float c = 0;
            for (int a = 1; a < zahl; a += 1)
            {
                for (int b = 1; b < zahl; b += 1)
                {
                    if (a * a + b * b == (zahl - a - b) * (zahl - a - b) && a < b)
                    {
                        pyth = true;
                        c = zahl - a - b;
                        Console.WriteLine(String.Format("\n{0} + {1} + {2} = {3}\n{4} + {5} = {6}\n", a, b, c, zahl, a * a, b * b, c * c));
                    }
                }
            }
            if (pyth == false)
            {
                Console.WriteLine("keine Zahlen gefunden.");
            }
        }

        //Fibonacci
        static void Fibonacci(float zahl)
        {
            ulong fib1 = 0;
            ulong fib2 = 1;
            ulong fibo = 0;
            for (ulong a = 1; a <= zahl; a++)
            {
                fibo = fib1 + fib2;
                fib2 = fib1;
                fib1 = fibo;
            }
            Console.WriteLine("\nfib(" + zahl + ") = " + fibo);
        }

        //Größter gemeinsamer Teiler
        static void ggt(float z1, float z2)
        {
            //Modulo-Methode
            int ggt = 0, mod;
            int x = Convert.ToInt32(z1);
            int y = Convert.ToInt32(z2);
            if (x > y && x!=0 && y!=0)
            {
                mod = x % y;
                ggt = y - mod;
            }
            else if(x!=0 && y!=0)
            {
                mod = y % x;
                ggt = x - mod;
            }

            Console.WriteLine("Der Größte gemeinsame Teiler ist: " + ggt);

            ////Wechselwegnahme
            //while (x != y)
            //{
            //    if (x > y)
            //    {
            //        x = x - y;
            //    }
            //    else
            //    {
            //        y = y - x;
            //    }
            //}
            //Console.WriteLine(x);
            //Console.WriteLine(y);
        }

        //Main
        public static void Main(string[] args)
        {
            bool run = true;
            bool next = false;
            while (run)
            {
                //Eingabe z1
                float z1 = ZahlEingabe();

                //Eingabe Rechenoperation
                next = false;
                string o;
                do
                {
                    Console.WriteLine("\nGeben Sie die Rechenoperation ein. ( + - * / ! pt fib ggt )");
                    o = Console.ReadLine();
                    if (o == "+" || o == "-" || o == "*" || o == "/" || o == "!" || o == "pt" || o == "fib" || o == "ggt")
                    {
                        next = true;
                    }
                    else
                    {
                        Console.WriteLine("Ungültige Rechenoperation.");
                    }
                }
                while (next == false);

                if (o == "+" || o == "-" || o == "*" || o == "/" || o == "ggt")
                {

                    //Eingabe z2
                    float z2 = ZahlEingabe();

                    switch (o)
                    {
                        case "+":
                            Console.WriteLine(String.Format("\n{0} + {1} = {2}", z1, z2, z1 + z2));
                            break;

                        case "-":
                            Console.WriteLine(String.Format("\n{0} - {1} = {2}", z1, z2, z1 - z2));
                            break;

                        case "*":
                            Console.WriteLine(String.Format("\n{0} * {1} = {2}", z1, z2, z1 * z2));
                            break;

                        case "/":
                            Console.WriteLine(String.Format("\n{0} / {1} = {2}", z1, z2, z1 / z2));
                            break;
                        case "ggt":
                            ggt(z1, z2);
                            break;
                    }
                }
                else
                {
                    switch (o)
                    {
                        case "!":
                            Fakultät(z1);
                            break;

                        case "pt":
                            Phytago(z1);
                            break;

                        case "fib":
                            Fibonacci(z1);
                            break;
                    }
                    Console.WriteLine("\nBeliebige Taste drücken um fortzufahren.\n[x] - Beenden");
                    string eingabe = Console.ReadLine();
                    if (eingabe == "x")
                    {
                        run = false;
                    }
                }
            }
        }
    }
}

