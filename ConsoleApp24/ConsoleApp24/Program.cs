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

        static bool czyWygrana(int[, ] tab, int x, int y, int nr_gracza)
        {
            tab[x, y] = nr_gracza;
            //Po przekątnej:
            if (tab[x, y] == nr_gracza && tab[x-1, y-1] == nr_gracza && tab[x+1, y+1] == nr_gracza)
            {
                return true;
            }
            else if (tab[x, y] == nr_gracza && tab[x-1, y-1] == nr_gracza && tab[x-2, y-2] == nr_gracza)
            {
                return true;
            }
            else if (tab[x, y] == nr_gracza && tab[x+1, y+1] == nr_gracza && tab[x+2, y+2] == nr_gracza)
            {
                return true;
            }
            //Po drugiej przekątnej:
            else if (tab[x, y] == nr_gracza && tab[x-1, y+1] == nr_gracza && tab[x+1, y-1] == nr_gracza)
            {
                return true;
            }
            else if (tab[x, y] == nr_gracza && tab[x+1, y-1] == nr_gracza && tab[x+2, y-2] == nr_gracza)
            {
                return true;
            }
            else if (tab[x, y] == nr_gracza && tab[x-1, y+1] == nr_gracza && tab[x-2, y+2] == nr_gracza)
            {
                return true;
            }
            //Pionowo:
            else if (tab[x, y] == nr_gracza && tab[x, y-1] == nr_gracza && tab[x, y+1] == nr_gracza)
            {
                return true;
            }
            else if (tab[x, y] == nr_gracza && tab[x, y+1] == nr_gracza && tab[x, y+2] == nr_gracza)
            {
                return true;
            }
            else if (tab[x, y] == nr_gracza && tab[x, y-1] == nr_gracza && tab[x, y-2] == nr_gracza)
            {
                return true;
            }
            //Poziomo:
            else if (tab[x, y] == nr_gracza && tab[x-1, y] == nr_gracza && tab[x+1, y] == nr_gracza)
            {
                return true;
            }
            else if (tab[x, y] == nr_gracza && tab[x+1, y] == nr_gracza && tab[x+2, y] == nr_gracza)
            {
                return true;
            }
            else if (tab[x, y] == nr_gracza && tab[x-1, y] == nr_gracza && tab[x-2, y] == nr_gracza)
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
            int x_gracz1, y_gracz1;
            int x_gracz2, y_gracz2;
            int x_gracz3, y_gracz3;

            bool wygrana_gracz1 = false, wygrana_gracz2 = false, wygrana_gracz3 = false;

            int wygrana_gracz1_counter = 0, wygrana_gracz2_counter = 0, wygrana_gracz3_counter = 0;

            int[,] plansza = new int[104, 104];

            for (int l = 0; l < 1000; l++)
            {
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

                for (int j = 0; j < 10000; j++)
                {
                    losujLiczbe(plansza, out x_gracz1, out y_gracz1);

                    //Console.WriteLine("Gracz 1: " + x_gracz1 + ", " + y_gracz1);

                    wygrana_gracz1 = czyWygrana(plansza, x_gracz1, y_gracz1, 1);

                    if (wygrana_gracz1 == true)
                    {
                        //Console.WriteLine("Wygrana " + "gracz 1");
                        wygrana_gracz1_counter++;
                        break;
                    }

                    losujLiczbe(plansza, out x_gracz2, out y_gracz2);

                    //Console.WriteLine("Gracz 2: " + x_gracz2 + ", " + y_gracz2);

                    wygrana_gracz2 = czyWygrana(plansza, x_gracz2, y_gracz2, 2);

                    if (wygrana_gracz2 == true)
                    {
                        //Console.WriteLine("Wygrana " + "gracz 2");
                        wygrana_gracz2_counter++;
                        break;
                    }

                    losujLiczbe(plansza, out x_gracz3, out y_gracz3);

                    //Console.WriteLine("Gracz 3: " + x_gracz3 + ", " + y_gracz3);

                    wygrana_gracz3 = czyWygrana(plansza, x_gracz3, y_gracz3, 3);

                    if (wygrana_gracz3 == true)
                    {
                        //Console.WriteLine("Wygrana " + "gracz 3");
                        wygrana_gracz3_counter++;
                        break;
                    }
                }
            }

            Console.WriteLine("Gracz1: " + wygrana_gracz1_counter);
            Console.WriteLine("Gracz2: " + wygrana_gracz2_counter);
            Console.WriteLine("Gracz3: " + wygrana_gracz3_counter);
            /*
            for (int i = 0; i < 104; i++)
            {
                for (int k = 0; k < 104; k++)
                {
                    Console.Write(plansza[i, k]);
                }
                Console.WriteLine();
            }
            */
        }
    }
}
