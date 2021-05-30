using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thermodynamics
{
    public partial class Form1 : Form
    {
        //for drawning
        const int distance = 5;
        const int drawX = 40;
        const int drawY = 40;

        const int n = 140;
        const int steps = 100000000;
        public double temperature = 1;
        public double dTemperature;
        Particle[,] particles = new Particle[n, n];

        Random random = new Random();

        public double p; 

        public Form1()
        {
            InitializeComponent();


            dTemperature = temperature / steps;
            progressBar1.Maximum = steps;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    particles[i, j] = new Particle();
                }
            }

        }

        private void CalculationButton_Click(object sender, EventArgs e)
        {
            int energy1, energy2, dEnergy;
            Initiation();
            DrawRectangle();
            DrawParticles();

            for (int k = 0; k < steps; k++)
            {
                temperature -= dTemperature;
                progressBar1.Value = k;

                int i = random.Next(0, n);
                int j = random.Next(0, n);
                double q;

                energy1 = CalculatedEnergy(i, j);
                particles[i, j].ChangeSpin();
                energy2 = CalculatedEnergy(i, j);
                dEnergy = energy2 - energy1;
                q = Math.Exp(-dEnergy / temperature);
                if (dEnergy > 0 )
                {
                    p = random.NextDouble();

                    if (p > q/(1+q))
                    {
                        particles[i, j].ChangeSpin();
                    }
                }
            }

            DrawParticles();
        }

        class Particle
        {
            private int _x = 0;
            private int _y = 0;
            private int _spin = 1;

            public void SetX(int x)
            {
                _x = x;
            }

            public int GetX()
            {
                return _x;
            }

            public void SetY(int y)
            {
                _y = y;
            }

            public int GetY()
            {
                return _y;
            }

            public int GetSpin()
            {
                return _spin;
            }
            public void ChangeSpin()
            {
                _spin = -_spin;
            }
            public void SetSpin(int spin)
            {
                _spin = spin;
            }
        }

        public void Initiation()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    particles[i, j].SetSpin(RandomSpin());

                    if (j == 0)
                    {
                        if (i % 2 == 0)
                        {
                            particles[i, j].SetX(distance / 2 + drawX);
                        }
                        else
                        {
                            particles[i, j].SetX(drawX);
                        }
                    }
                    else
                    {
                        particles[i, j].SetX(particles[i, j - 1].GetX() + distance);
                    }

                    if (i == 0)
                    {
                        particles[i, j].SetY(drawY);
                    }
                    else
                    {
                        particles[i, j].SetY(particles[i - 1, j].GetY() + distance);
                    }
                }
            }
        }

        public void DrawRectangle()
        {
            Graphics draw = this.CreateGraphics();
            draw.FillRectangle(new SolidBrush(Color.White), drawX, drawY, particles[n - 2, n - 1].GetX() + distance - drawX, particles[n - 1, n - 1].GetY() + distance - drawY);
        }

        public void DrawParticle(int i, int j)
        {
            Graphics draw = this.CreateGraphics();

            if (particles[i, j].GetSpin() == -1)
            {
                draw.FillEllipse(new SolidBrush(Color.Black), particles[i, j].GetX(), particles[i, j].GetY(), distance, distance);
            }
            else
            {
                draw.FillEllipse(new SolidBrush(Color.White), particles[i, j].GetX(), particles[i, j].GetY(), distance, distance);
            }
        }

        public void DrawParticles()
        {
            for (int l = 0; l < n; l++)
            {
                for (int m = 0; m < n; m++)
                {
                    DrawParticle(l, m);
                }
            }
        }

        public int CalculatedEnergy(int i, int j)
        {
            int up = i - 1;
            int down = i + 1;
            int left = j - 1;
            int right = j + 1;

            if (i == 0) up = n - 1;
            if (i == n - 1) down = 0;
            if (j == 0) left = n - 1;
            if (j == n - 1) right = 0;

            return (particles[up, left].GetSpin() + particles[up, j].GetSpin()
                + particles[i, left].GetSpin() + particles[i, right].GetSpin()
                + particles[down, j].GetSpin() + particles[down, right].GetSpin()) * particles[i, j].GetSpin();
        }

        public int RandomSpin()
        {
            int spin;
            spin = random.Next(2);
            if (spin == 0)
            {
                spin = -1;
            }

            return spin;
        }
    }
}
