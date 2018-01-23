using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot.Axes;

namespace KolkoKrzyzyk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();

            Random rnd = new Random();

            bool czyWygrana(int[,] tab, int x, int y, int nr_gracza)
            {
                tab[x, y] = nr_gracza;
                //Po przekątnej:
                if (tab[x, y] == nr_gracza && tab[x - 1, y - 1] == nr_gracza && tab[x + 1, y + 1] == nr_gracza)
                {
                    return true;
                }
                else if (tab[x, y] == nr_gracza && tab[x - 1, y - 1] == nr_gracza && tab[x - 2, y - 2] == nr_gracza)
                {
                    return true;
                }
                else if (tab[x, y] == nr_gracza && tab[x + 1, y + 1] == nr_gracza && tab[x + 2, y + 2] == nr_gracza)
                {
                    return true;
                }
                //Po drugiej przekątnej:
                else if (tab[x, y] == nr_gracza && tab[x - 1, y + 1] == nr_gracza && tab[x + 1, y - 1] == nr_gracza)
                {
                    return true;
                }
                else if (tab[x, y] == nr_gracza && tab[x + 1, y - 1] == nr_gracza && tab[x + 2, y - 2] == nr_gracza)
                {
                    return true;
                }
                else if (tab[x, y] == nr_gracza && tab[x - 1, y + 1] == nr_gracza && tab[x - 2, y + 2] == nr_gracza)
                {
                    return true;
                }
                //Pionowo:
                else if (tab[x, y] == nr_gracza && tab[x, y - 1] == nr_gracza && tab[x, y + 1] == nr_gracza)
                {
                    return true;
                }
                else if (tab[x, y] == nr_gracza && tab[x, y + 1] == nr_gracza && tab[x, y + 2] == nr_gracza)
                {
                    return true;
                }
                else if (tab[x, y] == nr_gracza && tab[x, y - 1] == nr_gracza && tab[x, y - 2] == nr_gracza)
                {
                    return true;
                }
                //Poziomo:
                else if (tab[x, y] == nr_gracza && tab[x - 1, y] == nr_gracza && tab[x + 1, y] == nr_gracza)
                {
                    return true;
                }
                else if (tab[x, y] == nr_gracza && tab[x + 1, y] == nr_gracza && tab[x + 2, y] == nr_gracza)
                {
                    return true;
                }
                else if (tab[x, y] == nr_gracza && tab[x - 1, y] == nr_gracza && tab[x - 2, y] == nr_gracza)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            void losujLiczbe(int[,] tab, out int x, out int y)
            {
                x = rnd.Next(2, 102);
                y = rnd.Next(2, 102);

                if (tab[x, y] == 1 && tab[x, y] == -1)
                    losujLiczbe(tab, out x, out y);
            }


            //Create Plotview object
            PlotView myPlot = new PlotView();

            var model = new PlotModel { Title = "Kółko, Krzyżyk i Gwiazdka" };
            var s1 = new LineSeries
            {
                Color = OxyColors.Purple,
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White,
                MarkerFill = OxyColors.Purple,
                MarkerStrokeThickness = 1.0,
                Smooth = true,
                Title = "Gracz 1"
            };

            var s2 = new LineSeries
            {
                Color = OxyColors.OrangeRed,
                MarkerType = MarkerType.Cross,
                MarkerSize = 4,
                MarkerStroke = OxyColors.OrangeRed,
                MarkerFill = OxyColors.OrangeRed,
                MarkerStrokeThickness = 1.0,
                Smooth = true,
                Title = "Gracz 2"
            };

            var s3 = new LineSeries
            {
                Color = OxyColors.Aqua,
                MarkerType = MarkerType.Star,
                MarkerSize = 4,
                MarkerStroke = OxyColors.Aqua,
                MarkerFill = OxyColors.Aqua,
                MarkerStrokeThickness = 1.0,
                Smooth = true,
                Title = "Gracz 3"
            };

            int x_gracz1, y_gracz1;
            int x_gracz2, y_gracz2;
            int x_gracz3, y_gracz3;

            bool wygrana_gracz1 = false, wygrana_gracz2 = false, wygrana_gracz3 = false;

            int wygrana_gracz1_counter = 0, wygrana_gracz2_counter = 0, wygrana_gracz3_counter = 0;

            int[,] plansza = new int[104, 104];

            for (int l = 0; l < 100; l++)
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

                    wygrana_gracz1 = czyWygrana(plansza, x_gracz1, y_gracz1, 1);

                    if (wygrana_gracz1 == true)
                    {
                        s1.Points.Add(new DataPoint(l, wygrana_gracz1_counter));
                        wygrana_gracz1_counter++;
                        break;
                    }

                    losujLiczbe(plansza, out x_gracz2, out y_gracz2);

                    wygrana_gracz2 = czyWygrana(plansza, x_gracz2, y_gracz2, 2);

                    if (wygrana_gracz2 == true)
                    {
                        s2.Points.Add(new DataPoint(l, wygrana_gracz2_counter));
                        wygrana_gracz2_counter++;
                        break;
                    }

                    losujLiczbe(plansza, out x_gracz3, out y_gracz3);

                    wygrana_gracz3 = czyWygrana(plansza, x_gracz3, y_gracz3, 3);

                    if (wygrana_gracz3 == true)
                    {
                        s3.Points.Add(new DataPoint(l, wygrana_gracz3_counter));
                        wygrana_gracz3_counter++;
                        break;
                    }
                }
            }


            model.Series.Add(s1);
            model.Series.Add(s2);
            model.Series.Add(s3);

            myPlot.Model = model;

            //Set up plot for display
            myPlot.Dock = System.Windows.Forms.DockStyle.Bottom;
            myPlot.Location = new System.Drawing.Point(0, 0);
            myPlot.Size = new System.Drawing.Size(500, 500);
            myPlot.TabIndex = 0;

            //Add plot control to form
            Controls.Add(myPlot);
        }
    }
}
