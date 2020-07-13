using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3mm
{
    class LaplaceDistribution : Distribution
    {

        public LaplaceDistribution(double a, int size)
        {
            Size = size;
            TheoreticalAvg = 0;
            TheoreticalDis = 2/Math.Pow(a,2);
            Random rnd = new Random();
            StatArr = new double[Size];

            for (int i = 0; i < size; i++)
            {
                double rndDouble = rnd.NextDouble();
                StatArr[i] = 1 / a;
                StatArr[i] *= (rndDouble < 0.5)? Math.Log(2*rndDouble) : -Math.Log(2 * (1 - rndDouble));
            }

            GetParams();
        }
    }
}
