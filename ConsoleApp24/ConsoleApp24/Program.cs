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

        bool pozaPlansza(int[,] tab, int x, int y)
        {
            return false;
        }
        static bool czyWygrana(int[, ] tab, int x, int y)
        {
            tab[x, y] = 1;
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
                return false;
            }
        }

        static void losujLiczbe(int[,] tab, out int x, out int y)
        {
            x = rnd.Next(2, 102);
            y = rnd.Next(2, 102);

            if (tab[x, y] == 1 && tab[x, y] == -1)
                losujLiczbe(tab, out x, out y);
        }

        static void Main(string[] args)
        {
            int[,] plansza = new int[104, 104];

            for (int n = 0; n < 100 + 4; n++)
            {
                for (int m = 0; m < 100 + 4; m++)
                    plansza[n, m] = -1;
            }
            for (int i = 2; i < 100 + 2; i++)
            {
                for (int j = 2; j < 100 + 2; j++)
                {
                    plansza[i, j] = 0;
                }
            }

            int x, y;
            bool wygrana = false;

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
                //Console.WriteLine(czyWygrana(plansza, x, y));
            }

            for (int i = 0; i < 104; i++)
            {
                for (int k = 0; k < 104; k++)
                {
                    Console.Write(plansza[i, k]);
                }
                Console.WriteLine(" ");
            }
        }
    }
}
