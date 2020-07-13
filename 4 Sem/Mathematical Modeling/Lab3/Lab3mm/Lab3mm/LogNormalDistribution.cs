using System;

namespace Lab3mm
{
    class LogNormalDistribution : Distribution
    {
        
        public LogNormalDistribution(double m, double diviatSqrt, int size)
        {
            Size = size;
            TheoreticalAvg = Math.Exp(m + diviatSqrt/2);
            TheoreticalDis = (Math.Exp(diviatSqrt) - 1) * Math.Exp(2 * m + diviatSqrt);
            StatArr = new double[Size];

            var dist = new NormalDistribution(m, diviatSqrt, 192, size);
            for (int i = 0; i < Size; i++)
            {
                StatArr[i] = Math.Exp(dist.StatArr[i]);
            }

            GetParams();
        }
    }
}
