using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3mm
{
    class СhiSquaredDistribution : Distribution
    {
        public СhiSquaredDistribution(int k, int size)
        {
            Size = size;
            TheoreticalAvg = k;
            TheoreticalDis = 2 * k;
            Random rnd = new Random();
            StatArr = new double[Size];

            var dist = new NormalDistribution(0, 1, 192, size);
            for (int i = 0; i < Size; i++)
            {
                StatArr[i] = 1;
                for (int j = 0; j < k/2; j++)
                {
                    StatArr[i] *= rnd.NextDouble();
                }
                StatArr[i] = - 2 * Math.Log(StatArr[i]);
                if (k%2 != 0)
                {
                   StatArr[i] += Math.Pow(dist.StatArr[i], 2);
                }
            }

            GetParams();
        }

    }
}
