using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2mm
{
    class BernoulliDistribution : Distribution
    {
        public BernoulliDistribution(double p, int n)
        {
            P = p;
            N = n;
            M = 1;
            EmpiricalAvg = P;
            EmpiricalDis = P * (1 - P);
            EmpiricalAsymmetry = ((1 - P) - P) / Math.Sqrt( P * (1 - P));
            EmpiricalExcess = ((6 * P * (P - 1)) + 1) / (P * (1 - P));

            Random rnd = new Random();
            StatArr = new double[1000].Select(x => rnd.NextDouble() > P ? 0.0d : 1.0d).ToArray();

            GetParams();
        }
    }
}
