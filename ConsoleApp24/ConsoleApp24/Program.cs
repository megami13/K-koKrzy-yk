using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24
{
    class Program
    {
        static Random rnd = new Random();

        static bool czyWygrana(int[, ] tab, int x, int y)
        {
            //Po przekątnej:
            if (tab[x, y] == 1 && tab[x-1, y-1] == 1 && tab[x+1, y+1] == 1)
            {
                return true;
            }
            else if (tab[x, y] == 1 && tab[x-1, y-1] == 1 && tab[x-2, y-2] == 1)
            {
                return true;
            }
            else if (tab[x, y] == 1 && tab[x+1, y+1] == 1 && tab[x+2, y+2] == 1)
            {
                return true;
            }
            //Po drugiej przekątnej:
            else if (tab[x, y] == 1 && tab[x-1, y+1] == 1 && tab[x+1, y-1] == 1)
            {
                return true;
            }
            else if (tab[x, y] == 1 && tab[x+1, y-1] == 1 && tab[x+2, y-2] == 1)
            {
                return true;
            }
            else if (tab[x, y] == 1 && tab[x-1, y+1] == 1 && tab[x-2, y+2] == 1)
            {
                return true;
            }
            //Pionowo:
            else if (tab[x, y] == 1 && tab[x, y-1] == 1 && tab[x, y+1] == 1)
            {
                return true;
            }
            else if (tab[x, y] == 1 && tab[x, y+1] == 1 && tab[x, y+2] == 1)
            {
                return true;
            }
            else if (tab[x, y] == 1 && tab[x, y-1] == 1 && tab[x, y-2] == 1)
            {
                return true;
            }
            //Poziomo:
            else if (tab[x, y] == 1 && tab[x-1, y] == 1 && tab[x+1, y] == 1)
            {
                return true;
            }
            else if (tab[x, y] == 1 && tab[x+1, y] == 1 && tab[x+2, y] == 1)
            {
                return true;
            }
            else if (tab[x, y] == 1 && tab[x-1, y] == 1 && tab[x-2, y] == 1)
            {
                return true;
            }
            else
            {
                tab[x, y] = 1;
                return false;
            }
        }

        static void losujLiczbe(int[,] tab, out int x, out int y)
        {
            x = rnd.Next(0, 100);
            y = rnd.Next(0, 100);

            if (tab[x, y] == 1)
                losujLiczbe(tab, out x, out y);
        }

        static void Main(string[] args)
        {
            int[,] plansza = new int[100, 100];

            for (int i = 0; i < 99; i++)
            {
                for (int j = 0; j < 99; j++)
                {
                    plansza[i, j] = 0;
                }
            }

            int x, y;
            bool wygrana = false;
            /*
            while (wygrana == false) 
            {
                losujLiczbe(plansza, out x, out y);

                Console.WriteLine(x + ", " + y);

                wygrana = czyWygrana(plansza, x, y);

                //Console.WriteLine(plansza[x, y]);
            }
            */
            for (int j = 0; j < 10000; j++)
            {
                losujLiczbe(plansza, out x, out y);

                Console.WriteLine(x + ", " + y);

                wygrana = czyWygrana(plansza, x, y);
                if (wygrana == true)
                {
                    Console.Write("Wygrana");
                    break;
                }
            }
            for (int i = 0; i < 100; i++)
                for (int k = 0; k < 100; k++)
                    Console.Write(plansza[i, k]);
        }
    }
}
