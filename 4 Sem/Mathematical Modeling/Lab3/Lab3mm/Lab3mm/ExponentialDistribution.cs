using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3mm
{
    class ExponentialDistribution : Distribution
    {
        public ExponentialDistribution(double lambda, int size)
        {
            Size = size;
            TheoreticalAvg = 1/lambda;
            TheoreticalDis = 1 / Math.Pow(lambda,2);
            Random rnd = new Random();
            StatArr = new double[Size];

            for (int i = 0; i < Size; i++)
            {
                StatArr[i] = -(Math.Log(rnd.NextDouble()))/lambda;
            }

            GetParams();
        }
    }
}
