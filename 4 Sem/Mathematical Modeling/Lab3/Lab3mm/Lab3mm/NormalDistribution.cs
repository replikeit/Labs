using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3mm
{
    class NormalDistribution : Distribution
    {
        public double N { get; private set; }

        public NormalDistribution(double m, double diviatSqrt, double n, int size)
        {
            Size = size;
            N = n;
            TheoreticalAvg = m;
            TheoreticalDis = diviatSqrt;
            Random rnd = new Random();
            StatArr = new double[Size];
            double diviat = Math.Sqrt(diviatSqrt);

            for (int i = 0; i < Size; i++)
            {
                double val = -N / 2;
                for (int j = 0; j < N; j++)
                {
                    val += rnd.NextDouble();
                }
                StatArr[i] = diviat * (Math.Sqrt( 12 / N) * val) + m;
            }
                
            GetParams();
        }
    }
}
