using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2mm
{
    class BinomialDistribution : Distribution
    {

        public BinomialDistribution(double m, double p, int n)
        {
            P = p;
            N = n;
            M = m;
            EmpiricalAvg = P * M;
            EmpiricalDis = M * P * (1 - P);
            EmpiricalAsymmetry = ((1 - P) - P) / Math.Sqrt(N * P * (1 - P));
            EmpiricalExcess = (1 - (6 * (1 - P) * P)) / (N * P * (1 - P));
            
            Random rnd = new Random();
            StatArr = new double[1000];

            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    StatArr[i] += ((P - rnd.NextDouble()) > 0) ? 1 : 0;
                }
            }

            GetParams();
        }
    }
}
